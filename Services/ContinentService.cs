using ProjectV.Domain;
using ProjectV.Interfaces;

namespace ProjectV.Services
{
    public class ContinentService
    {
        private readonly IContinentRepository _continentRepository;

        public ContinentService(IContinentRepository continentRepository)
        {
            _continentRepository = continentRepository;
        }

        public async Task<IEnumerable<Continent>> GetAllContinentsAsync()
        {
            return await _continentRepository.GetAllContinentsAsync();
        }

        public async Task<Continent> GetContinentByIdAsync(int id)
        {
            return await _continentRepository.GetContinentByIdAsync(id);
        }

        public async Task AddContinentAsync(Continent continent)
        {
            // Implementar regras de negócio antes de adicionar o país
            // Por exemplo, validar dados, checar duplicações, etc.
            await _continentRepository.AddContinentAsync(continent);
        }

        public async Task UpdateContinentAsync(Continent continent)
        {
            // Implementar regras de negócio antes de atualizar o país
            // Por exemplo, verificar se o país existe, fazer validações, etc.
            await _continentRepository.UpdateContinentAsync(continent);
        }

        public async Task DeleteContinentAsync(int id)
        {
            // Implementar regras de negócio antes de excluir o país
            // Por exemplo, verificar se o país existe, verificar dependências, etc.
            await _continentRepository.DeleteContinentAsync(id);
        }

        // Outros métodos personalizados que encapsulam regras de negócio relacionadas aos países...
    }
}
