using IceDog.WebApi2Core.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace IceDog.WebApi2Core.DataAccess
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
    }
}
