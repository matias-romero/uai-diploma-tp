using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SaludAr.BE.Bitacora;
using SaludAr.BLL.Traductor;
using SaludAr.DAL;

namespace SaludAr.BLL
{
    public interface IBitacora
    {
        BE.Bitacora.Evento[] ObtenerEventosDisponibles(ITraductor traductor);
        IEnumerable<EntradaEnBitacora> ObtenerTodasLasEntradasEnBitacora(ITraductor traductor);
        IEnumerable<EntradaEnBitacora> ObtenerTodasLasEntradasEnBitacora(ITraductor traductor, DateTime desde, DateTime hasta, Evento evento);
        void RegistrarEnBitacora(int tipoEvento, string mensaje);
        void RegistrarEnBitacora(int tipoEvento, Severidad severidad, string mensaje);
        void RegistrarEnBitacora(int tipoEvento, Severidad severidad, string mensaje, BE.Infraestructura.Usuario usuario);
        void RegistrarEnBitacora(EntradaEnBitacora entradaEnBitacora);
    }

    public class Bitacora : IBitacora
    {
        #region "Singleton"
        private static Lazy<IBitacora> _default = new Lazy<IBitacora>(() => new Bitacora(new SqlHelper().NuevaUnidadDeTrabajo().NuevoRepositorio<DAL.IBitacora>())); 

        public static IBitacora Default
        {
            get { return _default.Value; }
        }

        public static void ConfigurarProveedorDeDatosPorDefecto(DAL.IBitacora bitacoraDal)
        {
            _default = new Lazy<IBitacora>(() => new Bitacora(bitacoraDal));
        }
        #endregion

        private readonly DAL.IBitacora _bitacoraDal;

        public Bitacora(DAL.IBitacora bitacoraDal)
        {
            _bitacoraDal = bitacoraDal;
        }

        public Evento[] ObtenerEventosDisponibles(ITraductor traductor)
        {
            var eventos = _bitacoraDal.EventosDisponibles;
            foreach (var evento in eventos)
                evento.Descripcion = this.TraducirEvento(traductor, evento.Descripcion);

            return eventos;
        }

        public IEnumerable<EntradaEnBitacora> ObtenerTodasLasEntradasEnBitacora(ITraductor traductor)
        {
            var entradas = _bitacoraDal.ObtenerTodasLasEntradasEnBitacora()
                .OrderByDescending(b => b.FechaHora)
                .ToList();

            //Realizo la traducción del evento segun el idioma de preferencia
            foreach (var entradaEnBitacora in entradas)
            {
                var eventoId = entradaEnBitacora.Evento.Id;
                var field = typeof(Evento).GetFields(BindingFlags.Public | BindingFlags.Static)
                    .Single(f => (int) f.GetValue(null) == eventoId);

                entradaEnBitacora.Evento.Descripcion = this.TraducirEvento(traductor, field.Name);
            }

            return entradas;
        }

        private string TraducirEvento(ITraductor traductor, string nombreEvento)
        {
            return traductor.Traducir("Evento" + nombreEvento);
        }

        public IEnumerable<EntradaEnBitacora> ObtenerTodasLasEntradasEnBitacora(ITraductor traductor, DateTime desde, DateTime hasta, Evento evento)
        {
            if (evento != null && evento.Id < 0)
                evento = null;

            return this.ObtenerTodasLasEntradasEnBitacora(traductor)
                .Where(l => l.FechaHora >= desde && l.FechaHora <= hasta)
                .Where(l => evento == null || evento.Id.Equals(l.Evento.Id));
        }

        public void RegistrarEnBitacora(int tipoEvento, string mensaje)
        {
            this.RegistrarEnBitacora(tipoEvento, Severidad.Informativo, mensaje);
        }

        public void RegistrarEnBitacora(int tipoEvento, Severidad severidad, string mensaje)
        {
            this.RegistrarEnBitacora(tipoEvento, severidad, mensaje, SessionManager.Instance.UsuarioActual);
        }

        public void RegistrarEnBitacora(int tipoEvento, Severidad severidad, string mensaje, BE.Infraestructura.Usuario usuario)
        {
            var entradaEnBitacora = new EntradaEnBitacora
            {
                Id = Guid.NewGuid(),
                FechaHora = DateTime.Now,
                Evento = new Evento {Id = tipoEvento},
                Severidad = severidad,
                Mensaje = mensaje,
                Usuario = usuario
            };

            this.RegistrarEnBitacora(entradaEnBitacora);
        }

        public void RegistrarEnBitacora(EntradaEnBitacora entradaEnBitacora)
        {
            _bitacoraDal.RegistrarEnBitacora(entradaEnBitacora);
        }
    }
}