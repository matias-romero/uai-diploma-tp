namespace SaludAr.DAL.Internal.Auxiliares
{
    internal class UsuarioPermiso
    {
        public string UsuarioId { get; set; }
        public BE.Infraestructura.Usuario Usuario { get; set; }
        public string FamiliaId { get; set; }
        public BE.Infraestructura.Familia Familia { get; set; }
    }
}
