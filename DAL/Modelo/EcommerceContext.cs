using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.Modelo
{
    public partial class EcommerceContext : DbContext
    {
        public EcommerceContext()
        {
        }

        public EcommerceContext(DbContextOptions<EcommerceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CatDevolucionesPedido> CatDevolucionesPedidos { get; set; } = null!;
        public virtual DbSet<CatDistribuidore> CatDistribuidores { get; set; } = null!;
        public virtual DbSet<CatEstadoEnvio> CatEstadoEnvios { get; set; } = null!;
        public virtual DbSet<CatEstadoPago> CatEstadoPagos { get; set; } = null!;
        public virtual DbSet<CatProducto> CatProductos { get; set; } = null!;
        public virtual DbSet<CatProveedore> CatProveedores { get; set; } = null!;
        public virtual DbSet<TdhEstadoPedido> TdhEstadoPedidos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Pooling=true;Database=Ecommerce;UserId=postgres;Password=AlumnoCMI2;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatDevolucionesPedido>(entity =>
            {
                entity.HasKey(e => e.CodDevolucion)
                    .HasName("cat_devoluciones_pedidos_pkey");

                entity.ToTable("cat_devoluciones_pedidos", "dwh_ecommerce");

                entity.Property(e => e.CodDevolucion).HasColumnName("Cod_devolucion");

                entity.Property(e => e.DescDevolucion).HasColumnName("Desc_devolucion");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.MdDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("Md_date");

                entity.Property(e => e.MdUuid).HasColumnName("Md_uuid");
            });

            modelBuilder.Entity<CatDistribuidore>(entity =>
            {
                entity.HasKey(e => e.CodigoLinea)
                    .HasName("cat_distribuidores_pkey");

                entity.ToTable("cat_distribuidores", "dwh_ecommerce");

                entity.Property(e => e.CodigoLinea).HasColumnName("Codigo_linea");

                entity.Property(e => e.CodBarrio).HasColumnName("Cod_barrio");

                entity.Property(e => e.CodMunicipio).HasColumnName("Cod_municipio");

                entity.Property(e => e.CodProvincia).HasColumnName("Cod_provincia");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.MdDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("Md_date");

                entity.Property(e => e.MdUuid).HasColumnName("Md_uuid");
            });

            modelBuilder.Entity<CatEstadoEnvio>(entity =>
            {
                entity.HasKey(e => e.CodEstadoEnvio)
                    .HasName("cat_estado_envio_pkey");

                entity.ToTable("cat_estado_envio", "dwh_ecommerce");

                entity.Property(e => e.CodEstadoEnvio).HasColumnName("Cod_estado_envio");

                entity.Property(e => e.DescEnvio).HasColumnName("Desc_envio");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.MdDate).HasColumnName("Md_date");

                entity.Property(e => e.MdUuid).HasColumnName("Md_uuid");
            });

            modelBuilder.Entity<CatEstadoPago>(entity =>
            {
                entity.HasKey(e => e.CodEstadoPago)
                    .HasName("cat_estado_pago_pkey");

                entity.ToTable("cat_estado_pago", "dwh_ecommerce");

                entity.Property(e => e.CodEstadoPago).HasColumnName("Cod_estado_pago");

                entity.Property(e => e.DescEstadoPago).HasColumnName("Desc_estado_pago");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.MdDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("Md_date");

                entity.Property(e => e.MdUuid).HasColumnName("Md_uuid");
            });

            modelBuilder.Entity<CatProducto>(entity =>
            {
                entity.HasKey(e => e.CodProducto)
                    .HasName("cat_productos_pkey");

                entity.ToTable("cat_productos", "dwh_ecommerce");

                entity.Property(e => e.CodProducto).HasColumnName("Cod_producto");

                entity.Property(e => e.DescProducto).HasColumnName("Desc_producto");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.MdDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("Md_date");

                entity.Property(e => e.MdUuid).HasColumnName("Md_uuid");
            });

            modelBuilder.Entity<CatProveedore>(entity =>
            {
                entity.HasKey(e => e.CodProveedores)
                    .HasName("cat_proveedores_pkey");

                entity.ToTable("cat_proveedores", "dwh_ecommerce");

                entity.Property(e => e.CodProveedores).HasColumnName("Cod_proveedores");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.MdDate).HasColumnName("Md_date");

                entity.Property(e => e.MdUuid).HasColumnName("Md_uuid");
            });

            modelBuilder.Entity<TdhEstadoPedido>(entity =>
            {
                entity.ToTable("tdh_estado_pedidos", "dwh_ecommerce");

                entity.Property(e => e.CodDevolucion).HasColumnName("Cod_devolucion");

                entity.Property(e => e.CodEstadoEnvio).HasColumnName("Cod_estado_envio");

                entity.Property(e => e.CodEstadoPago).HasColumnName("Cod_estado_pago");

                entity.Property(e => e.CodProducto).HasColumnName("Cod_producto");

                entity.Property(e => e.CodProveedores).HasColumnName("Cod_proveedores");

                entity.Property(e => e.CodigoLinea).HasColumnName("Codigo_linea");

                entity.Property(e => e.MdDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("Md_date");

                entity.Property(e => e.MdUuid).HasColumnName("Md_uuid");

                entity.HasOne(d => d.CodDevolucionNavigation)
                    .WithMany(p => p.TdhEstadoPedidos)
                    .HasForeignKey(d => d.CodDevolucion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tdh_estado_pedidos_Cod_devolucion_fkey");

                entity.HasOne(d => d.CodEstadoEnvioNavigation)
                    .WithMany(p => p.TdhEstadoPedidos)
                    .HasForeignKey(d => d.CodEstadoEnvio)
                    .HasConstraintName("tdh_estado_pedidos_Cod_estado_envio_fkey");

                entity.HasOne(d => d.CodEstadoPagoNavigation)
                    .WithMany(p => p.TdhEstadoPedidos)
                    .HasForeignKey(d => d.CodEstadoPago)
                    .HasConstraintName("tdh_estado_pedidos_Cod_estado_pago_fkey");

                entity.HasOne(d => d.CodProductoNavigation)
                    .WithMany(p => p.TdhEstadoPedidos)
                    .HasForeignKey(d => d.CodProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tdh_estado_pedidos_Cod_producto_fkey");

                entity.HasOne(d => d.CodProveedoresNavigation)
                    .WithMany(p => p.TdhEstadoPedidos)
                    .HasForeignKey(d => d.CodProveedores)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tdh_estado_pedidos_Cod_proveedores_fkey");

                entity.HasOne(d => d.CodigoLineaNavigation)
                    .WithMany(p => p.TdhEstadoPedidos)
                    .HasForeignKey(d => d.CodigoLinea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tdh_estado_pedidos_Codigo_linea_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
