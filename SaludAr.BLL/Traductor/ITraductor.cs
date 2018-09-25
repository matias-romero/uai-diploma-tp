namespace SaludAr.BLL.Traductor
{
    /// <summary>
    /// Ofrece los servicios necesarios para la traducción de Constantes de texto
    /// </summary>
    public interface ITraductor
    {
        string Traducir(string constanteDeTexto);
        string TraducirConFormato(string constanteDeTexto, params object[] args);
    }
}