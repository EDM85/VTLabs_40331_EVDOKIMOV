using EVDOKIMOV.Domain.Entities;
using EVDOKIMOV.Domain.Models;

namespace EVDOKIMOV.Blazor.Services
{
    public class ApiProductService(HttpClient Http) : IProductService<Dish>
    {
        List<Dish> _dishes = new();
        int _currentPage = 1;
        int _totalPages = 1;
        public IEnumerable<Dish> Products => _dishes;
        public int CurrentPage => _currentPage;
        public int TotalPages => _totalPages;
        public event Action ListChanged;
        public async Task GetProducts(int pageNo = 1)
        {
            // отправить запрос http
            var result = await Http.GetAsync(Http.BaseAddress);
            // в случае успешного ответа
            if (result.IsSuccessStatusCode)
            {
                // получить данные из ответа
                var responseData = await result.Content
                .ReadFromJsonAsync<ResponseData<List<Dish>>>();
                // обновить параметры страниц
                _currentPage = pageNo;
                _totalPages = (int)Math.Ceiling(responseData.Data.Count() / (double)3);
                // получить нужную страницу
                _dishes = responseData.Data
                .Skip((pageNo - 1) * 3)
                .Take(3)
                .ToList();
                ListChanged?.Invoke();
            }
            // в случае ошибки
            else
            {
                _dishes = null;
                _currentPage = 1;
                _totalPages = 0;
            }
        }
    }
}
