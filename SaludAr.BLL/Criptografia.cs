using System;
using SaludAr.Services.Crypto;

namespace SaludAr.BLL
{
    /// <summary>
    /// Ofrece un punto de acceso a los servicios de criptografía desde la BLL
    /// </summary>
    public class Criptografia : ICriptografia
    {
        private readonly CSP _csp;
        private static Criptografia _default;

        public static Criptografia Default
        {
            get
            {
                if (_default == null)
                    throw new InvalidOperationException("Debe configurar un servicio por defecto antes de utilizar esta funcionalidad");

                return _default;
            }
            set { _default = value; }
        }

        public Criptografia(string base64SaltKey)
        {
            _csp = new CSP(base64SaltKey);
        }

        public string Encriptar(string textoPlano)
        {
            var bytes = _csp.EncryptString(textoPlano);
            return Convert.ToBase64String(bytes);
        }

        public string Desencriptar(string textoCifrado)
        {
            var bytes = Convert.FromBase64String(textoCifrado);
            return _csp.DecryptString(bytes);
        }
    }
}