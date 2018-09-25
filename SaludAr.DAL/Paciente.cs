using System.Linq;

namespace SaludAr.DAL
{
    public interface IPaciente
    {
        void Actualizar(BE.Paciente paciente);
        void Eliminar(BE.Paciente paciente);
        BE.Paciente[] Listar();
    }

    internal class Paciente : IPaciente
    {
        private readonly Internal.DatabaseContext _contexto;

        public Paciente(Internal.DatabaseContext contexto)
        {
            _contexto = contexto;
        }

        public void Actualizar(BE.Paciente paciente)
        {
            _contexto.UpdateEntity(paciente, true);
        }

        public void Eliminar(BE.Paciente paciente)
        {
            _contexto.DeleteEntity(paciente);
        }

        public BE.Paciente[] Listar()
        {
            return _contexto.Set<BE.Paciente>()
                .AsNoTracking()
                .ToArray();
        }
    }
}
