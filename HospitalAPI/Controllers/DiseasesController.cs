using HospitalAPI.DTOs;
using HospitalAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseasesController : ControllerBase
    {
        private readonly DiseaseService _diseaseService;

        public DiseasesController(DiseaseService diseaseService)
        {
            _diseaseService = diseaseService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DiseaseDto diseaseDto)
        {
            await _diseaseService.AddDiseaseAsync(diseaseDto);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var disease = await _diseaseService.GetDiseaseAsync(id);
            if (disease == null)
            {
                return NotFound();
            }

            return Ok(disease);
        }
    }
}
