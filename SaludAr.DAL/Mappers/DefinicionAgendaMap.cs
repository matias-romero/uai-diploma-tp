using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SaludAr.DAL.Mappers
{
    internal class DefinicionAgendaMap : EntityTypeConfiguration<BE.Agenda.DefinicionAgenda>
    {
        public DefinicionAgendaMap()
        {
            this.HasKey(e => e.Id);
            this.Property(e => e.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.HasRequired(e => e.Especialidad)
                .WithMany();

            this.HasRequired(e => e.CentroDeSalud)
                .WithMany();

            this.Property(e => e.Desde)
                .HasColumnType("datetime2");

            this.Property(e => e.Hasta)
                .HasColumnType("datetime2");

            this.HasMany(e => e.Bloques)
                .WithRequired();
        }
    }
}
