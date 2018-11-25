using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IceDog.WebApi2Core.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace IceDog.WebApi2Core.DataAccess.Repositories
{
    public class PetsRepository
    {
        private readonly PetContext _context;

        public PetsRepository(PetContext context)
        {
            _context = context;

            if (_context.Pets.Count() == 0)
            {
                _context.Pets.AddRange(
                    new Pet
                    {
                        Name = "Opie 奥比",
                        Breed = "Shih Tzu 狮子狗",
                        PetType = PetType.Dog
                    },
                    new Pet
                    {
                        Name = "Reggie 雷吉",
                        Breed = "Beagle 猎兔犬",
                        PetType = PetType.Dog
                    },
                    new Pet
                    {
                        Name = "Diesel 迪赛",
                        Breed = "Bombay 孟买猫",
                        PetType = PetType.Cat
                    },
                    new Pet
                    {
                        Name = "Lucy 露西",
                        Breed = "Maine Coon 缅因猫",
                        PetType = PetType.Cat
                    },
                    new Pet {
                        Name="gou zi 狗子",
                        Breed= "Chinese pastoral dog 中华田园犬",
                        PetType = PetType.Dog
                    });
                _context.SaveChanges();
            }
        }

        public async Task<List<Pet>> GetPetsAsync()
        {
            return await _context.Pets.ToListAsync();
        }

        public async Task<Pet> GetPetAsync(int id)
        {
            return await _context.Pets.FindAsync(id);
        }

        public async Task<int> AddPetAsync(Pet pet)
        {
            int rowsAffected = 0;

            _context.Pets.Add(pet);
            rowsAffected = await _context.SaveChangesAsync();

            return rowsAffected;
        }
    }
}
