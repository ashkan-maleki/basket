using Basket.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Basket.Models.Persistence
{
    public class BasketDbContext : DbContext
    {
        public BasketDbContext(DbContextOptions<BasketDbContext> options) : base(options)
        {
        }

        public DbSet<Form> Forms { get; set; }
    }
}