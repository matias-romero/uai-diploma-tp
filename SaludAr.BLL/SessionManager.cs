using System;
using SaludAr.BE.Bitacora;

namespace SaludAr.BLL
{
    /// <summary>
    /// Controla el estado de sesión de usuario
    /// </summary>
    public class SessionManager
    {
        #region "Singleton"

        private static readonly Lazy<SessionManager> DefaultInstance =
            new Lazy<SessionManager>(() => new SessionManager());

        public static SessionManager Instance
        {
            get { return DefaultInstance.Value; }
        }

        #endregion

        private BE.Infraestructura.Usuario _usuario;

        public BE.Infraestructura.Usuario UsuarioActual
        {
            get { return _usuario; }
            private set { _usuario = value; }
        }

        public void IniciarSesion(BE.Infraestructura.Usuario usuario)
        {
            this.UsuarioActual = usuario;
            Bitacora.Default.RegistrarEnBitacora(Evento.UsuarioIngresoAlSistema, usuario.Nombre);
        }

        public void FinalizarSesion()
        {
            var usuarioActual = this.UsuarioActual;
            this.UsuarioActual = null;
            Bitacora.Default.RegistrarEnBitacora(Evento.UsuarioSalioDelSistema, usuarioActual.Nombre);
        }
    }
}