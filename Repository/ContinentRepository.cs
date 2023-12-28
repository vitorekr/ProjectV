using Microsoft.EntityFrameworkCore;
using ProjectV.Data;
using ProjectV.Domain;
using ProjectV.Interfaces;

namespace ProjectV.Repository
{
    public class ContinentRepository : IContinentRepository
    {
        private readonly TravelDbContext _context;

        public ContinentRepository(TravelDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Continent>> GetAllContinentsAsync()
        {
            return await _context.Continent.ToListAsync();
        }

        public async Task<Continent> GetContinentByIdAsync(int id)
        {
            return await _context.Continent.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddContinentAsync(Continent continent)
        {
            _context.Continent.Add(continent);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateContinentAsync(Continent continent)
        {
            _context.Continent.Update(continent);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteContinentAsync(int id)
        {
            var continent = await _context.Continent.FindAsync(id);
            if (continent != null)
            {
                _context.Continent.Remove(continent);
                await _context.SaveChangesAsync();
            }
        }
    }
}
