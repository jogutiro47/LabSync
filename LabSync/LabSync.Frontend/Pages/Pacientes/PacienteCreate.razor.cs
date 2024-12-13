using LabSync.Frontend.Repositories;
using LabSync.Frontend.Shared.Resources;
using LabSync.Shared.DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace LabSync.Frontend.Pages.Pacientes;

public partial class PacienteCreate
{
    private PacienteForm? pacienteForm;
    private PacienteDTO pacienteDTO = new();

    [Inject] private IRepository Repository { get; set; } = null!;
    [Inject] private NavigationManager NavigationManager { get; set; } = null!;
    [Inject] private ISnackbar Snackbar { get; set; } = null!;
    [Inject] private IStringLocalizer<Literals> Localizer { get; set; } = null!;

    private async Task CreateAsync()
    {
        var responseHttp = await Repository.PostAsync("/api/pacientes/full", pacienteDTO);
        if (responseHttp.Error)
        {
            var message = await responseHttp.GetErrorMessageAsync();
            Snackbar.Add(Localizer[message!], Severity.Error);
            return;
        }

        Return();
        Snackbar.Add(Localizer["RecordCreatedOk"], Severity.Success);
    }

    private void Return()
    {
        pacienteForm!.FormPostedSuccessfully = true;
        NavigationManager.NavigateTo("/teams");
    }
}