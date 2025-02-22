using LabSync.Backend.Data;
using LabSync.Backend.Repositories.Interfaces;
using LabSync.Shared.DTOs;
using LabSync.Shared.Entites;
using LabSync.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace LabSync.Backend.Repositories.Implementations;

public class MuestrasRepository : IMuestrasRepository
{
    private readonly DataContext _context;

    public MuestrasRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<ActionResponse<Muestra>> AddAsync(MuestraDTO muestraDTO)
    {
        var muestra = new Muestra
        {
            PacienteId = muestraDTO.PacienteId,
            Fechaingreso = muestraDTO.Fechaingreso,
            MaterialEnviado = muestraDTO.MaterialEnviado,
            Protocolo = muestraDTO.Protocolo,
            IdMedicoOrigen = muestraDTO.IdMedicoOrigen,
            EstadoId = 1
        };

        _context.Add(muestra);
        try
        {
            await _context.SaveChangesAsync();
            return new ActionResponse<Muestra>
            {
                WasSuccess = true,
                Result = muestra
            };
        }
        catch (DbUpdateException)
        {
            return new ActionResponse<Muestra>
            {
                WasSuccess = false,
                Message = "ERR003"
            };
        }
        catch (Exception exception)
        {
            return new ActionResponse<Muestra>
            {
                WasSuccess = false,
                Message = exception.Message
            };
        }
    }

    public async Task<ActionResponse<IEnumerable<Muestra>>> GetAsync()
    {
        var muestras = await _context.Muestras
                  .Include(x => x.Paciente)
                   .Include(x => x.Paciente)
                  .OrderBy(x => x.MuestraId)
                  .ToListAsync();
        return new ActionResponse<IEnumerable<Muestra>>
        {
            WasSuccess = true,
            Result = muestras
        };
    }

    public async Task<ActionResponse<Muestra>> GetAsync(int id)
    {
        var muestras = await _context.Muestras
                .Include(x => x.Paciente)
                .FirstOrDefaultAsync(c => c.MuestraId == id);

        if (muestras == null)
        {
            return new ActionResponse<Muestra>
            {
                WasSuccess = false,
                Message = "ERR001"
            };
        }

        return new ActionResponse<Muestra>
        {
            WasSuccess = true,
            Result = muestras
        };
    }
}