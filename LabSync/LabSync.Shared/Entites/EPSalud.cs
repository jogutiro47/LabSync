using LabSync.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LabSync.Shared.Entites
{
    public class EPSalud
    {
        public int EPSSaludId { get; set; }  // Identificador único para la EPS

        [Required(ErrorMessage = "El nombre de la EPS es obligatorio.")]
        [StringLength(200, ErrorMessage = "El nombre no puede exceder los 200 caracteres.")]
        public string? NombreEPS { get; set; }  // Nombre de la EPS

        [StringLength(200, ErrorMessage = "El nombre no puede exceder los 200 caracteres.")]
        public string? AbreviaturaEPS { get; set; }  // Abreviatura EPS

        [StringLength(250, ErrorMessage = "La dirección no puede exceder los 250 caracteres.")]
        public string? DireccionEPS { get; set; }  // Dirección de la EPS

        [StringLength(15, ErrorMessage = "El teléfono no puede exceder los 15 caracteres.")]
        public string? TelefonoEPS { get; set; }  // Teléfono de contacto

        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        [StringLength(100, ErrorMessage = "El correo electrónico no puede exceder los 100 caracteres.")]
        public string? EmailEPS { get; set; }  // Correo electrónico de contacto

        [Required(ErrorMessage = "El tipo de EPS es obligatorio.")]
        public EPSClaseType TipoEPS { get; set; }

        [StringLength(250, ErrorMessage = "La página web no puede exceder los 250 caracteres.")]
        public string? PaginaWeb { get; set; }  // Página web (opcional)

        public DateTime? FechaRegistro { get; set; }  // Fecha de registro de la EPS

        // Relación con la entidad Paciente
        public ICollection<Paciente>? Pacientes { get; set; }  // Una EPS puede tener muchos pacientes
    }
}