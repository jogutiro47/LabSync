using LabSync.Shared.DTOs;
using LabSync.Shared.Entites;
using LabSync.Shared.Responses;

namespace LabSync.Backend.Repositories.Interfaces;

public interface IMuestrasRepository
{
    Task<ActionResponse<IEnumerable<Muestra>>> GetAsync();

    Task<ActionResponse<Muestra>> GetAsync(int id);

    Task<ActionResponse<Muestra>> AddAsync(MuestraDTO muestraDTO);
}