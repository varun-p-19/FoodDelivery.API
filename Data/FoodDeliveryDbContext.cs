using FoodDelivery.API.Models;
using Microsoft.EntityFrameworkCore;
namespace FoodDelivery.API.Data
{
    public class FoodDeliveryDbContext:DbContext
    {
        public FoodDeliveryDbContext(DbContextOptions<FoodDeliveryDbContext> options) : base(options)
        {
        }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<Review> Reviews { get; set; }

    }
}
