using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SaludAr.DAL.Mappers
{
    internal class EmpleadoMap : EntityTypeConfiguration<BE.Empleados.Empleado>
    {
        public EmpleadoMap()
        {
            this.HasKey(e => e.Id);
            this.Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //this.Map(e => e.ToTable("Empleado"));

            this.HasOptional(e => e.CredencialUsuario)
                .WithOptionalPrincipal();
        }
    }
}