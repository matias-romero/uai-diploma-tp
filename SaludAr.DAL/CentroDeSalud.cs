using System;
using System.Data.Entity;
using System.Linq;
using SaludAr.DAL.Internal;

namespace SaludAr.DAL
{
    public interface ICentroDeSalud : IRepositorioABM<BE.CentroDeSalud>
    {
        BE.CentroDeSalud[] Listar();
        BE.CentroDeSalud BuscarPorId(Guid id);
    }

    internal class CentroDeSalud : RepositorioABM<BE.CentroDeSalud>, ICentroDeSalud
    {
        public CentroDeSalud(Internal.DatabaseContext context)
            : base(context)
        {
        }

        public BE.CentroDeSalud BuscarPorId(Guid id)
        {
            return this.MyDbSet().AsNoTracking().FirstOrDefault(c => c.Id == id);
        }

        public BE.CentroDeSalud[] Listar()
        {
            return base.ListarPorDefecto();
        }
    }
}
