using System;
using SaludAr.BE.Infraestructura;

namespace SaludAr.BLL
{
    public interface IControlDePatentes
    {
        bool ConcederAcceso(string codigoPatente);
        bool ConcederAcceso(BE.Infraestructura.Patente patente);
    }

    /// <summary>
    /// Modela las operaciones relacionadas con la autorización de acceso a ciertos recursos
    /// </summary>
    public class ControlDePatentes : IControlDePatentes
    {
        public const string AgregarPacienteAlPadron = Services.PatentesDelSistema.AgregarPacienteAlPadron;
        public const string EditarDatosDelPadronDePacientes = Services.PatentesDelSistema.EditarDatosDelPadronDePacientes;
        public const string VerHistoriaClinica = Services.PatentesDelSistema.VerHistoriaClinica;
        public const string EditarEspecialidadesDelProfesional = Services.PatentesDelSistema.EditarEspecialidadesDelProfesional;
        public const string RegistrarNuevoEmpleado = Services.PatentesDelSistema.RegistrarNuevoEmpleado;
        public const string EditarDatosDelEmpleado = Services.PatentesDelSistema.EditarDatosDelEmpleado;
        public const string DesvincularEmpleado = Services.PatentesDelSistema.DesvincularEmpleado;
        public const string DefinirAgenda = Services.PatentesDelSistema.DefinirAgenda;
        public const string DarTurnoPaciente = Services.PatentesDelSistema.DarTurnoPaciente;
        public const string VerTurnosAsignados = Services.PatentesDelSistema.VerTurnosAsignados;
        public const string BuscarTurnoLibre = Services.PatentesDelSistema.BuscarTurnoLibre;
        public const string AdmisionDePaciente = Services.PatentesDelSistema.AdmisionDePaciente;
        public const string AtenderPacienteRegistrarEvolucion = Services.PatentesDelSistema.AtenderPacienteRegistrarEvolucion;
        public const string DerivarConEspecialista = Services.PatentesDelSistema.DerivarConEspecialista;
        public const string RegistrarPrestacion = Services.PatentesDelSistema.RegistrarPrestacion;
        public const string ConfigurarCentrosDeSalud = Services.PatentesDelSistema.ConfigurarCentrosDeSalud;
        public const string ConfigurarEspecialidadesDeLaRed = Services.PatentesDelSistema.ConfigurarEspecialidadesDeLaRed;
        public const string ConfigurarPrestacionesDeLaRed = Services.PatentesDelSistema.ConfigurarPrestacionesDeLaRed;
        public const string ConcederAccesoAlSistema = Services.PatentesDelSistema.ConcederAccesoAlSistema;
        public const string RevocarAccesoAlSistema = Services.PatentesDelSistema.RevocarAccesoAlSistema;
        public const string ResetearContraseñaDeAccesoPorUsuario = Services.PatentesDelSistema.ResetearContraseñaDeAccesoPorUsuario;
        public const string RealizarTareasDeBackup = Services.PatentesDelSistema.RealizarTareasDeBackup;
        public const string AsignarRolesPorUsuario = Services.PatentesDelSistema.AsignarRolesPorUsuario;

        public bool ConcederAcceso(string codigoPatente)
        {
            return this.ObtenerPermisosUsuarioActual().ConcederAcceso(codigoPatente);
        }

        public bool ConcederAcceso(BE.Infraestructura.Patente patente)
        {
            return this.ObtenerPermisosUsuarioActual().ConcederAcceso(patente.Codigo);
        }

        private IPermiso ObtenerPermisosUsuarioActual()
        {
            return SessionManager.Instance.UsuarioActual.Permiso;
        }
    }
}