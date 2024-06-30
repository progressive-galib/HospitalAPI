using HospitalAPI.DTOs;
using HospitalAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NCDsController : ControllerBase
    {
        private readonly NCDService _ncdService;

        public NCDsController(NCDService ncdService)
        {
            _ncdService = ncdService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NCDDto ncdDto)
        {
            await _ncdService.AddNCDAsync(ncdDto);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var ncd = await _ncdService.GetNCDAsync(id);
            if (ncd == null)
            {
                return NotFound();
            }

            return Ok(ncd);
        }
    }
}
