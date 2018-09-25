using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using SaludAr.BE.Infraestructura;
using SaludAr.BLL;
using SaludAr.BLL.Traductor;

namespace SaludAr.GUI
{
    public partial class frmGestionDePermisos : Form, ISubscriptorCambioIdioma
    {
        private readonly ITraductorUsuario _traductorUsuario;
        private readonly IGestorDePermisos _gestorDePermisos;

        public frmGestionDePermisos(IServiciosDeAplicacion serviciosDeAplicacion)
        {
            InitializeComponent();

            _traductorUsuario = serviciosDeAplicacion.TraductorUsuario;
            this.EnlazarmeConServiciosDeTraduccion(_traductorUsuario);

            _gestorDePermisos = serviciosDeAplicacion.GestorDePermisos;
            this.cboPerfil.EnlazarListado(_gestorDePermisos.ListarFamilias(), nameof(Familia.Descripcion), nameof(Familia.Codigo));
        }

        void ISubscriptorCambioIdioma.IdiomaCambiado(Idioma nuevoIdioma)
        {
            this.Text = _traductorUsuario.Traducir(ConstantesDeTexto.MenuOpciones);
            this.btnGuardar.Text = _traductorUsuario.Traducir(ConstantesDeTexto.BotonGuardar);
        }

        private void cboPerfil_SelectedValueChanged(object sender, EventArgs e)
        {
            this.btnGuardar.Enabled = false;
            var familiaSeleccionada = ObtenerFamiliaSeleccionada();
            if (familiaSeleccionada != null)
            {
                this.checkedListBoxPermisos.DataSource = null;
                this.checkedListBoxPermisos.DataSource = _gestorDePermisos.PatentesDisponibles;

                var index = 0;
                var items = this.checkedListBoxPermisos.Items.Cast<Patente>().ToArray();
                foreach (var item in items)
                {
                    if (familiaSeleccionada.ConcederAcceso(item.Codigo))
                        this.checkedListBoxPermisos.SetItemChecked(index, true);

                    index++;
                }

                this.btnGuardar.Enabled = true;
            }
        }

        private Familia ObtenerFamiliaSeleccionada()
        {
            return (Familia) this.cboPerfil.SelectedItem;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var nombre = Prompt.ShowDialog("", _traductorUsuario.Traducir(ConstantesDeTexto.IngreseNuevoNombreParaElPerfil));
                if (!string.IsNullOrWhiteSpace(nombre))
                {
                    var nuevaFamilia = _gestorDePermisos.NuevaFamilia(nombre);
                    _gestorDePermisos.Actualizar(nuevaFamilia);
                    (this.cboPerfil.DataSource as ObservableCollection<BE.Infraestructura.Familia>).Add(nuevaFamilia);
                }
            }
            catch (Exception ex)
            {
                //TODO: Revisar que sea la exception concreta
                this.MostrarDialogoAdvertencia(_traductorUsuario, ConstantesDeTexto.ErrorElementoRepetido);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var familiaSeleccionada = this.ObtenerFamiliaSeleccionada();
            familiaSeleccionada.Permisos.Clear();

            var patentesEnlazadas = this.checkedListBoxPermisos.CheckedItems.Cast<Patente>();
            foreach (var patenteEnlazada in patentesEnlazadas)
                familiaSeleccionada.Permisos.Add(patenteEnlazada);
            
            _gestorDePermisos.Actualizar(familiaSeleccionada);
        }
    }
}
