using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;

namespace SaludAr.BLL.Traductor
{
    /// <summary>
    /// Implementa el patron "Observador" gestionando los subscriptores y notificando los cambios de idioma
    /// </summary>
    public class TraductorUsuario : ITraductorUsuario
    {
        private BE.Infraestructura.Idioma _idiomaPreferido;

        private readonly DAL.IIdioma _idiomaDal;
        private readonly IList<ISubscriptorCambioIdioma> _subscriptores = new List<ISubscriptorCambioIdioma>();

        public TraductorUsuario()
            : this(new DAL.Idioma())
        {
        }

        public TraductorUsuario(DAL.IIdioma idiomaDal)
        {
            _idiomaDal = idiomaDal;
        }

        public BE.Infraestructura.Idioma IdiomaPreferido
        {
            get { return _idiomaPreferido; }
            set
            {
                _idiomaPreferido = value;
                this.NotificarIdiomaCambiado(_idiomaPreferido);
            }
        }

        public IList<BE.Infraestructura.Idioma> IdiomasSoportados
        {
            get { return _idiomaDal.ObtenerIdiomasSoportados(); }
        }

        public void Subscribirse(ISubscriptorCambioIdioma nuevoSubscriptor)
        {
            _subscriptores.Add(nuevoSubscriptor);
            //Notifico al nuevo subscriptor la configuración actual
            nuevoSubscriptor.IdiomaCambiado(this.IdiomaPreferido);
        }

        public void Desubscribirse(ISubscriptorCambioIdioma subscriptor)
        {
            _subscriptores.Remove(subscriptor);
        }

        public string Traducir(string constanteDeTexto)
        {
            var resourceManager = new ResourceManager("SaludAr.BLL.Traductor.RecursoTemporal", this.GetType().Assembly);
            try
            {
                return resourceManager.GetString(constanteDeTexto, CultureInfo.GetCultureInfo(this.IdiomaPreferido.CodigoIso));
            }
            catch (MissingManifestResourceException ex)
            {
                throw new ConstanteNoEncontradaException(constanteDeTexto, ex);
            }
        }

        public string TraducirConFormato(string constanteDeTexto, params object[] args)
        {
            var traduccion = this.Traducir(constanteDeTexto);
            return string.Format(traduccion, args);
        }

        private void NotificarIdiomaCambiado(BE.Infraestructura.Idioma nuevoIdioma)
        {
            //Notifico a la colección de subscriptores
            lock (_subscriptores)
            {
                foreach (var subscriptor in _subscriptores)
                    subscriptor.IdiomaCambiado(nuevoIdioma);
            }
        }
    }
}