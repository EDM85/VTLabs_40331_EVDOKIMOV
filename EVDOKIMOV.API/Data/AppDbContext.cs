using EVDOKIMOV.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EVDOKIMOV.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
