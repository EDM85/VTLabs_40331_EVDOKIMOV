using EVDOKIMOV.Domain.Entities;

namespace EVDOKIMOV.API.Data
{
    public static class DbInit
    {
        public static async Task SetupAsync(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            using var db = scope.ServiceProvider.GetService<AppDbContext>();

            await db.Categories.AddRangeAsync([ 

                // имитация данных

                new Category { Name = "Супы", NormalizedName = "soups" },
                new Category { Name = "Салаты", NormalizedName = "salads" },
                new Category { Name = "Напитки", NormalizedName = "drinks" }
            ]);

            // сохраняем изменения в базе данных для Категорий блюд
            await db.SaveChangesAsync();

            await db.Dishes.AddRangeAsync([
                new Dish
                {
                    Id = 1,
                    Name = "Суп-харчо",
                    Description = "острый суп",
                    Calories = 200,
                    Image = "https://localhost:7002/Images/Харчо.jpg",
                    CategoryId = db.Categories
                        .First(c => c.NormalizedName == "soups").Id,
                    Category = db.Categories
                        .First(c => c.NormalizedName == "soups")
                },
                new Dish
                {
                    Id = 2,
                    Name = "Борщ",
                    Description = "классический борщ",
                    Calories = 330,
                    Image = "https://localhost:7002/Images/Борщ.jpg",
                    CategoryId = db.Categories
                        .First(c => c.NormalizedName == "soups").Id,
                    Category = db.Categories
                        .First(c => c.NormalizedName == "soups")
                },
                new Dish
                {
                    Id = 3,
                    Name = "Греческий салат",
                    Description = "с овощами и сыром",
                    Calories = 180,
                    Image = "https://localhost:7002/Images/Салат.jpg",
                    CategoryId = db.Categories
                        .First(c => c.NormalizedName == "salads").Id,
                    Category = db.Categories
                        .First(c => c.NormalizedName == "salads")
                },
                new Dish
                {
                    Id = 4,
                    Name = "Чай",
                    Description = "черный",
                    Calories = 5,
                    Image = "https://localhost:7002/Images/Чай.jpg",
                    CategoryId = db.Categories
                        .First(c => c.NormalizedName == "drinks").Id,
                    Category = db.Categories
                        .First(c => c.NormalizedName == "drinks")
                }]);

            // сохраняем изменения в базе данных для Блюд
            await db.SaveChangesAsync();
        }
    }
}
