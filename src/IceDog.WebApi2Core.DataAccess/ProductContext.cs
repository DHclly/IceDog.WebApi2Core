using IceDog.WebApi2Core.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace IceDog.WebApi2Core.DataAccess
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
