using System;
using System.Linq;
using SaludAr.BE.Bitacora;

namespace SaludAr.BLL
{
    public interface IPaciente
    {
        BE.Paciente Nuevo();
        void Actualizar(BE.Paciente paciente);
        void Eliminar(BE.Paciente paciente);
        BE.Paciente[] Listar();
        BE.Paciente[] Buscar(string texto);
    }

    public class Paciente : IPaciente
    {
        private readonly DAL.IPaciente _pacienteDal;

        public Paciente(DAL.IPaciente pacienteDal)
        {
            _pacienteDal = pacienteDal;
        }

        public BE.Paciente Nuevo()
        {
            return new BE.Paciente();
        }

        public void Actualizar(BE.Paciente paciente)
        {
            _pacienteDal.Actualizar(paciente);
            Bitacora.Default.RegistrarEnBitacora(Evento.InformacionPacienteActualizada, paciente.Id.ToString());
        }

        public void Eliminar(BE.Paciente paciente)
        {
            _pacienteDal.Eliminar(paciente);
        }

        public BE.Paciente[] Listar()
        {
            return _pacienteDal.Listar();
        }

        public BE.Paciente[] Buscar(string texto)
        {
            //Buscador simple que por cada palabra buscada comprueba:
            //la coincidencia parcial contra el Apellido o Nombre,
            //o bien, la coincidencia exacta con el numero de documento
            var tokens = texto.Split(' ');
            return this.Listar()
                .Where(p => tokens.Any(t => p.Apellido.StartsWith(t, StringComparison.InvariantCultureIgnoreCase) || p.Nombre.StartsWith(t, StringComparison.InvariantCultureIgnoreCase))
                        || tokens.Any(t => p.NumeroDocumento.Equals(t)))
                .ToArray();
        }
    }
}
