using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SaludAr.DAL.Mappers
{
    internal class EstudioImagenologiaMap : EntityTypeConfiguration<BE.HistoriaClinica.EstudioImagenologia>
    {
        public EstudioImagenologiaMap()
        {
            //Obligo a que se mapee en su propia tabla (TPT con EventoClinico)
            this.ToTable("EstudioImagenologia");

            this.Property(p => p.InformeTecnico)
                .IsRequired();
        }
    }
}