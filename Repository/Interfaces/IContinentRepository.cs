using ProjectV.Domain;

namespace ProjectV.Interfaces
{
    public interface IContinentRepository
    {
        Task<IEnumerable<Continent>> GetAllContinentsAsync();
        Task<Continent> GetContinentByIdAsync(int id);
        Task AddContinentAsync(Continent continent);
        Task UpdateContinentAsync(Continent continent);
        Task DeleteContinentAsync(int id);
    }
}
