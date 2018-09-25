using System;

namespace SaludAr.BE
{
    public class CentroDeSalud
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }

        public override string ToString()
        {
            return this.Nombre ?? base.ToString();
        }
    }
}