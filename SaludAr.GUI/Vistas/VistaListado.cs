using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

namespace SaludAr.GUI.Vistas
{
    public interface IVistaListado
    {
        string Titulo { get; }
        bool PuedeAgregar { get; }
        bool PuedeEditar { get; }
        bool PuedeBorrar { get; }

        ObservableCollection<object> ListarTodos();
    }

    public abstract class VistaListado<T> : IVistaListado
    {
        public abstract string Titulo { get; }

        public ObservableCollection<T> Listado { get; set; }

        public bool PuedeAgregar { get; set; }
        public bool PuedeEditar { get; set; }
        public bool PuedeBorrar { get; set; }

        ObservableCollection<object> IVistaListado.ListarTodos()
        {
            return this.Listado.Cast<object>().AsObservable();
        }

        public void Refrescar()
        {
            //Actualizo el listado de manera compatible para que se refresquen los controles enlazados
            var reloadedList = this.RecargarListado();
            if (reloadedList != null)
            {
                if (this.Listado == null)
                    this.Listado = reloadedList.AsObservable();
                else
                {
                    this.Listado.Clear();
                    foreach (var item in reloadedList)
                        this.Listado.Add(item);
                }
            }
        }

        protected virtual IEnumerable<T> RecargarListado()
        {
            return null;
        }

        public void HabilitarGestionParaLaEntidad(bool permiso)
        {
            this.PuedeAgregar = permiso;
            this.PuedeEditar = permiso;
            this.PuedeBorrar = permiso;
        }
    }
}
