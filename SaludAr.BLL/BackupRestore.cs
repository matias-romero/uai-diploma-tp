using System.Collections.Generic;
using System.Linq;
using SaludAr.BE.Bitacora;
using SaludAr.BE.Infraestructura;

namespace SaludAr.BLL
{
    public interface IBackupRestore
    {
        PuntoDeRestauracion CrearPuntoRestauracion(string nombre);
        IEnumerable<PuntoDeRestauracion> ListarPuntosRestauracion();
        bool VolverAlPuntoDeRestauracion(string nombre);
    }

    public class BackupRestore : IBackupRestore
    {
        private readonly DAL.IBackupRestore _backupRestoreDal;

        public BackupRestore(DAL.IBackupRestore backupRestoreDal)
        {
            _backupRestoreDal = backupRestoreDal;
        }

        public PuntoDeRestauracion CrearPuntoRestauracion(string nombre)
        {
            Bitacora.Default.RegistrarEnBitacora(Evento.AdministradorRealizoUnaCopiaDeSeguridad, Severidad.Advertencia, nombre);
            return _backupRestoreDal.CrearPuntoRestauracion(nombre);
        }

        public IEnumerable<PuntoDeRestauracion> ListarPuntosRestauracion()
        {
            return _backupRestoreDal.ListarPuntosRestauracion().ToList();
        }

        public bool VolverAlPuntoDeRestauracion(string nombre)
        {
            var puntoDeRestauracion = this.ListarPuntosRestauracion().FirstOrDefault(b => b.Nombre.Equals(nombre));
            var restauracion = _backupRestoreDal.Recuperar(puntoDeRestauracion);
            if(restauracion)
                Bitacora.Default.RegistrarEnBitacora(Evento.AdministradorRecuperoBaseDeDatos, Severidad.Critico, nombre);

            return restauracion;
        }
    }
}