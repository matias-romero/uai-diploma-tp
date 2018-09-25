using System;
using System.Linq;
using SaludAr.BE.Bitacora;
using SaludAr.BE.Empleados;
using SaludAr.BLL.Traductor;
using SaludAr.DAL;
using IPermiso = SaludAr.BE.Infraestructura.IPermiso;

namespace SaludAr.BLL
{
    public interface IEmpleado
    {
        BE.Empleados.Empleado BuscarPorId(Guid id);
        BE.Empleados.Empleado BuscarPorNombreUsuarioRelacionado(string nombreUsuario);
        BE.Empleados.Empleado[] Listar();
        BE.Empleados.Empleado[] ListarEmpleadosSoloConCredenciales();
        BE.Empleados.Profesional[] ListarSoloProfesionales();
        bool ValidarLegajo(BE.Empleados.Empleado empleado);
        BE.Infraestructura.ValorDeEnumeracion[] SexosPosibles { get; }
        void Actualizar(BE.Empleados.Empleado empleado);
        void HabilitarCredenciales(BE.Empleados.Empleado empleado, string nombreUsuario, BE.Infraestructura.IPermiso perfil);
        void EliminarCredenciales(BE.Empleados.Empleado empleado);
    }

    public class Empleado : IEmpleado
    {
        private readonly ITraductor _traductor;
        private readonly DAL.IEmpleado _empleadoDal;
        private readonly IProfesional _profesionalDal;
        private readonly DAL.IUsuario _usuarioDal;

        public Empleado(ITraductor traductor, DAL.IEmpleado empleadoDal, DAL.IProfesional profesionalDal, DAL.IUsuario usuarioDal)
        {
            _traductor = traductor;
            _empleadoDal = empleadoDal;
            _profesionalDal = profesionalDal;
            _usuarioDal = usuarioDal;
        }

        public BE.Empleados.Empleado BuscarPorId(Guid id)
        {
            return _empleadoDal.BuscarPorId(id);
        }

        public BE.Empleados.Empleado BuscarPorNombreUsuarioRelacionado(string nombreUsuario)
        {
            return _empleadoDal.BuscarPorNombreUsuarioRelacionado(nombreUsuario);
        }

        public BE.Empleados.Empleado[] Listar()
        {
            return _empleadoDal.Listar();
        }

        public BE.Empleados.Empleado[] ListarEmpleadosSoloConCredenciales()
        {
            return this.Listar()
                .Where(e => e.CredencialUsuario != null)
                .ToArray();
        }

        public BE.Empleados.Profesional[] ListarSoloProfesionales()
        {
            return _profesionalDal.Listar();
        }

        public bool ValidarLegajo(BE.Empleados.Empleado empleado)
        {
            //El legajo es valido si no existe otro empleado con ese numero
            return !_empleadoDal.ExisteLegajo(empleado);
        }

        public BE.Infraestructura.ValorDeEnumeracion[] SexosPosibles
        {
            get { return new Enumerados(_traductor).Listar(typeof(Sexo)); }
        }

        public void Actualizar(BE.Empleados.Empleado empleado)
        {
            var profesional = empleado as BE.Empleados.Profesional;
            if (profesional != null)
            {
                _profesionalDal.Actualizar(profesional);
                this.RegistrarActualizacionEnBitacora(profesional);
                return;
            }
               
            _empleadoDal.Actualizar(empleado);
            this.RegistrarActualizacionEnBitacora(empleado);
        }

        public void HabilitarCredenciales(BE.Empleados.Empleado empleado, string nombreUsuario, IPermiso perfil)
        {
            if(Guid.Empty.Equals(empleado.Id)) //Debo grabar primero al empleado
                _empleadoDal.Actualizar(empleado);

            var credencialUsuario = _usuarioDal.CrearCredencialDeUsuario(empleado, perfil, nombreUsuario);
            empleado.CredencialUsuario = credencialUsuario;
        }

        public void EliminarCredenciales(BE.Empleados.Empleado empleado)
        {
            _usuarioDal.EliminarCredencialDeUsuario(empleado.CredencialUsuario);
            empleado.CredencialUsuario = null;
        }

        private void RegistrarActualizacionEnBitacora(BE.Empleados.Empleado empleadoActualizado)
        {
            //Registro la modificación en la bitácora
            Bitacora.Default.RegistrarEnBitacora(Evento.InformacionUsuarioActualizada, empleadoActualizado.Id.ToString());
        }
    }
}
