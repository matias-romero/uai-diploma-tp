using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SaludAr.DAL.Mappers
{
    internal class PacienteMap : EntityTypeConfiguration<BE.Paciente>
    {
        public PacienteMap()
        {
            this.HasKey(m => m.Id);
            this.Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        }
    }
}