using SaludAr.BE.Infraestructura;

namespace SaludAr.BLL.Traductor
{
    /// <summary>
    /// Representa a un interesado para el servicio de traducciones
    /// </summary>
    public interface ISubscriptorCambioIdioma
    {
        void IdiomaCambiado(Idioma nuevoIdioma);
    }
}