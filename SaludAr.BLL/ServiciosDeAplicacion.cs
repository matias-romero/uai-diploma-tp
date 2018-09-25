using System;
using SaludAr.BLL.Dependencias;
using SaludAr.BLL.Traductor;

namespace SaludAr.BLL
{
    public interface IServiciosDeAplicacion : IDisposable
    {
        IControlDePatentes ControlDePatentes { get; }
        ITraductorUsuario TraductorUsuario { get; }
        IBitacora Bitacora { get; }
        IUsuario Usuario { get; }
        IEmpleado Empleado { get; }
        IBackupRestore BackupRestore { get; }
        IGestorDePermisos GestorDePermisos { get; }
        ICentroDeSalud CentroDeSalud { get; }
        IEspecialidad Especialidad { get; }
        IAgenda Agenda { get; }
        ITurno Turno { get; }
        IPaciente Paciente { get; }
        IHistoriaClinica HistoriaClinica { get; }
    }

    public class ServiciosDeAplicacion : IServiciosDeAplicacion
    {
        private ConfiguracionGlobal _configuracionGlobal;
        private readonly EnlazadorDeDependencias _enlazadorDeDependencias;

        public ServiciosDeAplicacion(ConfiguracionGlobal configuracion)
        {
            _configuracionGlobal = configuracion;
            _enlazadorDeDependencias = new EnlazadorDeDependencias();
        }

        public IControlDePatentes ControlDePatentes
        {
            get { return _enlazadorDeDependencias.Resolver<IControlDePatentes>(); }
        }

        public IGestorDePermisos GestorDePermisos
        {
            get { return _enlazadorDeDependencias.Resolver<IGestorDePermisos>(); }
        }

        public ITraductorUsuario TraductorUsuario
        {
            get { return _enlazadorDeDependencias.Resolver<ITraductorUsuario>(); }
        }

        public IBitacora Bitacora
        {
            get { return _enlazadorDeDependencias.Resolver<BLL.IBitacora>(); }
        }

        public IBackupRestore BackupRestore
        {
            get { return _enlazadorDeDependencias.Resolver<BLL.IBackupRestore>(); }
        }

        public IUsuario Usuario
        {
            get { return _enlazadorDeDependencias.Resolver<BLL.IUsuario>(); }
        }

        public IEmpleado Empleado
        {
            get { return _enlazadorDeDependencias.Resolver<BLL.IEmpleado>(); }
        }

        public ICentroDeSalud CentroDeSalud
        {
            get { return _enlazadorDeDependencias.Resolver<BLL.ICentroDeSalud>(); }
        }

        public IEspecialidad Especialidad
        {
            get { return _enlazadorDeDependencias.Resolver<BLL.IEspecialidad>(); }
        }

        public IAgenda Agenda
        {
            get{ return _enlazadorDeDependencias.Resolver<BLL.IAgenda>(); }
        }

        public ITurno Turno
        {
            get { return _enlazadorDeDependencias.Resolver<BLL.ITurno>(); }
        }

        public IPaciente Paciente
        {
            get { return _enlazadorDeDependencias.Resolver<BLL.IPaciente>(); }
        }

        public IHistoriaClinica HistoriaClinica
        {
            get { return _enlazadorDeDependencias.Resolver<BLL.IHistoriaClinica>(); }
        }

        public void Dispose()
        {
            _enlazadorDeDependencias?.Dispose();
        }
    }
}