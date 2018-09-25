using System;

namespace SaludAr.Services.Crypto
{
    public interface ICriptografia
    {
        string Encriptar(string textoPlano);
        string Desencriptar(string textoCifrado);
    }
}
