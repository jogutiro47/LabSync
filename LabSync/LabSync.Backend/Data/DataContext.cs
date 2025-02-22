using LabSync.Shared.Entites;
using Microsoft.EntityFrameworkCore;

namespace LabSync.Backend.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Country> Countries { get; set; }
    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<EPSalud> EPSaluds { get; set; }
    public DbSet<Muestra> Muestras { get; set; }
    public DbSet<ResultadoMuestra> ResultadoMuestras { get; set; }
    public DbSet<Medico> Medicos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Country>().HasIndex(x => x.Name).IsUnique();
        modelBuilder.Entity<Paciente>().HasKey(p => p.PacienteId);
        modelBuilder.Entity<EPSalud>().HasKey(p => p.EPSSaludId);
        modelBuilder.Entity<Muestra>().HasKey(p => p.MuestraId);
        modelBuilder.Entity<ResultadoMuestra>().HasKey(p => p.ResultadoId);
        modelBuilder.Entity<Medico>().HasKey(p => p.MedicoId);

        DisableCascadingDelete(modelBuilder);
    }

    private void DisableCascadingDelete(ModelBuilder modelBuilder)
    {
        var relationships = modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys());
        foreach (var relationship in relationships)
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}