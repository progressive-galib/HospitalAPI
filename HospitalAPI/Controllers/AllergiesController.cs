using HospitalAPI.DTOs;
using HospitalAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergiesController : ControllerBase
    {
        private readonly AllergyService _allergyService;

        public AllergiesController(AllergyService allergyService)
        {
            _allergyService = allergyService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AllergyDto allergyDto)
        {
            await _allergyService.AddAllergyAsync(allergyDto);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var allergy = await _allergyService.GetAllergyAsync(id);
            if (allergy == null)
            {
                return NotFound();
            }

            return Ok(allergy);
        }
    }
}
