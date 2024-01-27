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

    public virtual DbSet<ActividadDiariaTimeReport> ActividadDiariaTimeReports { get; set; }

    public virtual DbSet<Articulo> Articulos { get; set; }

    public virtual DbSet<AsignacionArticulo> AsignacionArticulos { get; set; }

    public virtual DbSet<BajaEquipo> BajaEquipos { get; set; }

    public virtual DbSet<Catalogo> Catalogos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<CursosTomado> CursosTomados { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<Equipo> Equipos { get; set; }

    public virtual DbSet<EquipoPersonaAsignacion> EquipoPersonaAsignacions { get; set; }

    public virtual DbSet<FeedbackProgresoHistorico> FeedbackProgresoHistoricos { get; set; }

    public virtual DbSet<HistorialLaboral> HistorialLaborals { get; set; }

    public virtual DbSet<LiderProyecto> LiderProyectos { get; set; }

    public virtual DbSet<Lidere> Lideres { get; set; }

    public virtual DbSet<Mantenimiento> Mantenimientos { get; set; }

    public virtual DbSet<Pagina> Paginas { get; set; }

    public virtual DbSet<PaginaRol> PaginaRols { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<PersonaProyectosAsignacion> PersonaProyectosAsignacions { get; set; }

    public virtual DbSet<Proyecto> Proyectos { get; set; }

    public virtual DbSet<RolUsuario> RolUsuarios { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolesPermiso> RolesPermisos { get; set; }

    public virtual DbSet<StackTecnologico> StackTecnologicos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=192.168.100.67;Database=IntegrityProjectManagement;User=timereport;Password=P@ssw0rd01; ; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActividadDiariaTimeReport>(entity =>
        {
            entity.HasKey(e => e.IdActividadDiaria).HasName("PK__Activida__D7F54D10431475E8");

            entity.ToTable("ActividadDiariaTimeReport");

            entity.Property(e => e.IdActividadDiaria).HasColumnName("IdActividad_Diaria");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.FechaActividad)
                .HasColumnType("date")
                .HasColumnName("Fecha_actividad");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("date")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaFin)
                .HasColumnType("date")
                .HasColumnName("fechaFin");
            entity.Property(e => e.Hora)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("hora");
            entity.Property(e => e.IdPersona).HasColumnName("idPersona");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.ActividadDiariaTimeReports)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("FK_Actividad_Diaria_Personas");

            entity.HasOne(d => d.IdProyectoNavigation).WithMany(p => p.ActividadDiariaTimeReports)
                .HasForeignKey(d => d.IdProyecto)
                .HasConstraintName("FK__Actividad__IdPro__06CD04F7");

            entity.HasOne(d => d.Usuario).WithMany(p => p.ActividadDiariaTimeReports)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK_Actividad_Diaria_Usuarios");
        });

        modelBuilder.Entity<Articulo>(entity =>
        {
            entity.HasKey(e => e.IdArticulo).HasName("PK__Articulo__AABB74229FE8C1AB");

            entity.Property(e => e.IdArticulo).HasColumnName("idArticulo");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.FechaEliminacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaEliminacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaModificacion");
            entity.Property(e => e.Fechacreacion)
                .HasColumnType("datetime")
                .HasColumnName("fechacreacion");
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("marca");
            entity.Property(e => e.Modelo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modelo");
            entity.Property(e => e.TipoComplemento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo_complemento");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuarioCreacion");
            entity.Property(e => e.UsuarioEliminacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuarioEliminacion");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuarioModificacion");
        });

        modelBuilder.Entity<AsignacionArticulo>(entity =>
        {
            entity.HasKey(e => e.IdAsignacionArticulo).HasName("PK__Asignaci__5D508DD06CA5DBB3");

            entity.ToTable("AsignacionArticulo");

            entity.Property(e => e.IdAsignacionArticulo).HasColumnName("idAsignacionArticulo");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.FechaEliminacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaEliminacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaModificacion");
            entity.Property(e => e.Fechacreacion)
                .HasColumnType("datetime")
                .HasColumnName("fechacreacion");
            entity.Property(e => e.IdArticulo).HasColumnName("idArticulo");
            entity.Property(e => e.IdAsignacion).HasColumnName("idAsignacion");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuarioCreacion");
            entity.Property(e => e.UsuarioEliminacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuarioEliminacion");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuarioModificacion");

            entity.HasOne(d => d.IdArticuloNavigation).WithMany(p => p.AsignacionArticulos)
                .HasForeignKey(d => d.IdArticulo)
                .HasConstraintName("FK_AsignacionArticulo_Articulo");

            entity.HasOne(d => d.IdAsignacionNavigation).WithMany(p => p.AsignacionArticulos)
                .HasForeignKey(d => d.IdAsignacion)
                .HasConstraintName("FK_AsignacionArticulo_Asignacion");
        });

        modelBuilder.Entity<BajaEquipo>(entity =>
        {
            entity.HasKey(e => e.IdBajaEquipo).HasName("PK__BajaEqui__D88DE945F3052A76");

            entity.ToTable("BajaEquipo");

            entity.Property(e => e.IdBajaEquipo).HasColumnName("idBajaEquipo");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.FechaEliminacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaEliminacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaModificacion");
            entity.Property(e => e.Fechacreacion)
                .HasColumnType("datetime")
                .HasColumnName("fechacreacion");
            entity.Property(e => e.IdEquipo).HasColumnName("idEquipo");
            entity.Property(e => e.MotivoBaja)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("motivoBaja");
            entity.Property(e => e.Observacion)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("observacion");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuarioCreacion");
            entity.Property(e => e.UsuarioEliminacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuarioEliminacion");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuarioModificacion");

            entity.HasOne(d => d.IdEquipoNavigation).WithMany(p => p.BajaEquipos)
                .HasForeignKey(d => d.IdEquipo)
                .HasConstraintName("FK_BajaEquipo_Equipo");
        });

        modelBuilder.Entity<Catalogo>(entity =>
        {
            entity.HasKey(e => e.IdCatalogo).HasName("PK__Catalogo__C615E0E8B4977D70");

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
            entity.Property(e => e.NombreMostrar)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("nombreMostrar");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuarioCreacion");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuarioModificacion");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Cliente__885457EE538DE97D");

            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.Celular)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("celular");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correoElectronico");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.FechaEliminacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaEliminacion");
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
            entity.Property(e => e.UsuarioEliminacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usuarioEliminacion");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuarioModificacion");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdEmpresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cliente__idEmpre__5812160E");
        });

        modelBuilder.Entity<CursosTomado>(entity =>
        {
            entity.HasKey(e => e.IdCursosTomadosPerfiles).HasName("PK__tmp_ms_x__B097D100EA8F3C29");

            entity.Property(e => e.IdCursosTomadosPerfiles).HasColumnName("idCursosTomadosPerfiles");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.FechaDesde)
                .HasColumnType("date")
                .HasColumnName("fechaDesde");
            entity.Property(e => e.FechaEliminacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaEliminacion");
            entity.Property(e => e.FechaHasta)
                .HasColumnType("date")
                .HasColumnName("fechaHasta");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaModificacion");
            entity.Property(e => e.Fechacreacion)
                .HasColumnType("datetime")
                .HasColumnName("fechacreacion");
            entity.Property(e => e.HoraCursoAvance)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("horaCursoAvance");
            entity.Property(e => e.HorasCurso)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("horasCurso");
            entity.Property(e => e.IdPersona).HasColumnName("idPersona");
            entity.Property(e => e.NombreCurso)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("nombreCurso");
            entity.Property(e => e.ProgresoPorcentaje)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("progresoPorcentaje");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usuarioCreacion");
            entity.Property(e => e.UsuarioEliminacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usuarioEliminacion");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usuarioModificacion");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.CursosTomados)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("FK__CursosTom__idPer__603D47BB");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.IdEmpresa).HasName("PK__Empresa__5EF4033E6976A869");

            entity.Property(e => e.Celular)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("celular");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
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
        });

        modelBuilder.Entity<Equipo>(entity =>
        {
            entity.HasKey(e => e.IdEquipo).HasName("PK__Equipo__981ACF53E5A51874");

            entity.Property(e => e.IdEquipo).HasColumnName("idEquipo");
            entity.Property(e => e.Batería)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("batería");
            entity.Property(e => e.Camara)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("camara");
            entity.Property(e => e.CargadorModel)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cargadorModel");
            entity.Property(e => e.Codigo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("codigo");
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("color");
            entity.Property(e => e.Conectividad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("conectividad");
            entity.Property(e => e.DiscoDuro)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("discoDuro");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.ExpressServiceCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("expressServiceCode");
            entity.Property(e => e.FechaEliminacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaEliminacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaModificacion");
            entity.Property(e => e.Fechacreacion)
                .HasColumnType("datetime")
                .HasColumnName("fechacreacion");
            entity.Property(e => e.Lector)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lector");
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("marca");
            entity.Property(e => e.MarcaMouse)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("marcaMouse");
            entity.Property(e => e.Memoria)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("memoria");
            entity.Property(e => e.Modelo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modelo");
            entity.Property(e => e.ModeloMouse)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("modeloMouse");
            entity.Property(e => e.NombreEquipo)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("nombreEquipo");
            entity.Property(e => e.Office)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("office");
            entity.Property(e => e.Pantalla)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pantalla");
            entity.Property(e => e.Procesador)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("procesador");
            entity.Property(e => e.Serial)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("serial");
            entity.Property(e => e.SerieMouse)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("serieMouse");
            entity.Property(e => e.ServiceTag)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("serviceTag");
            entity.Property(e => e.SistemaOperativo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sistemaOperativo");
            entity.Property(e => e.Usb)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usb");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuarioCreacion");
            entity.Property(e => e.UsuarioEliminacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuarioEliminacion");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuarioModificacion");
        });

        modelBuilder.Entity<EquipoPersonaAsignacion>(entity =>
        {
            entity.HasKey(e => e.IdAsignacion).HasName("PK__Asignaci__E17144787D307395");

            entity.ToTable("EquipoPersonaAsignacion");

            entity.Property(e => e.IdAsignacion).HasColumnName("idAsignacion");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.FechaAsignacion)
                .HasColumnType("date")
                .HasColumnName("fechaAsignacion");
            entity.Property(e => e.FechaEliminacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaEliminacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaModificacion");
            entity.Property(e => e.Fechacreacion)
                .HasColumnType("datetime")
                .HasColumnName("fechacreacion");
            entity.Property(e => e.IdEquipo).HasColumnName("idEquipo");
            entity.Property(e => e.IdPersona).HasColumnName("idPersona");
            entity.Property(e => e.Observacion)
                .IsUnicode(false)
                .HasColumnName("observacion");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuarioCreacion");
            entity.Property(e => e.UsuarioEliminacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuarioEliminacion");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuarioModificacion");

            entity.HasOne(d => d.IdEquipoNavigation).WithMany(p => p.EquipoPersonaAsignacions)
                .HasForeignKey(d => d.IdEquipo)
                .HasConstraintName("FK_Asignacion_Equipo");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.EquipoPersonaAsignacions)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("FK_Asignacion_Persona");
        });

        modelBuilder.Entity<FeedbackProgresoHistorico>(entity =>
        {
            entity.HasKey(e => e.IdFeedbackProgresoHistoricoPerfiles).HasName("PK__Feedback__DB122367E0E6B12C");

            entity.ToTable("FeedbackProgresoHistorico");

            entity.Property(e => e.IdFeedbackProgresoHistoricoPerfiles).HasColumnName("idFeedbackProgresoHistoricoPerfiles");
            entity.Property(e => e.Alertas)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("alertas");
            entity.Property(e => e.Entrevistas)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("entrevistas");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.FechaEliminacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaEliminacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaModificacion");
            entity.Property(e => e.Fechacreacion)
                .HasColumnType("datetime")
                .HasColumnName("fechacreacion");
            entity.Property(e => e.IdPersona).HasColumnName("idPersona");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("observaciones");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usuarioCreacion");
            entity.Property(e => e.UsuarioEliminacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usuarioEliminacion");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usuarioModificacion");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.FeedbackProgresoHistoricos)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("FK__FeedbackP__idPer__5A846E65");
        });

        modelBuilder.Entity<HistorialLaboral>(entity =>
        {
            entity.HasKey(e => e.IdHistorialPerfiles).HasName("PK__Historia__74391BEE3158D928");

            entity.ToTable("HistorialLaboral");

            entity.Property(e => e.IdHistorialPerfiles).HasColumnName("idHistorialPerfiles");
            entity.Property(e => e.Cargo)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.DescripcionSalida)
                .IsUnicode(false)
                .HasColumnName("descripcionSalida");
            entity.Property(e => e.Empresa)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("empresa");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.FechaDesde)
                .HasColumnType("date")
                .HasColumnName("fechaDesde");
            entity.Property(e => e.FechaEliminacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaEliminacion");
            entity.Property(e => e.FechaHasta)
                .HasColumnType("date")
                .HasColumnName("fechaHasta");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaModificacion");
            entity.Property(e => e.Fechacreacion)
                .HasColumnType("datetime")
                .HasColumnName("fechacreacion");
            entity.Property(e => e.IdPersona).HasColumnName("idPersona");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usuarioCreacion");
            entity.Property(e => e.UsuarioEliminacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usuarioEliminacion");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usuarioModificacion");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.HistorialLaborals)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("FK__Historial__idPer__54CB950F");
        });

        modelBuilder.Entity<LiderProyecto>(entity =>
        {
            entity.HasKey(e => e.IdLiderProyecto).HasName("PK__LiderPro__A840E48CEF3898F5");

            entity.ToTable("LiderProyecto");

            entity.Property(e => e.IdLiderProyecto).HasColumnName("idLiderProyecto");
            entity.Property(e => e.IdLider).HasColumnName("idLider");
            entity.Property(e => e.IdProyecto).HasColumnName("idProyecto");

            entity.HasOne(d => d.IdLiderNavigation).WithMany(p => p.LiderProyectos)
                .HasForeignKey(d => d.IdLider)
                .HasConstraintName("FK_LiderProyecto_Lider");

            entity.HasOne(d => d.IdProyectoNavigation).WithMany(p => p.LiderProyectos)
                .HasForeignKey(d => d.IdProyecto)
                .HasConstraintName("FK_LiderProyecto_Proyecto");
        });

        modelBuilder.Entity<Lidere>(entity =>
        {
            entity.HasKey(e => e.IdLider).HasName("PK__Lider__4FAD779B0123F736");

            entity.Property(e => e.IdLider).HasColumnName("idLider");
            entity.Property(e => e.EsLiderIntegritySolutions).HasColumnName("esLiderIntegritySolutions");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.FechaEliminacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaEliminacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaModificacion");
            entity.Property(e => e.IdPersona).HasColumnName("idPersona");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuarioCreacion");
            entity.Property(e => e.UsuarioEliminacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usuarioEliminacion");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuarioModificacion");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Lideres)
                .HasForeignKey(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Persona");
        });

        modelBuilder.Entity<Mantenimiento>(entity =>
        {
            entity.HasKey(e => e.IdMantenimiento).HasName("PK__Mantenim__187F756A520E1318");

            entity.ToTable("Mantenimiento");

            entity.Property(e => e.IdMantenimiento).HasColumnName("idMantenimiento");
            entity.Property(e => e.Costo)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("costo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.FechaEliminacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaEliminacion");
            entity.Property(e => e.FechaMantenimineto)
                .HasColumnType("date")
                .HasColumnName("fechaMantenimineto");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaModificacion");
            entity.Property(e => e.Fechacreacion)
                .HasColumnType("datetime")
                .HasColumnName("fechacreacion");
            entity.Property(e => e.IdEquipo).HasColumnName("idEquipo");
            entity.Property(e => e.NombreRespueto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreRespueto");
            entity.Property(e => e.NombreTecnico)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreTecnico");
            entity.Property(e => e.NumeroFactura)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("numeroFactura");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuarioCreacion");
            entity.Property(e => e.UsuarioEliminacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuarioEliminacion");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuarioModificacion");

            entity.HasOne(d => d.IdEquipoNavigation).WithMany(p => p.Mantenimientos)
                .HasForeignKey(d => d.IdEquipo)
                .HasConstraintName("FK_Mantenimiento_Equipo");
        });

        modelBuilder.Entity<Pagina>(entity =>
        {
            entity.HasKey(e => e.IdPagina).HasName("PK__Pagina__4AFCED6080ABB679");

            entity.ToTable("Pagina");

            entity.Property(e => e.IdPagina).HasColumnName("idPagina");
            entity.Property(e => e.Codigo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("codigo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Ruta)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("ruta");
            entity.Property(e => e.RutaPadre)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("rutaPadre");
            entity.Property(e => e.RutaUrl)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("rutaUrl");
        });

        modelBuilder.Entity<PaginaRol>(entity =>
        {
            entity.HasKey(e => e.IdPaginaRol).HasName("PK__PaginaRo__564B6933A511D836");

            entity.ToTable("PaginaRol");

            entity.Property(e => e.IdPaginaRol).HasColumnName("idPaginaRol");
            entity.Property(e => e.IdPagina).HasColumnName("idPagina");
            entity.Property(e => e.IdRol).HasColumnName("idRol");

            entity.HasOne(d => d.IdPaginaNavigation).WithMany(p => p.PaginaRols)
                .HasForeignKey(d => d.IdPagina)
                .HasConstraintName("FK__PaginaRol__idPag__318258D2");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.PaginaRols)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__PaginaRol__idRol__308E3499");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("estado");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.IdPersona).HasName("PK__Persona__A4788141B1CB1C28");

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
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.FechaClave).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaModificacion");
            entity.Property(e => e.Genero).HasColumnName("genero");
            entity.Property(e => e.Github)
                .IsUnicode(false)
                .HasColumnName("github");
            entity.Property(e => e.Imagen)
                .IsUnicode(false)
                .HasColumnName("imagen");
            entity.Property(e => e.Linkedin)
                .IsUnicode(false)
                .HasColumnName("linkedin");
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
        });

        modelBuilder.Entity<PersonaProyectosAsignacion>(entity =>
        {
            entity.HasKey(e => e.IdPersonaProyectos);

            entity.ToTable("PersonaProyectosAsignacion");

            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaEliminacion).HasColumnType("datetime");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioEliminacion)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Persona).WithMany(p => p.PersonaProyectosAsignacions)
                .HasForeignKey(d => d.PersonaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonaProyectosAsignacion_Personas");

            entity.HasOne(d => d.Proyecto).WithMany(p => p.PersonaProyectosAsignacions)
                .HasForeignKey(d => d.ProyectoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonaProyectosAsignacion_Proyectos");
        });

        modelBuilder.Entity<Proyecto>(entity =>
        {
            entity.HasKey(e => e.IdProyecto).HasName("PK__Proyecto__D0AF4CB42591483C");

            entity.Property(e => e.IdProyecto).HasColumnName("idProyecto");
            entity.Property(e => e.CodigoProyecto)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("codigoProyecto");
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

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Proyectos)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Proyecto__idClie__6B24EA82");
        });

        modelBuilder.Entity<RolUsuario>(entity =>
        {
            entity.HasKey(e => e.RolUsuario1).HasName("PK__RolUsuar__3CC5365A43BC1155");

            entity.HasIndex(e => e.UsuariosUsuarioId, "IX_RolUsuarios_UsuariosUsuarioId");

            entity.Property(e => e.RolUsuario1).HasColumnName("RolUsuario");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("estado");

            entity.HasOne(d => d.RolesRol).WithMany(p => p.RolUsuarios).HasForeignKey(d => d.RolesRolId);

            entity.HasOne(d => d.UsuariosUsuario).WithMany(p => p.RolUsuarios).HasForeignKey(d => d.UsuariosUsuarioId);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RolId);

            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("estado");
        });

        modelBuilder.Entity<RolesPermiso>(entity =>
        {
            entity.HasKey(e => new { e.RolId, e.PermisoId });

            entity.HasIndex(e => e.PermisoId, "IX_RolesPermisos_PermisoId");

            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("estado");

            entity.HasOne(d => d.Permiso).WithMany(p => p.RolesPermisos).HasForeignKey(d => d.PermisoId);

            entity.HasOne(d => d.Rol).WithMany(p => p.RolesPermisos).HasForeignKey(d => d.RolId);
        });

        modelBuilder.Entity<StackTecnologico>(entity =>
        {
            entity.HasKey(e => e.IdStackTecnologico).HasName("PK__StackTec__222C99F4E7665001");

            entity.ToTable("StackTecnologico");

            entity.Property(e => e.IdStackTecnologico).HasColumnName("idStackTecnologico");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.FechaEliminacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaEliminacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaModificacion");
            entity.Property(e => e.Fechacreacion)
                .HasColumnType("datetime")
                .HasColumnName("fechacreacion");
            entity.Property(e => e.IdCatalogoStack).HasColumnName("idCatalogoStack");
            entity.Property(e => e.IdNivelDominioTecnologico).HasColumnName("idNivelDominioTecnologico");
            entity.Property(e => e.IdPersona).HasColumnName("idPersona");
            entity.Property(e => e.Tecnologias)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("tecnologias");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usuarioCreacion");
            entity.Property(e => e.UsuarioEliminacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usuarioEliminacion");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usuarioModificacion");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.StackTecnologicos)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("FK__StackTecn__idPer__5D60DB10");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.Property(e => e.ActulizadaClave).HasColumnType("datetime");
            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.ConfirmarClave).HasMaxLength(50);
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdPersona).HasColumnName("idPersona");
            entity.Property(e => e.NombreUsuario)
                .IsUnicode(false)
                .HasColumnName("nombreUsuario");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("FK_Usuarios_Persona");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
