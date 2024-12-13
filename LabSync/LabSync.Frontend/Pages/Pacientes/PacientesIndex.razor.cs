using static MudBlazor.CategoryTypes;
using System.Net.Http;
using LabSync.Shared.Entites;
using CurrieTechnologies.Razor.SweetAlert2;
using LabSync.Frontend.Repositories;
using LabSync.Frontend.Shared.Resources;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using System.Xml.Linq;
using MudBlazor;

namespace LabSync.Frontend.Pages.Pacientes;

public partial class PacientesIndex
{
    private string _normalText = "";

    private bool dense = false;
    private bool hover = true;
    private bool striped = false;
    private bool bordered = false;
    private string searchString1 = "";

    //private List<Country>? Elements { get; set; }

    private Country selectedItem1 = null;  // Cambio de tipo a Country
    private HashSet<Country> selectedItems = new HashSet<Country>();
    private IEnumerable<Country> Countries = new List<Country>();

    [Inject] private IStringLocalizer<Literals> Localizer { get; set; } = null!;
    [Inject] private IRepository Repository { get; set; } = null!;
    [Inject] private IDialogService DialogService { get; set; } = null!;
    [Inject] private ISnackbar Snackbar { get; set; } = null!;
    [Inject] private NavigationManager NavigationManager { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        //Elements = await httpClient.GetFromJsonAsync<List<Element>>("webapi/periodictable");
        await LoadAsync();
    }

    private async Task LoadAsync()
    {
        var responseHppt = await Repository.GetAsync<List<Country>>("api/countries");
        if (responseHppt.Error)
        {
            var message = await responseHppt.GetErrorMessageAsync();
            Snackbar.Add(Localizer[message!], Severity.Error);
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

    private async Task ShowModalAsync(int id = 0, bool isEdit = false)
    {
        var options = new DialogOptions() { CloseOnEscapeKey = true, CloseButton = true };
        IDialogReference? dialog;
        if (isEdit)
        {
            var parameters = new DialogParameters
                {
                    { "Id", id }
                };
            dialog = DialogService.Show<PacientesCreate>($"{Localizer["Edit"]} {Localizer["Patients"]}", parameters, options);
        }
        else
        {
            dialog = DialogService.Show<PacientesCreate>($"{Localizer["New"]} {Localizer["Patients"]}", options);
        }

        var result = await dialog.Result;
        if (result!.Canceled)
        {
            await LoadAsync();
            //await _table.ReloadServerData();
        }
    }
}