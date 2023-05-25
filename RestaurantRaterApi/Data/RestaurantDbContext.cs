using Microsoft.EntityFrameworkCore;

namespace RestaurantRaterApi.Data;

// to inherit form the DbContext class we do "ClassName : DbContext"
public class RestaurantDbContext : DbContext
{
    // base is the keyword for our parent class, so base() is our parent constructor
    public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) 
    : base(options){}
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Rating> Ratings { get; set; }
}