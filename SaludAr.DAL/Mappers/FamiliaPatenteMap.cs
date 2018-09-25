using System;
using System.Data.Entity.ModelConfiguration;

namespace SaludAr.DAL.Mappers
{
    internal class FamiliaPatenteMap : EntityTypeConfiguration<Internal.Auxiliares.FamiliaPatente>
    {
        public FamiliaPatenteMap()
        {
            this.HasKey(fp => new {fp.FamiliaId, fp.PatenteId});

            this.HasRequired(fp => fp.Familia)
                .WithMany()
                .HasForeignKey(fp => fp.FamiliaId);

            this.HasRequired(fp => fp.Patente)
                .WithMany()
                .HasForeignKey(fp => fp.PatenteId);
        }
    }
}