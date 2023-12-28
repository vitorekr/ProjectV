using Microsoft.AspNetCore.Mvc;
using ProjectV.Domain;
using ProjectV.Services;

namespace ProjectV.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContinentController : ControllerBase
    {
        private readonly ContinentService _continentService;

        public ContinentController(ContinentService continentService)
        {
            _continentService = continentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContinents()
        {
            var continent = await _continentService.GetAllContinentsAsync();
            return Ok(continent);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContinentById(int id)
        {
            var continent = await _continentService.GetContinentByIdAsync(id);
            if (continent == null)
            {
                return NotFound();
            }
            return Ok(continent);
        }

        [HttpPost]
        public async Task<IActionResult> AddContinent([FromBody] Continent continent)
        {
            // Validação simples do modelo recebido
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Implementar outras validações e regras de negócio necessárias antes de adicionar o país

            await _continentService.AddContinentAsync(continent);
            return CreatedAtAction(nameof(GetContinentById), new { id = continent.Id }, continent);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContinent(int id, [FromBody] Continent continent)
        {
            if (id != continent.Id)
            {
                return BadRequest("ID do país na URL difere do ID do país no corpo da requisição.");
            }

            // Implementar outras validações e regras de negócio necessárias antes de atualizar o país

            await _continentService.UpdateContinentAsync(continent);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContinent(int id)
        {
            // Implementar outras validações e regras de negócio necessárias antes de excluir o país

            await _continentService.DeleteContinentAsync(id);
            return NoContent();
        }
    }
}
