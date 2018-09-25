using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SaludAr.BE.Empleados;

namespace SaludAr.DAL.Internal
{
    internal class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        public static Action<string> LoggerAction { get; set; }

        public override void InitializeDatabase(DatabaseContext context)
        {
            LoggerAction = log => System.Diagnostics.Debug.Print(log);

            context.Configuration.LazyLoadingEnabled = false;
            context.Database.Log = LoggerAction;
            //context.Configuration.AutoDetectChangesEnabled = false;
            base.InitializeDatabase(context);
        }

        protected override void Seed(DatabaseContext context)
        {
            var entityRawSql = context.CreateRawSqlHelper();
            this.ParametrizarPermisosPorDefecto(context);
            this.ParametrizarDatosParaBitacora(context);
            this.ParametrizarUsuariosPorDefecto(context, entityRawSql);
            this.ParametrizarDatosOperativosDePrueba(context);

            base.Seed(context);
        }

        private void ParametrizarDatosOperativosDePrueba(DatabaseContext context)
        {
        #if DEBUG

            //Estos objetos solo se cargan para facilitar las pruebas.
            //El sistema funciona correctamente sin los mismos y ofrece pantallas para poder cargarlos
            var centroDeSaludPorDefecto = new BE.CentroDeSalud
            {
                Nombre = "Hospital Central"
            };
            context.CentrosDeSalud.Add(centroDeSaludPorDefecto);

            var especialidadClinicaPorDefecto = new BE.Especialidad { Nombre = "Cardiología"};
            context.Especialidades.Add(especialidadClinicaPorDefecto);
            var especialidadImagenologiaPorDefecto = new BE.Especialidad { Nombre = "Radiología" };
            context.Especialidades.Add(especialidadImagenologiaPorDefecto);
            var especialidadLaboratorioPorDefecto = new BE.Especialidad { Nombre = "Análisis Clínicos" };
            context.Especialidades.Add(especialidadLaboratorioPorDefecto);

            var pacientePorDefecto = new BE.Paciente
            {
                Apellido = "Doe",
                Nombre = "Jane",
                FechaNacimiento = new DateTime(1960, 04, 01),
                NumeroDocumento = "123456789",
                Sexo = Sexo.Femenino
            };
            context.Set<BE.Paciente>().Add(pacientePorDefecto);
        #endif
        }

        private void ParametrizarUsuariosPorDefecto(DatabaseContext context, IEntityRawSql entityRawSql)
        {
            var empleadoDal = new DAL.Empleado(context);
            var usuariosPorDefecto = new List<BE.Infraestructura.Usuario>
            {
                new BE.Infraestructura.Usuario
                {
                    Nombre = "admin",
                    Contraseña = "admin",
                    Permiso = new BE.Infraestructura.Familia {Codigo = "SUPER"}
                },
                new BE.Infraestructura.Usuario
                {
                    Nombre = "operador",
                    Contraseña = "operador",
                    Permiso = new BE.Infraestructura.Familia {Codigo = "GP0005"}
                }
            };

            var empleadoSysAdmin = new BE.Empleados.Empleado
            {
                Nombre = "System Administrator",
                Apellido = "System Administrator",
                NroLegajo = 0,
                Sexo = BE.Empleados.Sexo.NoEspecificado,
                //CredencialUsuario = usuariosPorDefecto[0]
            };
            empleadoDal.Actualizar(empleadoSysAdmin);

            var empleadoOperador = new BE.Empleados.Empleado
            {
                Nombre = "Operador",
                Apellido = "Operador",
                Sexo = Sexo.Masculino,
                NroLegajo = 1,
                //CredencialUsuario = usuariosPorDefecto[1]
            };
            empleadoDal.Actualizar(empleadoOperador);

            var usuarioDal = new DAL.Usuario(context, entityRawSql);
            usuarioDal.CrearCredencialDeUsuario(empleadoSysAdmin, usuariosPorDefecto[0].Permiso, usuariosPorDefecto[0].Nombre);
            usuarioDal.CrearCredencialDeUsuario(empleadoOperador, usuariosPorDefecto[1].Permiso, usuariosPorDefecto[1].Nombre);

        #if DEBUG
            //var especialidadPorDefecto = context.Especialidades.First();
            var profesionalPorDefecto = new BE.Empleados.Profesional
            {
                Nombre = "Dr",
                Apellido = "Who",
                CodMatricula = "WHOIS007",
                Sexo = Sexo.Masculino,
                NroLegajo = 2,
                CredencialUsuario = new BE.Infraestructura.Usuario
                {
                    Nombre = "drwho",
                    Contraseña = "drwho",
                    Permiso = new BE.Infraestructura.Familia { Codigo = "GP0006" }
                },
                //Especialidades = new List<BE.Especialidad> { especialidadPorDefecto }
            };
            var profesionalDal = new DAL.Profesional(context);
            profesionalDal.Actualizar(profesionalPorDefecto);

            usuarioDal.CrearCredencialDeUsuario(profesionalPorDefecto, profesionalPorDefecto.CredencialUsuario.Permiso, profesionalPorDefecto.CredencialUsuario.Nombre);
        #endif
        }

        private void ParametrizarDatosParaBitacora(DatabaseContext context)
        {
            //Defino los eventos de bitacora por defecto
            var bitacoraDal = new DAL.Bitacora(context);
            var setEventos = context.Set<BE.Bitacora.Evento>();
            foreach (var eventoDisponible in bitacoraDal.EventosDisponibles)
                setEventos.Add(eventoDisponible);
        }

        private void ParametrizarPermisosPorDefecto(DatabaseContext context)
        {
            //Defino las patentes por defecto
            var permisoDal = new DAL.Permiso(context);
            foreach (var patenteExistente in permisoDal.PatentesExistentes)
                context.Patentes.Add(patenteExistente);

            context.SaveChanges();

            //Defino las familias por defecto
            foreach (var familiaPorDefecto in permisoDal.FamiliasPorDefecto)
                permisoDal.Actualizar(familiaPorDefecto);
        }

        public static void Configure()
        {
            Database.SetInitializer(new DatabaseInitializer());
        }
    }
}