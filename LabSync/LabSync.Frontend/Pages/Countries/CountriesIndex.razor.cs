using CurrieTechnologies.Razor.SweetAlert2;
using LabSync.Frontend.Repositories;
using LabSync.Frontend.Shared.Resources;
using LabSync.Shared.Entites;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;
using static MudBlazor.CategoryTypes;

namespace LabSync.Frontend.Pages.Countries;

public partial class CountriesIndex
{
    private MudTable<Country> _table = new();
    private IEnumerable<Country> Countries = new List<Country>();

    private Country selectedItem1 = null;  // Cambio de tipo a Country
    private HashSet<Country> selectedItems = new HashSet<Country>();

    private bool dense = false;
    private bool hover = true;
    private bool striped = false;
    private bool bordered = false;
    private string searchString1 = "";

    [Inject] private IRepository Repository { get; set; } = null!;
    [Inject] private IStringLocalizer<Literals> Localizer { get; set; } = null!;
    [Inject] private NavigationManager NavigationManager { get; set; } = null!;
    [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        await LoadAsync();
    }

    private async Task LoadAsync()
    {
        var responseHppt = await Repository.GetAsync<List<Country>>("api/countries");
        if (responseHppt.Error)
        {
            var message = await responseHppt.GetErrorMessageAsync();
            await SweetAlertService.FireAsync(Localizer["Error"], message, SweetAlertIcon.Error);
            return;
        }
        Countries = responseHppt.Response!;
    }

    private bool FilterFunc1(Country country) => FilterFunc(country, searchString1);

    private bool FilterFunc(Country country, string searchString)
    {
        if (string.IsNullOrWhiteSpace(searchString))
            return true;

        return country.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
               country.Id.ToString().Contains(searchString);
    }

    private void PageChanged(int i)
    {
        _table.NavigateTo(i - 1);
    }
}