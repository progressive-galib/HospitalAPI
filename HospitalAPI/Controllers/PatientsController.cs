using HospitalAPI.DTOs;
using HospitalAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly PatientService _patientService;

        public PatientsController(PatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PatientDto patientDto)
        {
            await _patientService.AddPatientAsync(patientDto);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var patient = await _patientService.GetPatientAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }
    }
}
