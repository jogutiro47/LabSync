using LabSync.Shared.DTOs;
using LabSync.Shared.Entites;
using LabSync.Shared.Responses;

namespace LabSync.Backend.Repositories.Interfaces;

public interface IPacientesRepository
{
    Task<ActionResponse<IEnumerable<Paciente>>> GetAsync();

    Task<ActionResponse<Paciente>> GetAsync(string id);

    Task<ActionResponse<Paciente>> AddAsync(PacienteDTO pacienteDTO);
}