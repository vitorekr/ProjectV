using Microsoft.EntityFrameworkCore;
using ProjectV.Data;
using ProjectV.Domain;
using ProjectV.Repository.Interfaces;

namespace ProjectV.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly TravelDbContext _context;

        public CountryRepository(TravelDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Country>> GetAllCountriesAsync()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<Country> GetCountryByIdAsync(int id)
        {
            return await _context.Countries.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddCountryAsync(Country country)
        {
            _context.Countries.Add(country);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCountryAsync(Country country)
        {
            _context.Countries.Update(country);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCountryAsync(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country != null)
            {
                _context.Countries.Remove(country);
                await _context.SaveChangesAsync();
            }
        }
    }

}
