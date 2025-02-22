using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSync.Shared.Entites;

public class Medico
{
    public int MedicoId { get; set; }
    public string? Identificacion { get; set; }
    public string? Nombres { get; set; }
    public string? Apellidos { get; set; }
    public string? Profesion { get; set; }
    public string? NroTarjetaProfesional { get; set; }
    public string? RutaFirma { get; set; }
    public int? OrigenMedico { get; set; } // Local o Foraneo
}