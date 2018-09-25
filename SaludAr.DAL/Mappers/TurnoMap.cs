using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SaludAr.DAL.Mappers
{
    internal class TurnoMap : EntityTypeConfiguration<BE.Agenda.Turno>
    {
        public TurnoMap()
        {
            this.HasKey(c => c.Id);
            this.Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.HasRequired(t => t.Paciente)
                .WithMany();

            this.HasRequired(t => t.BloqueAgendaOriginal)
                .WithMany();

            this.HasOptional(t => t.Profesional)
                .WithMany();

            this.Property(t => t.FechaHora)
                .HasColumnType("datetime2");
        }
    }
}
