using System.Data.Entity;
using System.Linq;
using RefactorThis.GraphDiff;
using SaludAr.DAL.Internal;

namespace SaludAr.DAL
{
    public interface IProfesional
    {
        BE.Empleados.Profesional[] Listar();
        void Actualizar(BE.Empleados.Profesional profesional);
    }

    internal class Profesional : IProfesional
    {
        private readonly DatabaseContext _context;

        public Profesional(Internal.DatabaseContext context)
        {
            _context = context;
        }

        public BE.Empleados.Profesional[] Listar()
        {
            return _context.Set<BE.Empleados.Profesional>()
                .Include(p => p.Especialidades)
                .AsNoTracking()
                .ToArray();
        }

        public void Actualizar(BE.Empleados.Profesional profesional)
        {
            _context.UpdateEntityGraph(profesional,
                updated => profesional.Id = updated.Id,
                map => map.AssociatedCollection(p => p.Especialidades));
        }
    }
}
