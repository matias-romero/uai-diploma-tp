using System;
using System.Data.Entity.ModelConfiguration;

namespace SaludAr.DAL.Mappers
{
    internal class UsuarioPermisoMap : EntityTypeConfiguration<Internal.Auxiliares.UsuarioPermiso>
    {
        public UsuarioPermisoMap()
        {
            this.HasKey(up => new {up.UsuarioId, up.FamiliaId});

            this.HasRequired(up => up.Usuario)
                .WithMany()
                .HasForeignKey(up => up.UsuarioId);

            this.HasRequired(up => up.Familia)
                .WithMany()
                .HasForeignKey(up => up.FamiliaId);
        }
    }
}