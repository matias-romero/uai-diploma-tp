using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SaludAr.DAL.Mappers
{
    internal class ProfesionalMap : EntityTypeConfiguration<BE.Empleados.Profesional>
    {
        public ProfesionalMap()
        {
            //Obligo a que se mapee en su propia tabla (TPT con Empleado)
            this.ToTable("Profesional");

            this.Property(p => p.CodMatricula)
                .IsRequired();

            this.HasMany(p => p.Especialidades)
                .WithMany();
        }
    }
}