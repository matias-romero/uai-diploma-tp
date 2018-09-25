using SaludAr.DAL.Internal;
using System;
using System.Data.Entity;
using System.Linq;
using RefactorThis.GraphDiff;
using SaludAr.BE.Agenda;
using SaludAr.Services;

namespace SaludAr.DAL
{
    public interface IAgenda
    {
        BE.Agenda.DefinicionAgenda NuevaDefinicionAgenda();
        BE.Agenda.DefinicionAgenda[] Listar();
        void GrabarDefinicion(BE.Agenda.DefinicionAgenda definicionAgenda);
    }

    internal class Agenda : IAgenda
    {
        private DatabaseContext _context;
        public Agenda(DatabaseContext context)
        {
            _context = context;
        }

        public BE.Agenda.DefinicionAgenda NuevaDefinicionAgenda()
        {
            return new BE.Agenda.DefinicionAgenda();
        }

        public BE.Agenda.DefinicionAgenda[] Listar()
        {
            return _context.DefinicionesAgenda
                .Include(da => da.CentroDeSalud)
                .Include(da => da.Especialidad)
                .Include(da => da.Bloques)
                .AsNoTracking()
                .ToArray();
        }

        public void GrabarDefinicion(BE.Agenda.DefinicionAgenda definicionAgenda)
        {
            using (var ctx = _context.Clone())
            {
                var updated = ctx.UpdateGraph(definicionAgenda,
                    map => map.OwnedCollection(da => da.Bloques)
                        .AssociatedEntity(da => da.CentroDeSalud)
                        .AssociatedEntity(da => da.Especialidad));

                ctx.SaveChanges();

                Copiador.CopiarDeManeraSuperficial(updated, definicionAgenda);
            }
        }
    }
}
