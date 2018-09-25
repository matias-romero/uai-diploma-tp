using System;
using System.Data.Entity;
using System.Linq;
using SaludAr.DAL.Internal;
using SaludAr.DAL.Internal.Auxiliares;
using SaludAr.DAL.Validaciones;

namespace SaludAr.DAL
{
    public interface IUsuario
    {
        BE.Infraestructura.Usuario ObtenerPorNombre(string nombreUsuario);
        BE.Infraestructura.Usuario ObtenerPorEmpleado(BE.Empleados.Empleado empleado);
        BE.Infraestructura.Usuario CrearCredencialDeUsuario(BE.Empleados.Empleado empleado, BE.Infraestructura.IPermiso permiso, string nombreUsuario);
        void EliminarCredencialDeUsuario(BE.Infraestructura.Usuario credencialUsuario);
    }

    internal class Usuario : IUsuario
    {
        private readonly IEntityRawSql _entityRawSql;
        private readonly DatabaseContext _databaseContext;

        private readonly DAL.IPermiso _permisoDal;
        private readonly IReadOnlyEntityDbSet<Internal.Auxiliares.UsuarioPermiso> _usuarioPermisoDbSet;

        public Usuario(Internal.DatabaseContext databaseContext, Internal.IEntityRawSql entityRawSql)
        {
            _entityRawSql = entityRawSql;
            _databaseContext = databaseContext;

            _permisoDal = new Permiso(databaseContext);
            _usuarioPermisoDbSet = databaseContext.ResolveDbSet<Internal.Auxiliares.UsuarioPermiso>();
        }

        public BE.Infraestructura.Usuario ObtenerPorNombre(string nombreUsuario)
        {
            var usuario = _databaseContext.Usuarios.AsNoTracking().SingleOrDefault(u => u.Nombre.Equals(nombreUsuario));
            this.CargarPermisosDelUsuario(usuario);
            return usuario;
        }

        public BE.Infraestructura.Usuario ObtenerPorEmpleado(BE.Empleados.Empleado empleado)
        {
            const string SQL = "SELECT Nombre, Contraseña FROM Usuario WHERE Empleado_Id=@EmpleadoId";
            var usuario = _entityRawSql.ExecuteQuery<BE.Infraestructura.Usuario>(SQL, new {EmpleadoId = empleado.Id});
            return usuario.SingleOrDefault();
        }

        public BE.Infraestructura.Usuario CrearCredencialDeUsuario(BE.Empleados.Empleado empleado, BE.Infraestructura.IPermiso permiso, string nombreUsuario)
        {
            var estaRepetido = _entityRawSql.ExecuteScalar<int>("SELECT COUNT(1) AS EsRepetido FROM Usuario WHERE Empleado_Id<>@EmpleadoId AND Nombre=@NombreUsuario", new { EmpleadoId = empleado.Id, NombreUsuario = nombreUsuario }) > 0;
            if(estaRepetido)
                throw new ElementoRepetidoException(null, nameof(BE.Infraestructura.Usuario.Nombre), nombreUsuario);

            //Compruebo si el usuario existe repetido
            var coincidencias = _entityRawSql.ExecuteQuery<dynamic>("SELECT Nombre, Empleado_Id FROM Usuario WHERE Empleado_Id=@EmpleadoId", new { EmpleadoId = empleado.Id });
            foreach (var coincidencia in coincidencias)
                this.EliminarCredencialDeUsuario(new BE.Infraestructura.Usuario{ Nombre = coincidencia.Nombre });

            //Eliminar la credencial existente y recrearla para evitar problemas.
            if (empleado.CredencialUsuario != null)
            {
                this.EliminarCredencialDeUsuario(empleado.CredencialUsuario);
                empleado.CredencialUsuario = null;
            }
                
            var credencialUsuario = new BE.Infraestructura.Usuario
            {
                Nombre = nombreUsuario,
                Contraseña = nombreUsuario,
                Permiso = permiso
            };
            empleado.CredencialUsuario = credencialUsuario;

            _entityRawSql.ExecuteSql(
                "INSERT INTO Usuario(Nombre, Contraseña, Empleado_Id) VALUES(@Nombre, @PWD, @EmpleadoId)",
                new
                {
                    Nombre = credencialUsuario.Nombre,
                    PWD = credencialUsuario.Contraseña,
                    EmpleadoId = empleado.Id
                });
            
            var perfilUsuario = empleado.CredencialUsuario.Permiso as BE.Infraestructura.Familia;
            if (!string.IsNullOrEmpty(perfilUsuario.Codigo))
            {
                var usuarioPermiso = new UsuarioPermiso
                {
                    FamiliaId = perfilUsuario.Codigo,
                    UsuarioId = empleado.CredencialUsuario.Nombre
                };
                
                _entityRawSql.ExecuteSql("INSERT INTO UsuarioPermiso(FamiliaId, UsuarioId) VALUES (@FamiliaId, @UsuarioId)", usuarioPermiso);
            }

            return empleado.CredencialUsuario;
        }

        public void EliminarCredencialDeUsuario(BE.Infraestructura.Usuario credencialUsuario)
        {
            if (credencialUsuario != null)
            {
                //Borro todos los permisos relacionado al usuario
                const string SqlBorrarPermisosUsuario = "DELETE FROM UsuarioPermiso WHERE UsuarioId=@NombreUsuario";
                var cantidadRegistrosAfectados = _entityRawSql.ExecuteSql(SqlBorrarPermisosUsuario, new { NombreUsuario = credencialUsuario.Nombre });

                //Borro el usuario solicitado
                const string SqlBorrarUsuario = "DELETE FROM Usuario WHERE Nombre=@NombreUsuario";
                cantidadRegistrosAfectados += _entityRawSql.ExecuteSql(SqlBorrarUsuario, new { NombreUsuario = credencialUsuario.Nombre });
            }

        }

        private void CargarPermisosDelUsuario(BE.Infraestructura.Usuario usuario)
        {
            if (usuario != null)
            {
                var permisoUsuario = new BE.Infraestructura.Familia();
                var permisosAsociados = _usuarioPermisoDbSet.FindAllWithoutRelatedEntities(up => up.UsuarioId == usuario.Nombre);

                var familias = _permisoDal.ListarFamilias;
                foreach (var permisoAsociado in permisosAsociados)
                {
                    var familia = familias.SingleOrDefault(f => f.Codigo.Equals(permisoAsociado.FamiliaId));
                    permisoUsuario.Permisos.Add(familia);
                }

                usuario.Permiso = permisoUsuario;
            }
        }
    }
}