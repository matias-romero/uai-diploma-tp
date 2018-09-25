using System;
using System.Linq;
using System.Reflection;

namespace SaludAr.Services
{
    /// <summary>
    /// Define todas las familias existentes por defecto en el sistema
    /// </summary>
    public static class FamiliasPorDefecto
    {
        #region "Defino el código de Familia junto a su nombre seguido de las patenes que agrupe"

        private static readonly string[] GP0001 =
        {
            "Registrar nuevo profesional",
            PatentesDelSistema.RegistrarNuevoEmpleado,
            PatentesDelSistema.EditarEspecialidadesDelProfesional
        };

        private static readonly string[] GP0002 =
        {
            "Gestión de Pacientes",
            PatentesDelSistema.AgregarPacienteAlPadron,
            PatentesDelSistema.EditarDatosDelPadronDePacientes
        };

        private static readonly string[] GP0003 =
        {
            "Gestión de usuarios",
            PatentesDelSistema.ConcederAccesoAlSistema,
            PatentesDelSistema.RevocarAccesoAlSistema,
            PatentesDelSistema.ResetearContraseñaDeAccesoPorUsuario,
            PatentesDelSistema.AsignarRolesPorUsuario,
            PatentesDelSistema.RegistrarNuevoEmpleado,
            PatentesDelSistema.EditarDatosDelEmpleado,
            PatentesDelSistema.DesvincularEmpleado
        };

        private static readonly string[] GP0004 =
        {
            "Operador de turnos",
            PatentesDelSistema.DarTurnoPaciente,
            PatentesDelSistema.VerTurnosAsignados,
            PatentesDelSistema.BuscarTurnoLibre,
            PatentesDelSistema.AdmisionDePaciente
        };

        private static readonly string[] GP0005 =
        {
            "Operador IT",
            //TODO: Debería incluir algunos permisos de alta empleados para la primera vez
            PatentesDelSistema.RealizarTareasDeBackup
        };

        private static readonly string[] GP0006 =
        {
            "Médico",
            PatentesDelSistema.VerHistoriaClinica,
            PatentesDelSistema.AtenderPacienteRegistrarEvolucion,
            PatentesDelSistema.DerivarConEspecialista,
            PatentesDelSistema.RegistrarPrestacion
        };

        #if DEBUG
        //Privilegio de acceso ilimitado para facilitar el DEBUG
        private static readonly string[] SUPER =
        {
            "Acceso Ilimitado",
            PatentesDelSistema.AgregarPacienteAlPadron,
            PatentesDelSistema.EditarDatosDelPadronDePacientes,
            PatentesDelSistema.VerHistoriaClinica,
            PatentesDelSistema.EditarEspecialidadesDelProfesional,
            PatentesDelSistema.RegistrarNuevoEmpleado,
            PatentesDelSistema.EditarDatosDelEmpleado,
            PatentesDelSistema.DesvincularEmpleado,
            PatentesDelSistema.DefinirAgenda,
            PatentesDelSistema.DarTurnoPaciente,
            PatentesDelSistema.VerTurnosAsignados,
            PatentesDelSistema.BuscarTurnoLibre,
            PatentesDelSistema.AdmisionDePaciente,
            PatentesDelSistema.AtenderPacienteRegistrarEvolucion,
            PatentesDelSistema.DerivarConEspecialista,
            PatentesDelSistema.RegistrarPrestacion,
            PatentesDelSistema.ConfigurarCentrosDeSalud,
            PatentesDelSistema.ConfigurarEspecialidadesDeLaRed,
            PatentesDelSistema.ConfigurarPrestacionesDeLaRed,
            PatentesDelSistema.ConcederAccesoAlSistema,
            PatentesDelSistema.RevocarAccesoAlSistema,
            PatentesDelSistema.ResetearContraseñaDeAccesoPorUsuario,
            PatentesDelSistema.RealizarTareasDeBackup,
            PatentesDelSistema.AsignarRolesPorUsuario
        };
        #endif

        #endregion

        public static Tuple<string,string, string[]>[] FamiliasDisponibles
        {
            get
            {
                //Enumero por reflexión los permisos disponibles en el sistema
                var camposDePatente = typeof(FamiliasPorDefecto).GetRuntimeFields();
                return camposDePatente
                    .Select(campo =>
                    {
                        var codigo = campo.Name;
                        var arr = (string[]) campo.GetValue(null);
                        var descripcion = arr[0];
                        var patentes = arr.Skip(1).ToArray();
                        return Tuple.Create(codigo, descripcion, patentes);
                    })
                    .ToArray();
            }
        }
    }
}
