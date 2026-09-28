using Microsoft.EntityFrameworkCore;
using PanchoApp.Domain.Entities;

namespace PanchoApp.Infrastructure.Data;

public class PanchoDbContext : DbContext
{
    public PanchoDbContext(DbContextOptions<PanchoDbContext> options)
        : base(options)
    {
    }

    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<Mascota> Mascotas => Set<Mascota>();
    public DbSet<Especie> Especies => Set<Especie>();
    public DbSet<Raza> Razas => Set<Raza>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.ToTable("Clientes");

            entity.HasKey(c => c.Id);

            entity.Property(c => c.Nombre)
                .IsRequired()
                .HasMaxLength(120);

            entity.Property(c => c.Telefono)
                .IsRequired()
                .HasMaxLength(30);

            entity.Property(c => c.Correo)
                .HasMaxLength(150);

            entity.Property(c => c.Direccion)
                .HasMaxLength(250);

            entity.Property(c => c.Observaciones)
                .HasMaxLength(500);

            entity.HasMany(c => c.Mascotas)
                .WithOne(m => m.Cliente)
                .HasForeignKey(m => m.ClienteID)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Especie>(entity =>
        {
            entity.ToTable("Especies");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(80);

            entity.Property(e => e.Descripcion)
                .HasMaxLength(250);

            entity.HasMany(e => e.Razas)
                .WithOne(r => r.Especie)
                .HasForeignKey(r => r.EspecieId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(e => e.Mascotas)
                .WithOne(m => m.Especie)
                .HasForeignKey(m => m.EspecieId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Raza>(entity =>
        {
            entity.ToTable("Razas");

            entity.HasKey(r => r.Id);

            entity.Property(r => r.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(r => r.Descripcion)
                .HasMaxLength(250);

            entity.HasMany(r => r.Mascotas)
                .WithOne(m => m.Raza)
                .HasForeignKey(m => m.RazaId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<Mascota>(entity =>
        {
            entity.ToTable("Mascotas");

            entity.HasKey(m => m.Id);

            entity.Property(m => m.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(m => m.Sexo)
                .IsRequired()
                .HasMaxLength(20);

            entity.Property(m => m.Color)
                .HasMaxLength(80);

            entity.Property(m => m.Peso)
                .HasColumnType("decimal(10,2)");

            entity.Property(m => m.FotoRuta)
                .HasMaxLength(300);

            entity.Property(m => m.NivelAgresividad)
                .HasMaxLength(50);

            entity.Property(m => m.Microchip)
                .HasMaxLength(100);

            entity.Property(m => m.TipoAlimentacion)
                .HasMaxLength(150);

            entity.Property(m => m.Alergias)
                .HasMaxLength(500);

            entity.Property(m => m.Enfermedades)
                .HasMaxLength(500);

            entity.Property(m => m.MedicamentosActuales)
                .HasMaxLength(500);

            entity.Property(m => m.Observaciones)
                .HasMaxLength(700);
        });
    }
}