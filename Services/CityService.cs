using Microsoft.EntityFrameworkCore;
using ProjectV.Domain;
using ProjectV.Repository.Interfaces;

namespace ProjectV.Services
{
    public class CityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly ICountryRepository _countryRepository;

        public CityService(ICityRepository cityRepository, ICountryRepository countryRepository)
        {
            _cityRepository = cityRepository;
            _countryRepository = countryRepository;
        }

        public async Task<IEnumerable<City>> GetAllCitiesAsync()
        {
            return await _cityRepository.GetAllCitiesAsync();
        }

        public async Task<City> GetCityByIdAsync(int id)
        {
            return await _cityRepository.GetCityByIdAsync(id);
        }

        public async Task AddCityAsync(City city)
        {
            if (city.IsCapital)
            {
                var country = await _countryRepository.GetCountryByIdAsync(city.CountryId);
                if (country != null)
                {
                    city.Country = country;
                    await _cityRepository.AddCityAsync(city);

                    country.Capital = city;
                    await _countryRepository.UpdateCountryAsync(country);
                }
                else
                {
                    throw new InvalidOperationException("The associated country does not exist.");
                }
            }
            else
            {
                var country = await _countryRepository.GetCountryByIdAsync(city.CountryId);
                city.Country = country;
                await _cityRepository.AddCityAsync(city);
            }
        }

        public async Task UpdateCityAsync(City city)
        {
            // Implementar regras de negócio antes de atualizar o país
            // Por exemplo, verificar se o país existe, fazer validações, etc.
            await _cityRepository.UpdateCityAsync(city);
        }

        public async Task DeleteCityAsync(int id)
        {
            // Implementar regras de negócio antes de excluir o país
            // Por exemplo, verificar se o país existe, verificar dependências, etc.
            await _cityRepository.DeleteCityAsync(id);
        }

        // Outros métodos personalizados que encapsulam regras de negócio relacionadas aos países...
    }
}
