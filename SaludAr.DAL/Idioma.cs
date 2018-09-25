using System.Collections.Generic;

namespace SaludAr.DAL
{
    public interface IIdioma
    {
        IList<BE.Infraestructura.Idioma> ObtenerIdiomasSoportados();
    }

    public class Idioma : IIdioma
    {
        public IList<BE.Infraestructura.Idioma> ObtenerIdiomasSoportados()
        {
            return new List<BE.Infraestructura.Idioma>
            {
                new BE.Infraestructura.Idioma {CodigoIso = "es-AR", Nombre = "Español (Argentina)"},
                new BE.Infraestructura.Idioma {CodigoIso = "en-US", Nombre = "English (United States)"},
            };
        }
    }
}