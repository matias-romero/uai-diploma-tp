using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SaludAr.DAL.Mappers
{
    internal class EventoMap : EntityTypeConfiguration<BE.Bitacora.Evento>
    {
        public EventoMap()
        {
            this.HasKey(e => e.Id);
            this.Property(e => e.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Ignore(e => e.Descripcion);
        }
    }
}
