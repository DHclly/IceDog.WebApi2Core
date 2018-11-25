using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IceDog.WebApi2Core.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace IceDog.WebApi2Core.DataAccess.Repositories
{
    public class ProductsRepository
    {
        private readonly ProductContext _context;

        public ProductsRepository(ProductContext context)
        {
            _context = context;

            if (_context.Products.Count() == 0)
            {
                _context.Products.AddRange(
                    new Product
                    {
                        IsDiscontinued = true,
                        Name = "Learning ASP.NET Core",
                        Description = "A best-selling book covering the fundamentals of ASP.NET Core"
                    },
                    new Product
                    {
                        Name = "Learning EF Core",
                        Description = "A best-selling book covering the fundamentals of Entity Framework Core"
                    });
                _context.SaveChanges();
            }
        }

        public async Task<List<Product>> GetDiscontinuedProductsAsync()
        {
            return await _context.Products
                                 .Where(p => p.IsDiscontinued)
                                 .ToListAsync();
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<int> AddProductAsync(Product product)
        {
            int rowsAffected = 0;

            _context.Products.Add(product);
            rowsAffected = await _context.SaveChangesAsync();

            return rowsAffected;
        }
    }
}
