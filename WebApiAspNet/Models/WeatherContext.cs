using Microsoft.EntityFrameworkCore;

namespace WebApiAspNet.Models
{
    public class WeatherContext : DbContext
    {
        public WeatherContext(DbContextOptions<WeatherContext> options)
            : base(options)
        {
        }

        public DbSet<WeatherForecast> TodoItems { get; set; } = null!;
    }
}
