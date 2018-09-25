using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SaludAr.DAL.Mappers
{
    internal class EventoClinicoMap : EntityTypeConfiguration<BE.HistoriaClinica.EventoClinico>
    {
        public EventoClinicoMap()
        {
            this.HasKey(e => e.Id);
            this.Property(e => e.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}