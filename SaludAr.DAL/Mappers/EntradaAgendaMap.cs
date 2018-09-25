using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SaludAr.DAL.Mappers
{
    internal class EntradaAgendaMap : EntityTypeConfiguration<BE.Agenda.EntradaAgenda>
    {
        public EntradaAgendaMap()
        {
            this.HasKey(e => e.Id);
            this.Property(e => e.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
