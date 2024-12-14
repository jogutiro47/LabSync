using LabSync.Shared.Entites;

namespace LabSync.Backend.Repositories.Interfaces
{
    public interface IEPSaludsRepository
    {
        Task<IEnumerable<EPSalud>> GetComboAsync();
    }
}