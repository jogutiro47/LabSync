using LabSync.Backend.Data;
using LabSync.Backend.Repositories.Interfaces;
using LabSync.Shared.DTOs;
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

    public async Task<ActionResponse<Paciente>> AddAsync(PacienteDTO pacienteDTO)
    {
        var eps = await _context.EPSaluds.FindAsync(pacienteDTO.EPSSaludId);
        if (eps == null)
        {
            return new ActionResponse<Paciente>
            {
                WasSuccess = false,
                Message = "ERR004"
            };
        }

        var paciente = new Paciente
        {
            TipoDocumento = pacienteDTO.TipoDocumento,
            NumeroIdentidad = pacienteDTO.NumeroIdentidad,
            Nombres = pacienteDTO.Nombres,
            Apellidos = pacienteDTO.Apellidos,
            FechaNacimiento = pacienteDTO.FechaNacimiento,
            Direccion = pacienteDTO.Direccion,
            Telefono = pacienteDTO.Telefono,
            CorreoElectronico = pacienteDTO.CorreoElectronico,
            GrupoSanguineo = pacienteDTO.GrupoSanguineo,
            Sexo = pacienteDTO.Sexo,
            EstadoCivil = pacienteDTO.EstadoCivil,
            Alergias = pacienteDTO.Alergias,
            EPSSalud = eps,
            FechaRegistro = DateTime.Now
        };

        _context.Add(paciente);
        try
        {
            await _context.SaveChangesAsync();
            return new ActionResponse<Paciente>
            {
                WasSuccess = true,
                Result = paciente
            };
        }
        catch (DbUpdateException)
        {
            return new ActionResponse<Paciente>
            {
                WasSuccess = false,
                Message = "ERR003"
            };
        }
        catch (Exception exception)
        {
            return new ActionResponse<Paciente>
            {
                WasSuccess = false,
                Message = exception.Message
            };
        }
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