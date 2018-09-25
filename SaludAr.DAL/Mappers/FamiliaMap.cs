using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace SaludAr.DAL.Mappers
{
    public class FamiliaMap : EntityTypeConfiguration<BE.Infraestructura.Familia>
    {
        public FamiliaMap()
        {
            this.HasKey(f => f.Codigo);

            this.Property(f => f.Descripcion)
                .IsRequired();

            this.Ignore(f => f.Permisos);

            //this.HasIndex(f => f.Descripcion)
            //    .IsUnique();
        }
    }
}
