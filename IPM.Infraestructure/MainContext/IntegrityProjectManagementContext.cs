using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace IPM.Infraestructure.MainContext;

public partial class IntegrityProjectManagementContext : DbContext
{
    public IntegrityProjectManagementContext()
    {
    }

    public IntegrityProjectManagementContext(DbContextOptions<IntegrityProjectManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Catalogo> Catalogos { get; set; }

    public virtual DbSet<CatalogoDetalle> CatalogoDetalles { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<Lider> Liders { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Proyecto> Proyectos { get; set; }

    public virtual DbSet<ProyectoDetalle> ProyectoDetalles { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolesPermiso> RolesPermisos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=192.168.100.67;Database=IntegrityProjectManagement;User=timereport;Password=P@ssw0rd01; ; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Catalogo>(entity =>
        {
            entity.HasKey(e => e.IdCatalogo).HasName("PK__Catalogo__C615E0E8B4977D70");

            entity.ToTable("Catalogo");

            entity.Property(e => e.IdCatalogo).HasColumnName("idCatalogo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaModificacion");
            entity.Property(e => e.Nemonico)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nemonico");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuarioCreacion");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuarioModificacion");
        });

        modelBuilder.Entity<CatalogoDetalle>(entity =>
        {
            entity.HasKey(e => e.IdCatalogoDetalle).HasName("PK__Catalogo__3DD1E49026405A80");

            entity.ToTable("CatalogoDetalle");

            entity.Property(e => e.IdCatalogoDetalle).HasColumnName("idCatalogoDetalle");
            entity.Property(e => e.Cargo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cargo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaModificacion");
            entity.Property(e => e.Genero)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("genero");
            entity.Property(e => e.IdCatalogo).HasColumnName("idCatalogo");
            entity.Property(e => e.Nemonico)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nemonico");
            entity.Property(e => e.TipoIdentificacion)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tipoIdentificacion");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuarioCreacion");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuarioModificacion");

            entity.HasOne(d => d.IdCatalogoNavigation).WithMany(p => p.CatalogoDetalles)
                .HasForeignKey(d => d.IdCatalogo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CatalogoD__idCat__52593CB8");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Cliente__885457EE538DE97D");

            entity.ToTable("Cliente");

            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.Celular)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("celular");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correoElectronico");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaModificacion");
            entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");
            entity.Property(e => e.NombreComercial)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreComercial");
            entity.Property(e => e.NumeroIdentificacion)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("numeroIdentificacion");
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("razonSocial");
            entity.Property(e => e.TipoIdentificacion).HasColumnName("tipoIdentificacion");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuarioCreacion");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuarioModificacion");

            entity.HasOne(d => d.EstadoNavigation).WithMany(p => p.ClienteEstadoNavigations)
                .HasForeignKey(d => d.Estado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cliente_Estado");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdEmpresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cliente__idEmpre__5812160E");

            entity.HasOne(d => d.TipoIdentificacionNavigation).WithMany(p => p.ClienteTipoIdentificacionNavigations)
                .HasForeignKey(d => d.TipoIdentificacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cliente_tipoIdentificacion");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.IdEmpresa).HasName("PK__Empresa__5EF4033E6976A869");

            entity.ToTable("Empresa");

            entity.Property(e => e.Celular)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("celular");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaModificacion");
            entity.Property(e => e.NombreComercial)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreComercial");
            entity.Property(e => e.NumeroRuc)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("numeroRuc");
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("razonSocial");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuarioCreacion");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuarioModificacion");

            entity.HasOne(d => d.EstadoNavigation).WithMany(p => p.Empresas)
                .HasForeignKey(d => d.Estado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empresa_Estado");
        });

        modelBuilder.Entity<Lider>(entity =>
        {
            entity.HasKey(e => e.IdLider).HasName("PK__Lider__4FAD779B0123F736");

            entity.ToTable("Lider");

            entity.Property(e => e.IdLider).HasColumnName("idLider");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaModificacion");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdPersona).HasColumnName("idPersona");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuarioCreacion");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuarioModificacion");

            entity.HasOne(d => d.EstadoNavigation).WithMany(p => p.Liders)
                .HasForeignKey(d => d.Estado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lider_Estado");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Liders)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Lider__idCliente__5CD6CB2B");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.IdPersona).HasName("PK__Persona__A4788141B1CB1C28");

            entity.ToTable("Persona");

            entity.Property(e => e.IdPersona).HasColumnName("idPersona");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.Cargo).HasColumnName("cargo");
            entity.Property(e => e.Celular)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("celular");
            entity.Property(e => e.DireccionDomicilio)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("direccionDomicilio");
            entity.Property(e => e.EmailCorporativo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("emailCorporativo");
            entity.Property(e => e.EmailPersonal)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("emailPersonal");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaModificacion");
            entity.Property(e => e.Genero).HasColumnName("genero");
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombres");
            entity.Property(e => e.NumeroIdentificacion)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("numeroIdentificacion");
            entity.Property(e => e.TipoIdentificacion).HasColumnName("tipoIdentificacion");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuarioCreacion");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuarioModificacion");

