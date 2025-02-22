using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSync.Shared.Entites
{
    public class ResultadoMuestra
    {
        public int ResultadoId { get; set; }

        public int? MuestraId { get; set; }
        public Muestra? Muestra { get; set; }

        public string? ResultadoMacro { get; set; }
        public string? ResultadoMicro { get; set; }
        public string? ResultadoDiagnostico { get; set; }
        public DateTime FechaReporte { get; set; }

        public int? MedicoId { get; set; }
        public Medico? Medico { get; set; }
    }
}