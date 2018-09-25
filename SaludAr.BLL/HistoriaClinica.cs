using System.Collections.Generic;
using SaludAr.BE.HistoriaClinica;

namespace SaludAr.BLL
{
    public interface IHistoriaClinica
    {
        HC Recuperar(BE.Paciente paciente);
        void Actualizar(HC historiaClinica);
    }

    public class HistoriaClinica : IHistoriaClinica
    {
        private readonly DAL.IHistoriaClinica _historiaClinicaDal;

        public HistoriaClinica(DAL.IHistoriaClinica historiaClinicaDal)
        {
            _historiaClinicaDal = historiaClinicaDal;
        }

        public HC Recuperar(BE.Paciente paciente)
        {
            var hc = _historiaClinicaDal.Recuperar(paciente);
            if (hc == null)
            {
                hc = new HC
                {
                    Paciente = paciente,
                    PacienteId = paciente.Id,
                    Eventos = new List<EventoClinico>()
                };
            }

            return hc;
        }

        public void Actualizar(HC historiaClinica)
        {
            _historiaClinicaDal.Actualizar(historiaClinica);
        }
    }
}
