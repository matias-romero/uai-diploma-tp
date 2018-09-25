using System;

namespace SaludAr.BLL
{
    public interface IEspecialidad
    {
        BE.Especialidad[] Listar();
        void Actualizar(BE.Especialidad especialidad);
    }

    public class Especialidad : IEspecialidad
    {
        private readonly DAL.IEspecialidad _especialidadDal;

        public Especialidad(DAL.IEspecialidad especialidadDal)
        {
            _especialidadDal = especialidadDal;
        }

        public BE.Especialidad[] Listar()
        {
            return _especialidadDal.Listar();
        }

        public void Actualizar(BE.Especialidad especialidad)
        {
            _especialidadDal.Actualizar(especialidad);
        }
    }
}
