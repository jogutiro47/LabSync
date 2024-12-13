using LabSync.Backend.Data;
using LabSync.Backend.Repositories.Interfaces;
using LabSync.Shared.Entites;
using LabSync.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace LabSync.Backend.Repositories.Implementations;

public class PacientesRepository : IPacientesRepository
{
    private readonly DataContext _context;

    public PacientesRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<ActionResponse<IEnumerable<Paciente>>> GetAsync()
    {
        var pacientes = await _context.Pacientes
          .Include(x => x.EPSSalud)
          .OrderBy(c => c.Nombres)
          .ToListAsync();
        return new ActionResponse<IEnumerable<Paciente>>
        {
            WasSuccess = true,
            Result = pacientes
        };
    }

    public async Task<ActionResponse<Paciente>> GetAsync(string id)
    {
        var paciente = await _context.Pacientes
         .Include(x => x.EPSSalud)
         .FirstOrDefaultAsync(c => c.NumeroIdentidad == id);

        if (paciente == null)
        {
            return new ActionResponse<Paciente>
            {
                WasSuccess = false,
                Message = "ERR001"
            };
        }

        return new ActionResponse<Paciente>
        {
            WasSuccess = true,
            Result = paciente
        };
    }
}