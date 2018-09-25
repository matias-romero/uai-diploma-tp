using System;
using SaludAr.BE.Bitacora;

namespace SaludAr.BLL
{
    public interface IUsuario
    {
        BE.Infraestructura.Usuario IniciarSesion(string nombreUsuario, string contraseña);
        BE.Infraestructura.Usuario FinalizarSesion();
    }

    public class Usuario : IUsuario
    {
        private readonly DAL.IUsuario _usuarioDal;

        public Usuario(DAL.IUsuario usuarioDal)
        {
            _usuarioDal = usuarioDal;
        }

        public BE.Infraestructura.Usuario IniciarSesion(string nombreUsuario, string contraseña)
        {
            var usuario = _usuarioDal.ObtenerPorNombre(nombreUsuario);
            if (usuario != null)
            {
                var esCorrecto = usuario.Contraseña.Equals(contraseña);
                if (esCorrecto)
                    SessionManager.Instance.IniciarSesion(usuario);
            }

            var usuarioActual = SessionManager.Instance.UsuarioActual;
            if (usuarioActual == null)
            {
                //Registro el intento fallido de Login
                Bitacora.Default.RegistrarEnBitacora(Evento.UsuarioFalloIngresandoCredenciales, Severidad.Advertencia,
                    nombreUsuario);
            }

            return usuarioActual;
        }

        public BE.Infraestructura.Usuario FinalizarSesion()
        {
            var ultimoUsuarioEnLinea = SessionManager.Instance.UsuarioActual;
            SessionManager.Instance.FinalizarSesion();
            return ultimoUsuarioEnLinea;
        }
    }
}