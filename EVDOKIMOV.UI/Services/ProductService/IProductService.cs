using EVDOKIMOV.Domain.Entities;
using EVDOKIMOV.Domain.Models;

namespace EVDOKIMOV.UI.Services.ProductService
{
    public interface IProductService
    {
        // получение списка блюд с фильтрацией по категории
        Task<ResponseData<List<Dish>>> GetProductListAsync(string? category);

        // получение блюда по id
        Task<ResponseData<Dish>> GetProductByIdAsync(int id);

        // обновление блюда
        Task UpdateProductAsync(int id, Dish product, IFormFile? formFile);

        // удаление блюда
        Task DeleteProductAsync(int id);

        // создание блюда
        Task<ResponseData<Dish>> CreateProductAsync(Dish product, IFormFile? formFile);
    }
}
