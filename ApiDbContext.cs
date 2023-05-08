using Microsoft.EntityFrameworkCore;
using ODataCoreDemo.Models;

namespace ODataCoreDemo
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options)
        : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
