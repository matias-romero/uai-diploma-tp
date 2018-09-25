using System;
using System.Collections.Generic;

namespace SaludAr.BE.Agenda
{
    public class EntradaAgenda
    {
        public int Id { get; set; }

        public DiaSemana DiaSemana { get; set; }
        public TimeSpan Duracion { get; set; }

        public DateTime InicioBloque { get; set; }
        public DateTime FinBloque { get; set; }

        public IEnumerable<SlotDeAgenda> ObtenerBloquesAsignables()
        {
            var inicioSlot = this.InicioBloque;
            do
            {
                var finSlot = inicioSlot.Add(this.Duracion);
                var nuevoSlot = new SlotDeAgenda
                {
                    Horario = inicioSlot,
                    Duracion = this.Duracion,
                    Disponible = true,

                };
                yield return nuevoSlot;
                inicioSlot = finSlot;
            } while (inicioSlot < this.FinBloque);
        }
    }
}
