using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APIGAMES.Models
{
    public partial class DBGAMESContext : DbContext
    {
        public DBGAMESContext()
        {
        }

        public DBGAMESContext(DbContextOptions<DBGAMESContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Videojuego> Videojuegos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__PRODUCTO__09889210F1A72897");

                entity.ToTable("PRODUCTO");

                entity.Property(e => e.Genero)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Trailer)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Oplataforma)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdPlataforma)
                    .HasConstraintName("FK_Idplataforma");
            });

            modelBuilder.Entity<Videojuego>(entity =>
            {
                entity.HasKey(e => e.Idplataforma)
                    .HasName("PK__VIDEOJUE__D0E4A85DD213DAB7");

                entity.ToTable("VIDEOJUEGOS");

                entity.Property(e => e.Plataforma)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
