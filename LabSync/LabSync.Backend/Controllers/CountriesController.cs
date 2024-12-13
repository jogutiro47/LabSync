using LabSync.Backend.Data;
using LabSync.Backend.Repositories.Interfaces;
using LabSync.Shared.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LabSync.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountriesController : ControllerBase
{
    private readonly ICountriesRepository _countriesRepository;

    public CountriesController(ICountriesRepository countriesRepository)
    {
        _countriesRepository = countriesRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var response = await _countriesRepository.GetAsync();
        if (response.WasSuccess)
        {
            return Ok(response.Result);
        }
        return BadRequest();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id)
    {
        var response = await _countriesRepository.GetAsync(id);
        if (response.WasSuccess)
        {
            return Ok(response.Result);
        }
        return NotFound(response.Message);
    }

    [HttpGet("combo")]
    public async Task<IActionResult> GetComboAsync()
    {
        return Ok(await _countriesRepository.GetComboAsync());
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(Country country)
    {
        var response = await _countriesRepository.AddAsync(country);
        if (response.WasSuccess)
        {
            return Ok(response.Result);
        }
        return BadRequest(response.Message); // Si hubo un error, lo notifica
    }

    [HttpPut]
    public async Task<IActionResult> PutAsync(Country country)
    {
        var response = await _countriesRepository.UpdateAsync(country);
        if (response.WasSuccess)
        {
            return Ok(response.Result);  // Retorna el país actualizado
        }
        return NotFound(response.Message); // Si no se encuentra el país, se devuelve 404
    }
}