using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SaludAr.DAL.Mappers
{
    internal class DigitoVerificadorVerticalMap : EntityTypeConfiguration<BE.Seguridad.DigitoVerificadorVertical>
    {
        public DigitoVerificadorVerticalMap()
        {
            this.HasKey(l => l.Entidad);
            this.Property(l => l.Entidad)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
