using EVDOKIMOV.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EVDOKIMOV.UI
{
    public class TempContext : DbContext
    {
            public TempContext (DbContextOptions<TempContext> opt) : base(opt)
            {

            }
            // контекст базы данных Categories и Dishes
            public DbSet<Category> Categories { get; set; }
            public DbSet<Dish> Dishes { get; set; }
    }
}
