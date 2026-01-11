using EVDOKIMOV.Domain.Entities;
using EVDOKIMOV.Domain.Models;
using System.Text.Json;
using System.Net.Http.Json;

namespace EVDOKIMOV.UI.Services.ProductService
{
    public class ApiProductService(HttpClient httpClient) : IProductService
    {
        public async Task<ResponseData<Dish>> CreateProductAsync(Dish product, IFormFile? formFile)
        {
            var serializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            // послать запрос к API для сохранения объекта
            var response = await httpClient.PostAsJsonAsync(httpClient.BaseAddress, product);

            if (!response.IsSuccessStatusCode)
            {
                return ResponseData<Dish>
                    .Error($"Не удалось создать объект: {response.StatusCode}");
            }

            // если файл изображения передан клиентом
            if (formFile != null)
            {
                // получить созданный объект из ответа Api-сервиса
                var dish = await response.Content.ReadFromJsonAsync<Dish>();

                // создать объект запроса
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri($"{httpClient.BaseAddress.AbsoluteUri}/{dish.Id}")
                };

                // создать контент типа multipart form-data
                var content = new MultipartFormDataContent();

                // создать потоковый контент из переданного файла
                var streamContent = new StreamContent(formFile.OpenReadStream());

                // добавить потоковый контент в общий контент под именем "image"
                // имя файла оставим без изменений
                content.Add(streamContent, "image", formFile.FileName);

                // поместить контент в запрос
                request.Content = content;

                // послать запрос к Api-сервису
                response = await httpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    return ResponseData<Dish>
                        .Error($"Не удалось сохранить изображение: {response.StatusCode}");
                }
            }

            return ResponseData<Dish>.OK(null);
        }

        public Task DeleteProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseData<Dish>> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseData<List<Dish>>> GetProductListAsync(string? category)
        {
            var uri = httpClient.BaseAddress;

            var queryData = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(category))
            {
                queryData.Add("category", category);
            }

            var query = QueryString.Create(queryData);
            var result = await httpClient.GetAsync(uri + query.Value);

            if (result.IsSuccessStatusCode)
            {
                return await result.Content
                    .ReadFromJsonAsync<ResponseData<List<Dish>>>();
            }

            return ResponseData<List<Dish>>
                .Error("Ошибка чтения API");
        }

        public Task UpdateProductAsync(int id, Dish product, IFormFile? formFile)
        {
            throw new NotImplementedException();
        }
    }
}
