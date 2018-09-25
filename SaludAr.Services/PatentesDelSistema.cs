using System;
using System.Linq;

namespace SaludAr.Services
{
    /// <summary>
    /// Agrupa todas las patentes existentes en el sistema
    /// </summary>
    public static class PatentesDelSistema
    {
        #region "Acá deben ir cada una de las patentes existentes en el sistema con su código"

        //public const string PuedeConsutlarBitacoraDelSistema = "P0001";
        public const string AgregarPacienteAlPadron = "PP0001";
        public const string EditarDatosDelPadronDePacientes = "PP0002";
        public const string VerHistoriaClinica = "PP0003";
        public const string EditarEspecialidadesDelProfesional = "PP0004";
        public const string RegistrarNuevoEmpleado = "PP0005";
        public const string EditarDatosDelEmpleado = "PU0003";
        public const string DesvincularEmpleado = "PP0006";
        public const string DefinirAgenda = "PT0001";
        public const string DarTurnoPaciente = "PT0002";
        public const string VerTurnosAsignados = "PT0003";
        public const string BuscarTurnoLibre = "PT0004";
        public const string AdmisionDePaciente = "PT0005";
        public const string AtenderPacienteRegistrarEvolucion = "PA0001";
        public const string DerivarConEspecialista = "PA0002";
        public const string RegistrarPrestacion = "PA0003";
        public const string ConfigurarCentrosDeSalud = "PG0001";
        public const string ConfigurarEspecialidadesDeLaRed = "PG0002";
        public const string ConfigurarPrestacionesDeLaRed = "PG0003";
        public const string ConcederAccesoAlSistema = "PS0001";
        public const string RevocarAccesoAlSistema = "PS0002";
        public const string ResetearContraseñaDeAccesoPorUsuario = "PS0003";
        public const string RealizarTareasDeBackup = "PS0004";
        public const string AsignarRolesPorUsuario = "PS0005";

        #endregion

        public static string[] PatentesDisponibles
        {
            get
            {
                //Enumero por reflexión los permisos disponibles en el sistema
                var camposDePatente = typeof(PatentesDelSistema).GetFields();
                return camposDePatente
                    .Select(campo => (string) campo.GetRawConstantValue())
                    .ToArray();
            }
        }
    }
}
