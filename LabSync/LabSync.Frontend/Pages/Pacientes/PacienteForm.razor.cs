using CurrieTechnologies.Razor.SweetAlert2;
using LabSync.Frontend.Repositories;
using LabSync.Frontend.Shared.Resources;
using LabSync.Shared.Entites;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using LabSync.Shared.DTOs;
using MudBlazor;

namespace LabSync.Frontend.Pages.Pacientes;

public partial class PacienteForm
{
    private EditContext editContext = null!;
    private EPSalud selected_EPS = new();
    private List<EPSalud>? epssaluds;

    [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
    [Inject] private IStringLocalizer<Literals> Localizer { get; set; } = null!;
    [Inject] private IRepository Repository { get; set; } = null!;

    [EditorRequired, Parameter] public PacienteDTO PacienteDTO { get; set; } = null!;
    [EditorRequired, Parameter] public EventCallback OnValidSubmit { get; set; }
    [EditorRequired, Parameter] public EventCallback ReturnAction { get; set; }

    public bool FormPostedSuccessfully { get; set; } = false;

    protected override void OnInitialized()
    {
        editContext = new(PacienteDTO);
    }

    protected override async Task OnInitializedAsync()
    {
        await LoadEPSAsync();
    }

    private async Task LoadEPSAsync()
    {
        var responseHttp = await Repository.GetAsync<List<EPSalud>>("/api/EPSaluds/combo");
        if (responseHttp.Error)
        {
            var message = await responseHttp.GetErrorMessageAsync();
            await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
            return;
        }

        epssaluds = responseHttp.Response;
    }

    private async Task<IEnumerable<EPSalud>> SearchEPS(string searchText, CancellationToken cancellationToken)
    {
        await Task.Delay(5);
        if (string.IsNullOrWhiteSpace(searchText))
        {
            return epssaluds!;
        }

        return epssaluds!
            .Where(x => x.AbreviaturaEPS!.Contains(searchText, StringComparison.InvariantCultureIgnoreCase))
            .ToList();
    }

    private void EPSaludChanged(EPSalud epssalud)
    {
        selected_EPS = epssalud;
        PacienteDTO.EPSSaludId = epssalud.EPSSaludId;
    }

    private async Task OnBeforeInternalNavigation(LocationChangingContext context)
    {
        var formWasEdited = editContext.IsModified();

        if (!formWasEdited || FormPostedSuccessfully)
        {
            return;
        }

        var result = await SweetAlertService.FireAsync(new SweetAlertOptions
        {
            Title = Localizer["Confirmation"],
            Text = Localizer["LeaveAndLoseChanges"],
            Icon = SweetAlertIcon.Warning,
            ShowCancelButton = true,
            CancelButtonText = Localizer["Cancel"],
        });

        var confirm = !string.IsNullOrEmpty(result.Value);
        if (confirm)
        {
            return;
        }

        context.PreventNavigation();
    }
}