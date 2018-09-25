using System.Data.Entity;
using System.Linq;
using RefactorThis.GraphDiff;
using SaludAr.DAL.Internal;
using SaludAr.Services;

namespace SaludAr.DAL
{
    public interface ITurno
    {
        BE.Agenda.Turno[] Listar();
        void Actualizar(BE.Agenda.Turno turno);
    }

    internal class Turno : ITurno
    {
        private readonly DatabaseContext _context;

        public Turno(Internal.DatabaseContext context)
        {
            _context = context;
        }

        public BE.Agenda.Turno[] Listar()
        {
            return _context.Set<BE.Agenda.Turno>()
                .Include(t => t.Paciente)
                .Include(t => t.Profesional)
                .Include(t => t.BloqueAgendaOriginal)
                .AsNoTracking()
                .ToArray();
        }

        public void Actualizar(BE.Agenda.Turno turno)
        {
            _context.UpdateEntityGraph(turno,
                updated => Copiador.CopiarDeManeraSuperficial(updated, turno),
                map => map.AssociatedEntity(t => t.Paciente)
                    .AssociatedEntity(t => t.Profesional)
                    .AssociatedEntity(t => t.BloqueAgendaOriginal));
        }
    }
}
