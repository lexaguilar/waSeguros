using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace waSeguros.Models
{
    public partial class SegurosContext : DbContext
    {
        public SegurosContext()
        {
        }

        public SegurosContext(DbContextOptions<SegurosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CatCobertura> CatCoberturas { get; set; }
        public virtual DbSet<CatContador> CatContadors { get; set; }
        public virtual DbSet<CatDepartamento> CatDepartamentos { get; set; }
        public virtual DbSet<CatMonedum> CatMoneda { get; set; }
        public virtual DbSet<CatMunicipio> CatMunicipios { get; set; }
        public virtual DbSet<CatPai> CatPais { get; set; }
        public virtual DbSet<CatRamo> CatRamos { get; set; }
        public virtual DbSet<CatTipoCambio> CatTipoCambios { get; set; }
        public virtual DbSet<CatTipoIdentificacion> CatTipoIdentificacions { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<CoberturasPoliza> CoberturasPolizas { get; set; }
        public virtual DbSet<CuotasPoliza> CuotasPolizas { get; set; }
        public virtual DbSet<Poliza> Polizas { get; set; }
        public virtual DbSet<ViewDepartamentoMunicipio> ViewDepartamentoMunicipios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<CatCobertura>(entity =>
            {
                entity.HasKey(e => new { e.CodRamo, e.CodCobertura });

                entity.ToTable("CatCobertura");

                entity.Property(e => e.Isuma)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.NombreCobertura)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .UseCollation("Modern_Spanish_CI_AI");

                entity.HasOne(d => d.CodRamoNavigation)
                    .WithMany(p => p.CatCoberturas)
                    .HasForeignKey(d => d.CodRamo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CatCobertura_CatRamos");
            });

            modelBuilder.Entity<CatContador>(entity =>
            {
                entity.HasKey(e => new { e.Parametro, e.NumContador })
                    .HasName("PK_CatContadores");

                entity.ToTable("CatContador");

                entity.Property(e => e.Parametro)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NumContador).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<CatDepartamento>(entity =>
            {
                entity.HasKey(e => new { e.CodPais, e.CodDepartamento });

                entity.ToTable("CatDepartamento");

                entity.Property(e => e.Iestado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("iestado")
                    .IsFixedLength(true)
                    .UseCollation("Modern_Spanish_CI_AI");

                entity.Property(e => e.Isum)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Xdepartamento)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("xdepartamento")
                    .UseCollation("Modern_Spanish_CI_AI");

                entity.HasOne(d => d.CodPaisNavigation)
                    .WithMany(p => p.CatDepartamentos)
                    .HasForeignKey(d => d.CodPais)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CatDepartamento_CatPais");
            });

            modelBuilder.Entity<CatMonedum>(entity =>
            {
                entity.HasKey(e => e.CodMoneda)
                    .HasName("PK_CatMoneda_1");

                entity.Property(e => e.CodMoneda).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Moneda)
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CatMunicipio>(entity =>
            {
                entity.HasKey(e => new { e.CodPais, e.CodDepartamento, e.CodMunicipio });

                entity.ToTable("CatMunicipio");

                entity.Property(e => e.Iestado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("iestado")
                    .IsFixedLength(true)
                    .UseCollation("Modern_Spanish_CI_AI");

                entity.Property(e => e.Xmunicipio)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("xmunicipio")
                    .UseCollation("Modern_Spanish_CI_AI");

                entity.HasOne(d => d.Cod)
                    .WithMany(p => p.CatMunicipios)
                    .HasForeignKey(d => new { d.CodPais, d.CodDepartamento })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CatMunicipio_CatDepartamento");
            });

            modelBuilder.Entity<CatPai>(entity =>
            {
                entity.HasKey(e => e.CodPais);

                entity.Property(e => e.CodPais).ValueGeneratedNever();

                entity.Property(e => e.Iestado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("iestado")
                    .IsFixedLength(true)
                    .UseCollation("Modern_Spanish_CI_AI");

                entity.Property(e => e.Xpais)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("xpais")
                    .UseCollation("Modern_Spanish_CI_AI");
            });

            modelBuilder.Entity<CatRamo>(entity =>
            {
                entity.HasKey(e => e.CodRamo);

                entity.Property(e => e.CodRamo).ValueGeneratedNever();

                entity.Property(e => e.Abreviatura)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Xramo)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("xramo")
                    .UseCollation("Modern_Spanish_CI_AI");
            });

            modelBuilder.Entity<CatTipoCambio>(entity =>
            {
                entity.HasKey(e => e.Fecha);

                entity.ToTable("CatTipoCambio");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.TipoCambio).HasColumnType("numeric(8, 4)");
            });

            modelBuilder.Entity<CatTipoIdentificacion>(entity =>
            {
                entity.HasKey(e => e.CodTipoIdentificacion);

                entity.ToTable("CatTipoIdentificacion");

                entity.Property(e => e.CodTipoIdentificacion)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.Property(e => e.IdCliente).ValueGeneratedNever();

                entity.Property(e => e.Celular)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CodTipoIdentificacion)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('V')")
                    .HasComment("V: Vigente , N: No Vigente");

                entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCliente)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodPaisNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.CodPais)
                    .HasConstraintName("FK_Clientes_CatPais1");

                entity.HasOne(d => d.CodTipoIdentificacionNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.CodTipoIdentificacion)
                    .HasConstraintName("FK_Clientes_CatTipoIdentificacion");

                entity.HasOne(d => d.Cod)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => new { d.CodPais, d.CodDepartamento })
                    .HasConstraintName("FK_Clientes_CatDepartamento");

                entity.HasOne(d => d.CodNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => new { d.CodPais, d.CodDepartamento, d.CodMunicipio })
                    .HasConstraintName("FK_Clientes_CatMunicipio");
            });

            modelBuilder.Entity<CoberturasPoliza>(entity =>
            {
                entity.HasKey(e => new { e.CodCobertura, e.IdRecibo })
                    .HasName("PK_CoberturasPoliza_1");

                entity.ToTable("CoberturasPoliza");

                entity.Property(e => e.Isuma)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MontoPrima).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.MontoSumaAsegurada).HasColumnType("numeric(18, 2)");

                entity.HasOne(d => d.IdReciboNavigation)
                    .WithMany(p => p.CoberturasPolizas)
                    .HasForeignKey(d => d.IdRecibo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CoberturasPoliza_Polizas");
            });

            modelBuilder.Entity<CuotasPoliza>(entity =>
            {
                entity.HasKey(e => e.IdCuotaPoliza)
                    .HasName("PK_CuotasPolizas");

                entity.ToTable("CuotasPoliza");

                entity.Property(e => e.FechaPago).HasColumnType("datetime");

                entity.Property(e => e.FechaVencimiento).HasColumnType("datetime");

                entity.Property(e => e.MontoCuota).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.MontoPagado).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Pagado)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdReciboNavigation)
                    .WithMany(p => p.CuotasPolizas)
                    .HasForeignKey(d => d.IdRecibo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CuotasPoliza_FacturaPoliza");
            });

            modelBuilder.Entity<Poliza>(entity =>
            {
                entity.HasKey(e => e.IdRecibo)
                    .HasName("PK_FacturaPoliza");

                entity.ToTable("Poliza");

                entity.Property(e => e.IdRecibo).ValueGeneratedNever();

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.FechaVenta).HasColumnType("datetime");

                entity.Property(e => e.MontoDerechoEmision).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.MontoImpuesto).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.MontoPagado).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.MontoPendiente).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.MontoTotal).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.NumeroPoliza)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PDerechoEmision)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("pDerechoEmision");

                entity.Property(e => e.PImpuesto)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("pImpuesto");

                entity.Property(e => e.TotalPrima).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.TotalSumaAsegurada).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.VigenciaDesde).HasColumnType("datetime");

                entity.Property(e => e.VigenciaHasta).HasColumnType("datetime");

                entity.HasOne(d => d.CodMonedaNavigation)
                    .WithMany(p => p.Polizas)
                    .HasForeignKey(d => d.CodMoneda)
                    .HasConstraintName("FK_Polizas_CatMoneda");

                entity.HasOne(d => d.CodRamoNavigation)
                    .WithMany(p => p.Polizas)
                    .HasForeignKey(d => d.CodRamo)
                    .HasConstraintName("FK_FacturaPoliza_CatRamos");

                entity.HasOne(d => d.IdContrantanteNavigation)
                    .WithMany(p => p.Polizas)
                    .HasForeignKey(d => d.IdContrantante)
                    .HasConstraintName("FK_FacturaPoliza_Clientes");
            });

            modelBuilder.Entity<ViewDepartamentoMunicipio>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("view_DepartamentoMunicipios");

                entity.Property(e => e.Expr2)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .UseCollation("Modern_Spanish_CI_AI");

                entity.Property(e => e.Expr5)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true)
                    .UseCollation("Modern_Spanish_CI_AI");

                entity.Property(e => e.Iestado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("iestado")
                    .IsFixedLength(true)
                    .UseCollation("Modern_Spanish_CI_AI");

                entity.Property(e => e.Xdepartamento)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("xdepartamento")
                    .UseCollation("Modern_Spanish_CI_AI");

                entity.Property(e => e.Xmunicipio)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("xmunicipio")
                    .UseCollation("Modern_Spanish_CI_AI");

                entity.Property(e => e.Xpais)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("xpais")
                    .UseCollation("Modern_Spanish_CI_AI");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
