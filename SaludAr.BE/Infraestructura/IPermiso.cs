namespace SaludAr.BE.Infraestructura
{
    /// <summary>
    /// Modela un permiso genérico del sistema
    /// </summary>
    public interface IPermiso
    {
        string Codigo { get; }
        string Descripcion { get; }
        bool ConcederAcceso(string codigoPermiso);
    }
}