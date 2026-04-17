using Microsoft.EntityFrameworkCore;
using ClinicalAttention.Domain.Entities;

namespace ClinicalAttention.Infrastructure.Persistence.Context;

public class AppDbContext : DbContext
{
    public DbSet<SolicitudAtencion> Solicitudes => Set<SolicitudAtencion>();
    public DbSet<Paciente> Pacientes => Set<Paciente>();
    public DbSet<Medico> Medicos => Set<Medico>();
    public DbSet<Receta> Recetas => Set<Receta>();
    public DbSet<Consulta> Consultas => Set<Consulta>();
    public DbSet<HistorialSolicitud> HistorialSolicitudes => Set<HistorialSolicitud>();

    public AppDbContext(DbContextOptions<AppDbContext> options) 
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<SolicitudAtencion>(entity =>
        {
            entity.ToTable("solicitudes");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PacienteId).HasColumnName("paciente_id");
            entity.Property(e => e.Especialidad).HasColumnName("especialidad");
            entity.Property(e => e.Motivo).HasColumnName("motivo");
            entity.Property(e => e.Prioridad).HasColumnName("prioridad");
            entity.Property(e => e.Estado).HasColumnName("estado").HasConversion<string>();
            entity.Property(e => e.FechaCreacion).HasColumnName("fecha_creacion");
            entity.Property(e => e.MedicoAsignadoId).HasColumnName("medico_asignado_id");

            // Relaciones (FK)
            entity.HasOne<Paciente>()
                  .WithMany()
                  .HasForeignKey(e => e.PacienteId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne<Medico>()
                  .WithMany()
                  .HasForeignKey(e => e.MedicoAsignadoId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.ToTable("pacientes");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
            entity.Property(e => e.Documento).HasColumnName("documento");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.Estado).HasColumnName("estado");
        });

        modelBuilder.Entity<Medico>(entity =>
        {
            entity.ToTable("medicos");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
            entity.Property(e => e.Especialidad).HasColumnName("especialidad");
            entity.Property(e => e.Disponible).HasColumnName("disponible");
            entity.Property(e => e.Estado).HasColumnName("estado");
        });

        modelBuilder.Entity<Receta>(entity =>
        {
            entity.ToTable("recetas");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ConsultaId).HasColumnName("consulta_id");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
        });

        modelBuilder.Entity<Consulta>(entity =>
        {
            entity.ToTable("consultas");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.SolicitudId).HasColumnName("solicitud_id");
            entity.Property(e => e.MedicoId).HasColumnName("medico_id");
            entity.Property(e => e.Diagnostico).HasColumnName("diagnostico");
            entity.Property(e => e.Tratamiento).HasColumnName("tratamiento");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
        });

        modelBuilder.Entity<HistorialSolicitud>(entity =>
        {
            entity.ToTable("historial_solicitudes");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).HasColumnName("id"); 

            entity.Property(e => e.SolicitudId).HasColumnName("solicitud_id");
            entity.Property(e => e.EstadoAnterior).HasColumnName("estado_anterior");
            entity.Property(e => e.EstadoNuevo).HasColumnName("estado_nuevo");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Observacion).HasColumnName("observacion");
        });

        base.OnModelCreating(modelBuilder);
    }



}