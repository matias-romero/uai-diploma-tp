using System.Data.Entity.ModelConfiguration;

namespace SaludAr.DAL.Mappers
{
    internal class EntradaEnBitacoraMap : EntityTypeConfiguration<BE.Bitacora.EntradaEnBitacora>
    {
        public EntradaEnBitacoraMap()
        {
            this.HasKey(b => b.Id);

            this.HasRequired(b => b.Evento)
                .WithMany();

            this.HasOptional(b => b.Usuario)
                .WithMany();
        }
    }
}
