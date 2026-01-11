using EVDOKIMOV.Domain.Entities;
using EVDOKIMOV.Domain.Models;

namespace EVDOKIMOV.UI.Services.CategoryService
{
    public class ApiCategoryService(HttpClient httpClient) : ICategoryService
    {
        public async Task<ResponseData<List<Category>>> GetCategoryListAsync()
        {
            var result = await httpClient.GetAsync(httpClient.BaseAddress);
            if (result.IsSuccessStatusCode)
            {
                return await result.Content
                    .ReadFromJsonAsync<ResponseData<List<Category>>>();
            }

            return ResponseData<List<Category>>
                .Error("Ошибка чтения API");
        }
    }
}