            entity.HasOne(d => d.CargoNavigation).WithMany(p => p.PersonaCargoNavigations)
                .HasForeignKey(d => d.Cargo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Persona_cargo");

            entity.HasOne(d => d.EstadoNavigation).WithMany(p => p.PersonaEstadoNavigations)
                .HasForeignKey(d => d.Estado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Persona_Estado");

            entity.HasOne(d => d.GeneroNavigation).WithMany(p => p.PersonaGeneroNavigations)
                .HasForeignKey(d => d.Genero)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Persona_genero");

            entity.HasOne(d => d.TipoIdentificacionNavigation).WithMany(p => p.PersonaTipoIdentificacionNavigations)
                .HasForeignKey(d => d.TipoIdentificacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Persona_tipoIdentificacion");
        });

        modelBuilder.Entity<Proyecto>(entity =>
        {
            entity.HasKey(e => e.IdProyecto).HasName("PK__Proyecto__D0AF4CB42591483C");

            entity.ToTable("Proyecto");

            entity.Property(e => e.IdProyecto).HasColumnName("idProyecto");
            entity.Property(e => e.CodigoProyecto)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("codigoProyecto");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.FechaFin)
                .HasColumnType("datetime")
                .HasColumnName("fechaFin");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("datetime")
                .HasColumnName("fechaInicio");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaModificacion");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdLiderPrincipal).HasColumnName("idLiderPrincipal");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuarioCreacion");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuarioModificacion");

            entity.HasOne(d => d.EstadoNavigation).WithMany(p => p.Proyectos)
                .HasForeignKey(d => d.Estado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Proyecto_Estado");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Proyectos)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Proyecto__idClie__6B24EA82");

            entity.HasOne(d => d.IdLiderPrincipalNavigation).WithMany(p => p.Proyectos)
                .HasForeignKey(d => d.IdLiderPrincipal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Proyecto__idLide__6A30C649");
        });

        modelBuilder.Entity<ProyectoDetalle>(entity =>
        {
            entity.HasKey(e => e.IdProyectoDetalle).HasName("PK__Proyecto__3A9B7D26FD244C83");

            entity.ToTable("Proyecto_Detalle");

            entity.Property(e => e.IdProyectoDetalle).HasColumnName("idProyectoDetalle");
            entity.Property(e => e.CargoRecurso).HasColumnName("cargoRecurso");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaModificacion");
            entity.Property(e => e.IdLider).HasColumnName("idLider");
            entity.Property(e => e.IdProyecto).HasColumnName("idProyecto");
            entity.Property(e => e.IdRecurso).HasColumnName("idRecurso");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuarioCreacion");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuarioModificacion");

            entity.HasOne(d => d.CargoRecursoNavigation).WithMany(p => p.ProyectoDetalleCargoRecursoNavigations)
                .HasForeignKey(d => d.CargoRecurso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Proyecto_Detalle_Cargo");

            entity.HasOne(d => d.EstadoNavigation).WithMany(p => p.ProyectoDetalleEstadoNavigations)
                .HasForeignKey(d => d.Estado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Proyecto_Detalle_Estado");

            entity.HasOne(d => d.IdLiderNavigation).WithMany(p => p.ProyectoDetalles)
                .HasForeignKey(d => d.IdLider)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Proyecto___idLid__6EF57B66");

            entity.HasOne(d => d.IdProyectoNavigation).WithMany(p => p.ProyectoDetalles)
                .HasForeignKey(d => d.IdProyecto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Proyecto___idPro__6FE99F9F");

            entity.HasOne(d => d.IdRecursoNavigation).WithMany(p => p.ProyectoDetalles)
                .HasForeignKey(d => d.IdRecurso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Proyecto___idRec__70DDC3D8");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RolId);

            entity.HasMany(d => d.UsuariosUsuarios).WithMany(p => p.RolesRols)
                .UsingEntity<Dictionary<string, object>>(
                    "RolUsuario",
                    r => r.HasOne<Usuario>().WithMany().HasForeignKey("UsuariosUsuarioId"),
                    l => l.HasOne<Role>().WithMany().HasForeignKey("RolesRolId"),
                    j =>
                    {
                        j.HasKey("RolesRolId", "UsuariosUsuarioId");
                        j.ToTable("RolUsuarios");
                        j.HasIndex(new[] { "UsuariosUsuarioId" }, "IX_RolUsuarios_UsuariosUsuarioId");
                    });
        });

        modelBuilder.Entity<RolesPermiso>(entity =>
        {
            entity.HasKey(e => new { e.RolId, e.PermisoId });

            entity.HasIndex(e => e.PermisoId, "IX_RolesPermisos_PermisoId");

            entity.HasOne(d => d.Permiso).WithMany(p => p.RolesPermisos).HasForeignKey(d => d.PermisoId);

            entity.HasOne(d => d.Rol).WithMany(p => p.RolesPermisos).HasForeignKey(d => d.RolId);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.Property(e => e.ConfirmarClave).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
