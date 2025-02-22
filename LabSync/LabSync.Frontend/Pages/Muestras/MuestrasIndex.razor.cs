using LabSync.Frontend.Repositories;
using LabSync.Frontend.Shared.Resources;
using LabSync.Shared.Entites;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace LabSync.Frontend.Pages.Muestras;

public partial class MuestrasIndex
{
    private bool dense = true;
    private bool hover = true;
    private bool striped = false;
    private bool bordered = false;
    private string searchString1 = "";

    private MudTable<Muestra> _tablamuestras = new();
    private Muestra? selectedItem1 = null;
    private HashSet<Muestra> selectedItems = new HashSet<Muestra>();
    private IEnumerable<Muestra> ListaMuestras = new List<Muestra>();
    private bool isLoading = false;

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
        isLoading = true;

        var responseHppt = await Repository.GetAsync<List<Muestra>>("api/Muestras");

        if (responseHppt.Error)
        {
            var message = await responseHppt.GetErrorMessageAsync();
            Snackbar.Add(Localizer[message!], Severity.Error);
        }
        else
        {
            ListaMuestras = responseHppt.Response ?? new List<Muestra>(); // Si la respuesta es nula, asigna una lista vacía
        }

        isLoading = false; // Termina la carga
    }

    private bool FilterFunc1(Muestra muestra) => FilterFunc(muestra, searchString1);

    private bool FilterFunc(Muestra muestra, string searchString)
    {
        if (string.IsNullOrWhiteSpace(searchString))
            return true;

        return muestra.NroAdmision!.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
       muestra.Paciente!.Nombres!.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
       muestra.Paciente!.Apellidos!.Contains(searchString, StringComparison.OrdinalIgnoreCase);
    }
}