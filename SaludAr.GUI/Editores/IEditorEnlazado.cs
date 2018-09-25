using System;

namespace SaludAr.GUI.Editores
{
    public interface IEditorEnlazado
    {
        void CargarDesdeModeloAInterfazVisual();
        void GuardarCambiosEnElModelo();
    }
}
