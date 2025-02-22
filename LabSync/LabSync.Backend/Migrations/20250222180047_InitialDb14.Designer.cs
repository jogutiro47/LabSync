﻿// <auto-generated />
using System;
using LabSync.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LabSync.Backend.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20250222180047_InitialDb14")]
    partial class InitialDb14
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("LabSync.Shared.Entites.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("LabSync.Shared.Entites.EPSalud", b =>
                {
                    b.Property<int>("EPSSaludId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("EPSSaludId"));

                    b.Property<string>("AbreviaturaEPS")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("DireccionEPS")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("EmailEPS")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("FechaRegistro")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NombreEPS")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("PaginaWeb")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("TelefonoEPS")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<int>("TipoEPS")
                        .HasColumnType("int");

                    b.HasKey("EPSSaludId");

                    b.ToTable("EPSaluds");
                });

            modelBuilder.Entity("LabSync.Shared.Entites.Medico", b =>
                {
                    b.Property<int>("MedicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("MedicoId"));

                    b.Property<string>("Apellidos")
                        .HasColumnType("longtext");

                    b.Property<string>("Identificacion")
                        .HasColumnType("longtext");

                    b.Property<string>("Nombres")
                        .HasColumnType("longtext");

                    b.Property<string>("NroTarjetaProfesional")
                        .HasColumnType("longtext");

                    b.Property<int?>("OrigenMedico")
                        .HasColumnType("int");

                    b.Property<string>("Profesion")
                        .HasColumnType("longtext");

                    b.Property<string>("RutaFirma")
                        .HasColumnType("longtext");

                    b.HasKey("MedicoId");

                    b.ToTable("Medicos");
                });

            modelBuilder.Entity("LabSync.Shared.Entites.Muestra", b =>
                {
                    b.Property<int>("MuestraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("MuestraId"));

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fechaingreso")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("IdEntidadSolicita")
                        .HasColumnType("longtext");

                    b.Property<string>("IdMedicoOrigen")
                        .HasColumnType("longtext");

                    b.Property<string>("MaterialEnviado")
                        .HasColumnType("longtext");

                    b.Property<int?>("PacienteId")
                        .HasColumnType("int");

                    b.Property<string>("Protocolo")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Reporte")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("nroAdmision")
                        .HasColumnType("longtext");

                    b.HasKey("MuestraId");

                    b.HasIndex("PacienteId");

                    b.ToTable("Muestras");
                });

            modelBuilder.Entity("LabSync.Shared.Entites.Paciente", b =>
                {
                    b.Property<int>("PacienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("PacienteId"));

                    b.Property<string>("Alergias")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("CorreoElectronico")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Direccion")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<int?>("EPSSaludId")
                        .HasColumnType("int");

                    b.Property<int?>("EstadoCivil")
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaNacimiento")
                        .IsRequired()
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("FechaRegistro")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("FormatoEdad")
                        .HasColumnType("int");

                    b.Property<int?>("GrupoSanguineo")
                        .HasColumnType("int");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("NumeroIdentidad")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<int?>("Sexo")
                        .HasColumnType("int");

                    b.Property<string>("Telefono")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<int?>("TipoDocumento")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.HasKey("PacienteId");

                    b.HasIndex("EPSSaludId");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("LabSync.Shared.Entites.ResultadoMuestra", b =>
                {
                    b.Property<int>("ResultadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ResultadoId"));

                    b.Property<DateTime>("FechaRegistra")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("MedicoId")
                        .HasColumnType("int");

                    b.Property<int?>("MuestraId")
                        .HasColumnType("int");

                    b.Property<string>("ResultadoDiagnostico")
                        .HasColumnType("longtext");

                    b.Property<string>("ResultadoMacro")
                        .HasColumnType("longtext");

                    b.Property<string>("ResultadoMicro")
                        .HasColumnType("longtext");

                    b.HasKey("ResultadoId");

                    b.HasIndex("MedicoId");

                    b.HasIndex("MuestraId");

                    b.ToTable("ResultadoMuestras");
                });

            modelBuilder.Entity("LabSync.Shared.Entites.Muestra", b =>
                {
                    b.HasOne("LabSync.Shared.Entites.Paciente", "Paciente")
                        .WithMany("Muestras")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("LabSync.Shared.Entites.Paciente", b =>
                {
                    b.HasOne("LabSync.Shared.Entites.EPSalud", "EPSSalud")
                        .WithMany("Pacientes")
                        .HasForeignKey("EPSSaludId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("EPSSalud");
                });

            modelBuilder.Entity("LabSync.Shared.Entites.ResultadoMuestra", b =>
                {
                    b.HasOne("LabSync.Shared.Entites.Medico", "Medico")
                        .WithMany()
                        .HasForeignKey("MedicoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("LabSync.Shared.Entites.Muestra", "Muestra")
                        .WithMany("ResultadoMuestras")
                        .HasForeignKey("MuestraId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Medico");

                    b.Navigation("Muestra");
                });

            modelBuilder.Entity("LabSync.Shared.Entites.EPSalud", b =>
                {
                    b.Navigation("Pacientes");
                });

            modelBuilder.Entity("LabSync.Shared.Entites.Muestra", b =>
                {
                    b.Navigation("ResultadoMuestras");
                });

            modelBuilder.Entity("LabSync.Shared.Entites.Paciente", b =>
                {
                    b.Navigation("Muestras");
                });
#pragma warning restore 612, 618
        }
    }
}
