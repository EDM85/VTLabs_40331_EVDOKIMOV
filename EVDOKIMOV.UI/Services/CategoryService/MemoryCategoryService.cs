using EVDOKIMOV.Domain.Entities;
using EVDOKIMOV.Domain.Models;

namespace EVDOKIMOV.UI.Services.CategoryService
{
    public class MemoryCategoryService : ICategoryService
    {
        public Task<ResponseData<List<Category>>> GetCategoryListAsync()
        {
            // имитация данных
            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "Супы", NormalizedName = "soups" },
                new Category { Id = 2, Name = "Салаты", NormalizedName = "salads" },
                new Category { Id = 3, Name = "Напитки", NormalizedName = "drinks" }
            };

            var result = new ResponseData<List<Category>>();
            result.Data = categories;

            return Task.FromResult(result);
        }
    }
}
