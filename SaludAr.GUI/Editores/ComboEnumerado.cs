using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SaludAr.BE.Infraestructura;

namespace SaludAr.GUI.Editores
{
    public partial class ComboEnumerado : ComboBox
    {
        public ComboEnumerado()
        {
            InitializeComponent();

            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ValueMember = nameof(ValorDeEnumeracion.Valor);
            this.DisplayMember = nameof(ValorDeEnumeracion.Descripcion);
        }

        public void CargarOpciones(IList<ValorDeEnumeracion> valores)
        {
            this.DataSource = null;
            this.DataSource = valores;
        }
    }
}
