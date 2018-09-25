using System;
using System.Data.Entity.ModelConfiguration;

namespace SaludAr.DAL.Mappers
{
    internal class UsuarioMap : EntityTypeConfiguration<BE.Infraestructura.Usuario>
    {
        public UsuarioMap()
        {
            this.HasKey(m => m.Nombre);

            this.Property(m => m.Contraseña)
                .IsRequired();

            this.Ignore(m => m.Permiso);
        }
    }
}