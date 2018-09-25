using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SaludAr.DAL.Mappers
{
    internal class EstudioLaboratorioMap : EntityTypeConfiguration<BE.HistoriaClinica.EstudioLaboratorio>
    {
        public EstudioLaboratorioMap()
        {
            //Obligo a que se mapee en su propia tabla (TPT con EventoClinico)
            this.ToTable("EstudioLaboratorio");

            this.Property(p => p.NroProtocolo)
                .IsRequired();
        }
    }
}