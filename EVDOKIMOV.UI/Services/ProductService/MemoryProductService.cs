using EVDOKIMOV.Domain.Entities;
using EVDOKIMOV.Domain.Models;
using EVDOKIMOV.UI.Services.CategoryService;

namespace EVDOKIMOV.UI.Services.ProductService
{
    public class MemoryProductService : IProductService
    {
        private List<Dish> _dishes;
        private List<Category> _categories;

        public MemoryProductService(ICategoryService categoryService)
        {
            // получаем категории из сервиса
            _categories = categoryService
                .GetCategoryListAsync()
                .Result
                .Data;

            SetupData();
        }

        // инициализация коллекций
        private void SetupData()
        {
            _dishes = new List<Dish>
            {
                new Dish
                {
                    Id = 1,
                    Name = "Суп-харчо",
                    Description = "острый суп",
                    Calories = 200,
                    Image = "Images/Харчо.jpg",
                    CategoryId = _categories
                        .Find(c => c.NormalizedName == "soups").Id,
                    Category = _categories
                        .Find(c => c.NormalizedName == "soups")
                },
                new Dish
                {
                    Id = 2,
                    Name = "Борщ",
                    Description = "классический борщ",
                    Calories = 330,
                    Image = "Images/Борщ.jpg",
                    CategoryId = _categories
                        .Find(c => c.NormalizedName == "soups").Id,
                    Category = _categories
                        .Find(c => c.NormalizedName == "soups")
                },
                new Dish
                {
                    Id = 3,
                    Name = "Греческий салат",
                    Description = "с овощами и сыром",
                    Calories = 180,
                    Image = "Images/Салат.jpg",
                    CategoryId = _categories
                        .Find(c => c.NormalizedName == "salads").Id,
                    Category = _categories
                        .Find(c => c.NormalizedName == "salads")
                },
                new Dish
                {
                    Id = 4,
                    Name = "Чай",
                    Description = "черный",
                    Calories = 5,
                    Image = "Images/Чай.jpg",
                    CategoryId = _categories
                        .Find(c => c.NormalizedName == "drinks").Id,
                    Category = _categories
                        .Find(c => c.NormalizedName == "drinks")
                }
            };
        }

        // получение списка блюд
        public Task<ResponseData<List<Dish>>> GetProductListAsync(string? category)
        {
            var temp = _dishes.Where(d => String.IsNullOrEmpty(category) || d.Category.NormalizedName.Equals(category)).ToList();

            var result = ResponseData<List<Dish>>.OK(temp);

            // вернуть результат
            return Task.FromResult(result);
        }

        // остальные методы пока заглушки (будут в следующих работах)
        public Task<ResponseData<Dish>> GetProductByIdAsync(int id)
            => Task.FromResult(new ResponseData<Dish>());

        public Task UpdateProductAsync(int id, Dish product, IFormFile? formFile)
            => Task.CompletedTask;

        public Task DeleteProductAsync(int id)
            => Task.CompletedTask;

        public Task<ResponseData<Dish>> CreateProductAsync(Dish product, IFormFile? formFile)
            => Task.FromResult(new ResponseData<Dish>());
    }
}
