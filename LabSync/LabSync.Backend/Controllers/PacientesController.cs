using LabSync.Backend.Data;
using LabSync.Backend.Repositories.Implementations;
using LabSync.Backend.Repositories.Interfaces;
using LabSync.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LabSync.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacientesController : ControllerBase
    {
        private readonly IPacientesRepository _pacientesRepository;

        public PacientesController(IPacientesRepository pacientesRepository)
        {
            _pacientesRepository = pacientesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var response = await _pacientesRepository.GetAsync();
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var response = await _pacientesRepository.GetAsync(id);
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return NotFound(response.Message);
        }

        [HttpPost("full")]
        public async Task<IActionResult> PostAsync(PacienteDTO pacienteDTO)
        {
            var action = await _pacientesRepository.AddAsync(pacienteDTO);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest(action.Message);
        }
    }
}