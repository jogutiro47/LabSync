using LabSync.Frontend.Repositories;
using LabSync.Frontend.Shared.Resources;
using LabSync.Shared.Entites;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace LabSync.Frontend.Pages.Countries;

public partial class CountriesIndex
{
    [Inject] private IRepository Repository { get; set; } = null!;
    [Inject] private IStringLocalizer<Literals> Localizer { get; set; } = null!;

    private List<Country>? Countries { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var responseHppt = await Repository.GetAsync<List<Country>>("api/countries");
        Countries = responseHppt.Response!;
    }
}