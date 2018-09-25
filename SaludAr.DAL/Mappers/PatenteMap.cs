using System;
using System.Data.Entity.ModelConfiguration;

namespace SaludAr.DAL.Mappers
{
    internal class PatenteMap : EntityTypeConfiguration<BE.Infraestructura.Patente>
    {
        public PatenteMap()
        {
            this.HasKey(m => m.Codigo);

            this.Ignore(m => m.Descripcion);
        }
    }
}