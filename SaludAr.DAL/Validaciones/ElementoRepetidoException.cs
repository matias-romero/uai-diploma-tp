using System;

namespace SaludAr.DAL.Validaciones
{
    public class ElementoRepetidoException : Exception
    {
        public object Elemento { get; private set; }
        public string Campo { get; private set; }

        public ElementoRepetidoException(object elemento, string campo, object valor)
            : base(string.Format("Existe otro elemento con el mismo valor en el campo {0} [Valor={1}]", campo, valor))
        {
            Elemento = elemento;
            Campo = campo;
        }
    }
}
