using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Revifast.Models
{
    public partial class DbRevifastContext : DbContext
    {
        public DbRevifastContext()
        {
        }

        public DbRevifastContext(DbContextOptions<DbRevifastContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Reserva> Reserva { get; set; }
        public virtual DbSet<Vehiculo> Vehiculo { get; set; }
        public virtual DbSet<Conductor> Conductor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=DbRevifastFASGugz;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.Property(e => e.Direccion)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ruc)
                    .HasColumnName("RUC")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha_y_hora");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.Reserva)
                    .HasForeignKey(d => d.EmpresaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reserva_Empresa");

                entity.HasOne(d => d.Vehiculo)
                    .WithMany(p => p.Reserva)
                    .HasForeignKey(d => d.VehiculoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reserva_Vehiculo")
                    .OnDelete(DeleteBehavior.ClientCascade);
                //REVISAR AQUI^^
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.Property(e => e.Categoria)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Modelo)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Placa)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Conductor)
                    .WithMany(p => p.Vehiculo)
                    .HasForeignKey(d => d.ConductorId)
                    .HasConstraintName("FK_Vehiculo_Conductor");
            });

            modelBuilder.Entity<Conductor>(entity =>
            {
                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Celular)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Dni)
                    .HasColumnName("DNI")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario).HasMaxLength(256);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
