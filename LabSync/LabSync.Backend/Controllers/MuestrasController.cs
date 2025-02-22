using LabSync.Backend.Repositories.Implementations;
using LabSync.Backend.Repositories.Interfaces;
using LabSync.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LabSync.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MuestrasController : ControllerBase
    {
        private readonly IMuestrasRepository _muestrasRepository;

        public MuestrasController(IMuestrasRepository muestraRepository)
        {
            _muestrasRepository = muestraRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var response = await _muestrasRepository.GetAsync();
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var response = await _muestrasRepository.GetAsync(id);
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return NotFound(response.Message);
        }

        [HttpPost("PostMuestra")]
        public async Task<IActionResult> PostAsync(MuestraDTO muestraDTO)
        {
            var action = await _muestrasRepository.AddAsync(muestraDTO);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest(action.Message);
        }
    }
}