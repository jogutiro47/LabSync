﻿using LabSync.Shared.Entites;
using LabSync.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSync.Shared.DTOs;

public class PacienteDTO
{
    public TipoDocumentoType? TipoDocumento { get; set; }

    [Required(ErrorMessage = "El número de identidad es obligatorio.")]
    [StringLength(20, ErrorMessage = "El número de identidad no puede exceder los 20 caracteres.")]
    public string? NumeroIdentidad { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(200, ErrorMessage = "El nombre no puede exceder los 200 caracteres.")]
    public string? Nombres { get; set; }

    [Required(ErrorMessage = "El apellido es obligatorio.")]
    [StringLength(200, ErrorMessage = "El apellido no puede exceder los 200 caracteres.")]
    public string? Apellidos { get; set; }

    [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
    [DataType(DataType.Date)]
    public DateTime? FechaNacimiento { get; set; }

    [StringLength(250, ErrorMessage = "La dirección no puede exceder los 250 caracteres.")]
    public string? Direccion { get; set; }

    [StringLength(15, ErrorMessage = "El teléfono no puede exceder los 15 caracteres.")]
    public string? Telefono { get; set; }

    [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
    [StringLength(100, ErrorMessage = "El correo electrónico no puede exceder los 100 caracteres.")]
    public string? CorreoElectronico { get; set; }

    public GrupoSanguineoType? GrupoSanguineo { get; set; }

    public SexoType? Sexo { get; set; }

    public EstadoCivilType? EstadoCivil { get; set; }

    [StringLength(500, ErrorMessage = "Las alergias no pueden exceder los 500 caracteres.")]
    public string? Alergias { get; set; }

    public int? EPSSaludId { get; set; }

    public DateTime? FechaRegistro { get; set; }

    /*

    [Required(ErrorMessage = "El sexo es obligatorio.")]
    public string? FormatoEdad { get; set; }

    public string? UserName { get; set; }

    */
}