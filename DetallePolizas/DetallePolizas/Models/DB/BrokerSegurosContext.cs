using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DetallePolizas.Models.DB;

public partial class BrokerSegurosContext : DbContext
{
    public BrokerSegurosContext()
    {
    }

    public BrokerSegurosContext(DbContextOptions<BrokerSegurosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cobertura> Coberturas { get; set; }

    public virtual DbSet<CoberturasPoliza> CoberturasPolizas { get; set; }

    public virtual DbSet<Poliza> Polizas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-ON04E4DQ\\SQLEXPRESS; Database=BROKER_SEGUROS; Trusted_Connection=True; Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cobertura>(entity =>
        {
            entity.HasKey(e => e.IdCobertura).HasName("PK__COBERTUR__E64144A00845500C");

            entity.ToTable("COBERTURA");

            entity.Property(e => e.IdCobertura).HasColumnName("id_cobertura");
            entity.Property(e => e.CodCobertura)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("cod_cobertura");
            entity.Property(e => e.NomCobertura)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nom_cobertura");
        });

        modelBuilder.Entity<CoberturasPoliza>(entity =>
        {
            entity.HasKey(e => e.IdCoberturasPoliza).HasName("PK__COBERTUR__C590994F7255FEA2");

            entity.ToTable("COBERTURAS_POLIZA");

            entity.Property(e => e.IdCoberturasPoliza).HasColumnName("id_coberturas_poliza");
            entity.Property(e => e.IdCobertura).HasColumnName("id_cobertura");
            entity.Property(e => e.IdPoliza).HasColumnName("id_poliza");

            entity.HasOne(d => d.IdPolizaNavigation).WithMany(p => p.CoberturasPolizas)
                .HasForeignKey(d => d.IdPoliza)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__COBERTURA__id_po__286302EC");
        });

        modelBuilder.Entity<Poliza>(entity =>
        {
            entity.HasKey(e => e.IdPoliza).HasName("PK__POLIZA__75524905EEDBE6E9");

            entity.ToTable("POLIZA");

            entity.Property(e => e.IdPoliza).HasColumnName("id_poliza");
            entity.Property(e => e.MontoAsegurado).HasColumnName("monto_asegurado");
            entity.Property(e => e.NomPoliza)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nom_poliza");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
