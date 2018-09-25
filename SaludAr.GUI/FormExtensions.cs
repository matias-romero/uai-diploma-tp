using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Windows.Forms;
using SaludAr.BLL.Traductor;

namespace SaludAr.GUI
{
    /// <summary>
    /// Ofrece métodos de extension para algunas cuestiones repetitivas de la interfaz visual
    /// </summary>
    public static class FormExtensions
    {
        public static void EnlazarmeConServiciosDeTraduccion(this Form thisForm, ITraductorUsuario traductorUsuario)
        {
            var subscriptorCambioIdioma = thisForm as ISubscriptorCambioIdioma;
            if (subscriptorCambioIdioma == null)
                throw new ApplicationException(string.Format(
                    "El formulario {0} debe implementar {1} para ser compatible con traducciones", thisForm.Name,
                    typeof(ISubscriptorCambioIdioma).Name));

            traductorUsuario.Subscribirse(subscriptorCambioIdioma);
            thisForm.FormClosing += (sender, args) => traductorUsuario.Desubscribirse(subscriptorCambioIdioma);
        }

        public static DialogResult MostrarDialogoInformacion(this Form thisForm, ITraductor traductor, string constanteDeTexto)
        {
            return MostrarDialogo(thisForm, traductor, constanteDeTexto, MessageBoxIcon.Information);
        }

        public static DialogResult MostrarDialogoInformacionFormateado(this Form thisForm, ITraductor traductor, string constanteDeTextoFormat, params object[] args)
        {
            return MostrarDialogo(thisForm, traductor.TraducirConFormato(constanteDeTextoFormat, args), MessageBoxIcon.Information);
        }

        public static DialogResult MostrarDialogoAdvertencia(this Form thisForm, ITraductor traductor, string constanteDeTexto)
        {
            return MostrarDialogo(thisForm, traductor, constanteDeTexto, MessageBoxIcon.Warning);
        }

        public static DialogResult MostrarDialogoError(this Form thisForm, ITraductor traductor, ErrorDeValidacionException excepcion)
        {
            return MostrarDialogo(thisForm, excepcion.TraducirMensaje(traductor), MessageBoxIcon.Error);
        }

        public static DialogResult MostrarDialogoError(this Form thisForm, ITraductor traductor, string constanteDeTexto)
        {
            return MostrarDialogo(thisForm, traductor, constanteDeTexto, MessageBoxIcon.Error);
        }

        private static DialogResult MostrarDialogo(Form thisForm, ITraductor traductor, string constanteDeTexto, MessageBoxIcon icono)
        {
            return MostrarDialogo(thisForm, traductor.Traducir(constanteDeTexto), icono);
        }

        private static DialogResult MostrarDialogo(Form thisForm, string textoTraducido, MessageBoxIcon icono)
        {
            return MessageBox.Show(thisForm, textoTraducido, thisForm.Text, MessageBoxButtons.OK, icono);
        }

        public static System.Collections.ObjectModel.ObservableCollection<T> AsObservable<T>(this System.Collections.Generic.IEnumerable<T> thisEnumerable)
        {
            return new System.Collections.ObjectModel.ObservableCollection<T>(thisEnumerable);
        }

        public static void EnlazarListado<T>(this ListControl thisControl, IEnumerable<T> dataSource, string displayMember, string valueMember)
        {
            thisControl.DataSource = null;
            thisControl.DisplayMember = displayMember;
            thisControl.ValueMember = valueMember;
            thisControl.DataSource = dataSource.AsObservable();
        }

        #region "DateTimePicker Extensions"

        public static void ConfigurarSoloHora(this DateTimePicker thisControl)
        {
            thisControl.Format = DateTimePickerFormat.Custom;
            thisControl.CustomFormat = "HH:mm";
            thisControl.ShowUpDown = true;
        }

        public static void ConfigurarFormatoFechaHora(this DateTimePicker thisControl)
        {
            thisControl.Format = DateTimePickerFormat.Custom;
            thisControl.CustomFormat = "yyyy-MM-dd HH:mm";
            thisControl.ShowUpDown = true;
        }

        public static void EstablecerValorEntreElRangoPermitido(this DateTimePicker thisControl, DateTime value)
        {
            if (value < thisControl.MinDate)
                thisControl.Value = thisControl.MinDate;
            else if (value > thisControl.MaxDate)
                thisControl.Value = thisControl.MaxDate;
            else
                thisControl.Value = value;
        }

        #endregion
    }
}