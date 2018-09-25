using System;

namespace SaludAr.DAL.Internal.Auxiliares
{
    internal class FamiliaPatente
    {
        public string FamiliaId { get; set; }
        public BE.Infraestructura.Familia Familia { get; set; }

        public string PatenteId { get; set; }
        public BE.Infraestructura.Patente Patente { get; set; }
    }
}
