using ProjectV.Domain;
using ProjectV.Interfaces;
using ProjectV.Repository.Interfaces;

namespace ProjectV.Services
{
    public class CountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IContinentRepository _continentRepository;

        public CountryService(ICountryRepository countryRepository, IContinentRepository continentRepository)
        {
            _countryRepository = countryRepository;
            _continentRepository = continentRepository;
        }

        public async Task<IEnumerable<Country>> GetAllCountriesAsync()
        {
            return await _countryRepository.GetAllCountriesAsync();
        }

        public async Task<Country> GetCountryByIdAsync(int id)
        {
            return await _countryRepository.GetCountryByIdAsync(id);
        }

        public async Task AddCountryAsync(Country country)
        {
            var continent = await _continentRepository.GetContinentByIdAsync(country.ContinentId);
            country.Continent = continent;
            await _countryRepository.AddCountryAsync(country);
        }

        public async Task UpdateCountryAsync(Country country)
        {
            // Implementar regras de negócio antes de atualizar o país
            // Por exemplo, verificar se o país existe, fazer validações, etc.
            await _countryRepository.UpdateCountryAsync(country);
        }

        public async Task DeleteCountryAsync(int id)
        {
            // Implementar regras de negócio antes de excluir o país
            // Por exemplo, verificar se o país existe, verificar dependências, etc.
            await _countryRepository.DeleteCountryAsync(id);
        }

        // Outros métodos personalizados que encapsulam regras de negócio relacionadas aos países...
    }

}
