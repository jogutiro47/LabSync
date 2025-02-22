using LabSync.Shared.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSync.Shared.DTOs
{
    public class MuestraDTO
    {
        public int MuestraId { get; set; }
        public int? PacienteId { get; set; }
        public DateTime Fechaingreso { get; set; }
        public string? MaterialEnviado { get; set; }
        public string? Protocolo { get; set; }
        public string? IdMedicoOrigen { get; set; }
        public string? NroAdmision { get; set; }
        public string? IdEntidadSolicita { get; set; }
        public int EstadoId { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}