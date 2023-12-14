using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace aaclnezExamenNet.Models;

public partial class ExaDosContext : DbContext
{
    public ExaDosContext()
    {
    }

    public ExaDosContext(DbContextOptions<ExaDosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<RelVajillaReserva> RelVajillaReservas { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<Vajilla> Vajillas { get; set; }
    public object Alumnos { get; internal set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=PostgresConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RelVajillaReserva>(entity =>
        {
            entity.HasKey(e => e.IdRelVajillaReserva).HasName("rel_vajilla_reserva_pkey");

            entity.ToTable("rel_vajilla_reserva", "esqexados");

            entity.Property(e => e.IdRelVajillaReserva).HasColumnName("id_rel_vajilla_reserva");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.ReservaIdReserva).HasColumnName("reserva_id_reserva");
            entity.Property(e => e.VajillaIdVajilla).HasColumnName("vajilla_id_vajilla");

            entity.HasOne(d => d.ReservaIdReservaNavigation).WithMany(p => p.RelVajillaReservas)
                .HasForeignKey(d => d.ReservaIdReserva)
                .HasConstraintName("fk_rel_vajilla_reserva_reserva_id_reserva");

            entity.HasOne(d => d.VajillaIdVajillaNavigation).WithMany(p => p.RelVajillaReservas)
                .HasForeignKey(d => d.VajillaIdVajilla)
                .HasConstraintName("fk_rel_vajilla_reserva_vajilla_id_vajilla");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.IdReserva).HasName("reserva_pkey");

            entity.ToTable("reserva", "esqexados");

            entity.Property(e => e.IdReserva).HasColumnName("id_reserva");
            entity.Property(e => e.FechaReserva)
                .HasMaxLength(255)
                .HasColumnName("fecha_reserva");
        });

        modelBuilder.Entity<Vajilla>(entity =>
        {
            entity.HasKey(e => e.IdVajilla).HasName("vajillas_pkey");

            entity.ToTable("vajillas", "esqexados");

            entity.Property(e => e.IdVajilla).HasColumnName("id_vajilla");
            entity.Property(e => e.CatidadElemento).HasColumnName("catidad_elemento");
            entity.Property(e => e.CodigoElemento)
                .HasMaxLength(255)
                .HasColumnName("codigo_elemento");
            entity.Property(e => e.DescripcionElemento)
                .HasMaxLength(255)
                .HasColumnName("descripcion_elemento");
            entity.Property(e => e.NombreElemento)
                .HasMaxLength(255)
                .HasColumnName("nombre_elemento");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
