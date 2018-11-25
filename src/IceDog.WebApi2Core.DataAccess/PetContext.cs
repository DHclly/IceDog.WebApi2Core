using IceDog.WebApi2Core.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace IceDog.WebApi2Core.DataAccess
{
    public class PetContext : DbContext
    {
        public PetContext(DbContextOptions<PetContext> options)
            : base(options)
        {
        }

        public DbSet<Pet> Pets { get; set; }
    }
}
