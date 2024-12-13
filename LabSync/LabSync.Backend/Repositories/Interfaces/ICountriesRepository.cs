using LabSync.Shared.Entites;
using LabSync.Shared.Responses;

namespace LabSync.Backend.Repositories.Interfaces;

public interface ICountriesRepository
{
    Task<ActionResponse<Country>> GetAsync(int id);

    Task<ActionResponse<IEnumerable<Country>>> GetAsync();

    Task<IEnumerable<Country>> GetComboAsync();

    Task<ActionResponse<Country>> AddAsync(Country country);

    Task<ActionResponse<Country>> UpdateAsync(Country country);
}