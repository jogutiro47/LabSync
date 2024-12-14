using LabSync.Backend.Data;
using LabSync.Backend.Repositories.Interfaces;
using LabSync.Shared.Entites;
using Microsoft.EntityFrameworkCore;

namespace LabSync.Backend.Repositories.Implementations;

public class EPSaludsRepository : IEPSaludsRepository
{
    private readonly DataContext _context;

    public EPSaludsRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<EPSalud>> GetComboAsync()
    {
        return await _context.EPSaluds
           .OrderBy(x => x.AbreviaturaEPS)
           .ToListAsync();
    }
}