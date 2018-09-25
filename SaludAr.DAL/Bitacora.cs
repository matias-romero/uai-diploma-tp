using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using RefactorThis.GraphDiff;
using SaludAr.BE.Bitacora;
using SaludAr.DAL.Internal;

namespace SaludAr.DAL
{
    public interface IBitacora
    {
        Evento[] EventosDisponibles { get; }
        IEnumerable<EntradaEnBitacora> ObtenerTodasLasEntradasEnBitacora();
        void RegistrarEnBitacora(EntradaEnBitacora entradaEnBitacora);
    }

    internal class Bitacora : IBitacora
    {
        private readonly DatabaseContext _context;

        public Bitacora(Internal.DatabaseContext context)
        {
            _context = context;
        }

        public Evento[] EventosDisponibles
        {
            get
            {
                //Enumero por reflexión los tipos de eventos disponibles en el sistema
                var camposDeEvento = typeof(Evento).GetFields();
                return camposDeEvento
                    .Select(campo => new Evento
                    {
                        Id = (int)campo.GetRawConstantValue(),
                        Descripcion = campo.Name
                    })
                    .ToArray();

            }
        }

        public IEnumerable<EntradaEnBitacora> ObtenerTodasLasEntradasEnBitacora()
        {
            return _context.Set<EntradaEnBitacora>()
                .Include(e => e.Evento)
                .Include(e => e.Usuario)
                .AsNoTracking()
                .ToList();
        }

        public void RegistrarEnBitacora(EntradaEnBitacora entradaEnBitacora)
        {
            _context.UpdateEntityGraph(entradaEnBitacora,
                updated => entradaEnBitacora.Id = updated.Id, 
                map => map.AssociatedEntity(e => e.Evento)
                    .AssociatedEntity(e => e.Usuario));
        }
    }
}
