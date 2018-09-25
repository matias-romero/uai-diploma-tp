using System.Collections.Generic;

namespace SaludAr.BLL.Traductor
{
    /// <summary>
    /// Agrega servicios necesarios para soportar el sistema de traducciones
    /// </summary>
    public interface ITraductorUsuario : ITraductor
    {
        BE.Infraestructura.Idioma IdiomaPreferido { get; set; }
        IList<BE.Infraestructura.Idioma> IdiomasSoportados { get; }
        void Subscribirse(ISubscriptorCambioIdioma nuevoSubscriptor);
        void Desubscribirse(ISubscriptorCambioIdioma subscriptor);
    }
}