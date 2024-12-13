using LabSync.Backend.Data;
using LabSync.Backend.Repositories.Interfaces;
using LabSync.Shared.Entites;
using LabSync.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace LabSync.Backend.Repositories.Implementations;

public class CountriesRepository : ICountriesRepository
{
    private readonly DataContext _context;

    public CountriesRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<ActionResponse<IEnumerable<Country>>> GetAsync()
    {
        var countries = await _context.Countries
           .OrderBy(c => c.Name)  // Ordenar por el nombre del país
          .ToListAsync();
        return new ActionResponse<IEnumerable<Country>>
        {
            WasSuccess = true,
            Result = countries
        };
    }

    public async Task<ActionResponse<Country>> GetAsync(int id)
    {
        var country = await _context.Countries
         .FirstOrDefaultAsync(c => c.Id == id);

        if (country == null)
        {
            return new ActionResponse<Country>
            {
                WasSuccess = false,
                Message = "ERR001"
            };
        }

        return new ActionResponse<Country>
        {
            WasSuccess = true,
            Result = country
        };
    }

    public async Task<IEnumerable<Country>> GetComboAsync()
    {
        return await _context.Countries
            .OrderBy(c => c.Name)
            .ToListAsync();
    }

    public async Task<ActionResponse<Country>> AddAsync(Country country)
    {
        _context.Add(country);
        await _context.SaveChangesAsync();
        return new ActionResponse<Country>
        {
            WasSuccess = true,
            Result = country
        };
    }

    public async Task<ActionResponse<Country>> UpdateAsync(Country country)
    {
        var existingCountry = await _context.Countries.FirstOrDefaultAsync(c => c.Id == country.Id);

        if (existingCountry == null)
        {
            return new ActionResponse<Country>
            {
                WasSuccess = false,
                Message = "ERR001" // Country not found
            };
        }

        if (_context.Entry(existingCountry).State == EntityState.Detached)
        {
            // Si la entidad no está siendo rastreada, la marcamos para ser actualizada
            _context.Update(country);
        }
        else
        {
            // Si ya está siendo rastreada, simplemente actualizamos las propiedades necesarias
            existingCountry.Name = country.Name;
            _context.Update(existingCountry);
        }

        await _context.SaveChangesAsync();

        return new ActionResponse<Country>
        {
            WasSuccess = true,
            Result = country
        };
    }
}