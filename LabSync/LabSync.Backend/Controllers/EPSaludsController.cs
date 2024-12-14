using LabSync.Backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LabSync.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EPSaludsController : ControllerBase
    {
        private readonly IEPSaludsRepository _epsRepository;

        public EPSaludsController(IEPSaludsRepository epsrepository)
        {
            _epsRepository = epsrepository;
        }

        [HttpGet("combo")]
        public async Task<IActionResult> GetComboAsync()
        {
            return Ok(await _epsRepository.GetComboAsync());
        }
    }
}