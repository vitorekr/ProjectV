using Microsoft.AspNetCore.Mvc;
using ProjectV.Domain;
using ProjectV.Services;

namespace ProjectV.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        private readonly CityService _cityService;

        public CityController(CityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCities()
        {
            var cities = await _cityService.GetAllCitiesAsync();
            return Ok(cities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCityById(int id)
        {
            var city = await _cityService.GetCityByIdAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }

        [HttpPost]
        public async Task<IActionResult> AddCity([FromBody] City city)
        {
            // Validação simples do modelo recebido
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Implementar outras validações e regras de negócio necessárias antes de adicionar o país

            await _cityService.AddCityAsync(city);
            return CreatedAtAction(nameof(GetCityById), new { id = city.Id }, city);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCityy(int id, [FromBody] City city)
        {
            if (id != city.Id)
            {
                return BadRequest("ID do país na URL difere do ID do país no corpo da requisição.");
            }

            // Implementar outras validações e regras de negócio necessárias antes de atualizar o país

            await _cityService.UpdateCityAsync(city);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            // Implementar outras validações e regras de negócio necessárias antes de excluir o país

            await _cityService.DeleteCityAsync(id);
            return NoContent();
        }
    }
}
