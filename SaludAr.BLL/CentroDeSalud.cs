using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaludAr.BLL.Traductor;

namespace SaludAr.BLL
{
    public interface ICentroDeSalud
    {
        BE.CentroDeSalud[] Listar();
        void Actualizar(BE.CentroDeSalud centroDeSalud);
    }

    public class CentroDeSalud : ICentroDeSalud
    {
        private readonly ITraductorUsuario _traductorUsuario;
        private readonly DAL.ICentroDeSalud _centroDeSaludDal;

        public CentroDeSalud(ITraductorUsuario traductorUsuario, DAL.ICentroDeSalud centroDeSaludDal)
        {
            _traductorUsuario = traductorUsuario;
            _centroDeSaludDal = centroDeSaludDal;
        }

        public BE.CentroDeSalud[] Listar()
        {
            return _centroDeSaludDal.Listar();
        }

        public void Actualizar(BE.CentroDeSalud centroDeSalud)
        {
            _centroDeSaludDal.Actualizar(centroDeSalud);
        }
    }
}
