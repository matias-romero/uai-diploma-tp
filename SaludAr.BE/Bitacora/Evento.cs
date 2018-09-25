using System;

namespace SaludAr.BE.Bitacora
{
    /// <summary>
    /// Modela los tipos de eventos que registran entradas en la bitácora
    /// </summary>
    public class Evento
    {
        #region "Constantes de Evento"
        public const int UsuarioIngresoAlSistema = 1;
        public const int UsuarioSalioDelSistema = 2;
        public const int UsuarioFalloIngresandoCredenciales = 3;
        public const int AdministradorRealizoUnaCopiaDeSeguridad = 4;
        public const int AdministradorRecuperoBaseDeDatos = 5;
        public const int PlanificadorConfiguroOfertaAgenda = 6;
        public const int InformacionUsuarioActualizada = 7;
        public const int InformacionPacienteActualizada = 8;
        public const int NuevoTurnoAsignado = 9;
        public const int InicioAtencionAmbulatoria = 10;
        public const int FinAtencionAmbulatoria = 11;
        #endregion 

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public override string ToString()
        {
            return this.Descripcion;
        }
    }
}
