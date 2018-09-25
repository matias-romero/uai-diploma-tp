using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SaludAr.DAL.Mappers
{
    internal class HCMap : EntityTypeConfiguration<BE.HistoriaClinica.HC>
    {
        public HCMap()
        {
            this.HasKey(e => e.PacienteId);
            this.Property(e => e.PacienteId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.HasRequired(e => e.Paciente)
                .WithRequiredDependent();
                //.Map(fk=> fk.MapKey("PacienteId"));

            this.HasMany(e => e.Eventos)
                .WithRequired()
                .Map(fk => fk.MapKey("HCId"));
        }
    }
}