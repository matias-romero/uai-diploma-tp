using System.Data.Entity;
using System.Linq;
using RefactorThis.GraphDiff;
using SaludAr.DAL.Internal;
using SaludAr.Services;

namespace SaludAr.DAL
{
    public interface IHistoriaClinica
    {
        BE.HistoriaClinica.HC Recuperar(BE.Paciente paciente);
        void Actualizar(BE.HistoriaClinica.HC historiaClinica);
    }

    internal class HistoriaClinica : IHistoriaClinica
    {
        private readonly DatabaseContext _context;

        public HistoriaClinica(Internal.DatabaseContext context)
        {
            _context = context;
        }

        public BE.HistoriaClinica.HC Recuperar(BE.Paciente paciente)
        {
            return _context.Set<BE.HistoriaClinica.HC>()
                .Include(hc => hc.Eventos)
                .AsNoTracking()
                .SingleOrDefault(hc => hc.PacienteId == paciente.Id);
        }

        public void Actualizar(BE.HistoriaClinica.HC historiaClinica)
        {
            //Hack para que no detecte la relación como borrada
            historiaClinica.Paciente = historiaClinica.Paciente ?? new BE.Paciente {Id = historiaClinica.PacienteId};
            _context.UpdateEntityGraph(historiaClinica,
                updated => Copiador.CopiarDeManeraSuperficial(updated, historiaClinica),
                map => map.OwnedCollection(hc => hc.Eventos)
                    .AssociatedEntity(hc => hc.Paciente));
        }
    }
}
