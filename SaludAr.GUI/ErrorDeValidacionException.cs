using System;
using SaludAr.BLL.Traductor;

namespace SaludAr.GUI
{
    public class ErrorDeValidacionException : Exception
    {
        public string ClaveMensaje { get; }

        public ErrorDeValidacionException(string claveMensaje)
        {
            this.ClaveMensaje = claveMensaje;
        }

        private ErrorDeValidacionException(string claveMensaje, string mensajeLiteralAlUsuario)
            :base(mensajeLiteralAlUsuario)
        {
            this.ClaveMensaje = claveMensaje;
        }

        public string TraducirMensaje(ITraductor traductor)
        {
            if (!string.IsNullOrEmpty(this.ClaveMensaje))
                return traductor.Traducir(this.ClaveMensaje);

            return this.Message;
        }

        public static ErrorDeValidacionException Literal(string mensajeLiteral)
        {
            return new ErrorDeValidacionException(null, mensajeLiteral);
        }
    }
}
