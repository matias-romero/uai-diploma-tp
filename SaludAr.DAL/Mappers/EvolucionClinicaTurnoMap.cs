using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SaludAr.DAL.Mappers
{
    internal class EvolucionClinicaTurnoMap : EntityTypeConfiguration<BE.HistoriaClinica.EvolucionClinicaTurno>
    {
        public EvolucionClinicaTurnoMap()
        {
            //Obligo a que se mapee en su propia tabla (TPT con EventoClinico)
            this.ToTable("EvolucionClinicaTurno");

            this.Property(p => p.Evolucion)
                .IsRequired();
        }
    }
}