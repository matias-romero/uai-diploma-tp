using System;
using System.Data.Entity;
using System.Linq;
using SaludAr.DAL.Internal;

namespace SaludAr.DAL
{
    public interface IEspecialidad : IRepositorioABM<BE.Especialidad>
    {
        BE.Especialidad[] Listar();
        BE.Especialidad FindById(Guid id);
    }

    internal class Especialidad : RepositorioABM<BE.Especialidad>, IEspecialidad
    {
        public Especialidad(Internal.DatabaseContext context)
            :base(context)
        {
        }

        public BE.Especialidad FindById(Guid id)
        {
            return this.MyDbSet().AsNoTracking().FirstOrDefault(c => c.Id == id);
        }

        public BE.Especialidad[] Listar()
        {
            return base.ListarPorDefecto();
        }
    }
}
