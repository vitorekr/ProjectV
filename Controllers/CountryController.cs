using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectV.Domain;
using ProjectV.Services;

namespace ProjectV.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly CountryService _countryService;

        public CountryController(CountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCountries()
        {
            var countries = await _countryService.GetAllCountriesAsync();
            return Ok(countries);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCountryById(int id)
        {
            var country = await _countryService.GetCountryByIdAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }

        [HttpPost]
        public async Task<IActionResult> AddCountry([FromBody] Country country)
        {          
            // Validação simples do modelo recebido
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Implementar outras validações e regras de negócio necessárias antes de adicionar o país

            await _countryService.AddCountryAsync(country);
            return CreatedAtAction(nameof(GetCountryById), new { id = country.Id }, country);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCountry(int id, [FromBody] Country country)
        {
            if (id != country.Id)
            {
                return BadRequest("ID do país na URL difere do ID do país no corpo da requisição.");
            }

            // Implementar outras validações e regras de negócio necessárias antes de atualizar o país

            await _countryService.UpdateCountryAsync(country);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            // Implementar outras validações e regras de negócio necessárias antes de excluir o país

            await _countryService.DeleteCountryAsync(id);
            return NoContent();
        }
    }

}
