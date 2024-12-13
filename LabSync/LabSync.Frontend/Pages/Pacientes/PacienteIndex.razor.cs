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
using LabSync.Shared.DTOs;
using LabSync.Frontend.Pages.Countries;

namespace LabSync.Frontend.Pages.Pacientes;

public partial class PacienteIndex
{
    private string _normalText = "";

    private bool dense = false;
    private bool hover = true;
    private bool striped = false;
    private bool bordered = false;
    private string searchString1 = "";

    private Paciente? selectedItem1 = null;  // Cambio de tipo a Country
    private HashSet<Paciente> selectedItems = new HashSet<Paciente>();
    private IEnumerable<Paciente> Countries = new List<Paciente>();

    [Inject] private IStringLocalizer<Literals> Localizer { get; set; } = null!;
    [Inject] private IRepository Repository { get; set; } = null!;
    [Inject] private IDialogService DialogService { get; set; } = null!;
    [Inject] private ISnackbar Snackbar { get; set; } = null!;
    [Inject] private NavigationManager NavigationManager { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        await LoadAsync();
    }

    private async Task LoadAsync()
    {
        var responseHppt = await Repository.GetAsync<List<Paciente>>("api/Pacientes");
        if (responseHppt.Error)
        {
            var message = await responseHppt.GetErrorMessageAsync();
            Snackbar.Add(Localizer[message!], Severity.Error);
            return;
        }
        Countries = responseHppt.Response!;
    }

    private bool FilterFunc1(Paciente paciente) => FilterFunc(paciente, searchString1);

    private bool FilterFunc(Paciente paciente, string searchString)
    {
        if (string.IsNullOrWhiteSpace(searchString))
            return true;

        return paciente.NumeroIdentidad!.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
               paciente.Nombres!.Contains(searchString);
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
            dialog = DialogService.Show<CountryCreate>($"{Localizer["Edit"]} {Localizer["Patients"]}", parameters, options);
        }
        else
        {
            dialog = DialogService.Show<PacienteCreate>($"{Localizer["New"]} {Localizer["Patients"]}", options);
        }

        var result = await dialog.Result;
        if (result!.Canceled)
        {
            await LoadAsync();
            //await _table.ReloadServerData();
        }
    }
}