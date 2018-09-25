using System;
using System.Linq;
using System.Collections.Generic;
using SaludAr.BE.Infraestructura;
using System.Data.Entity;
using System.Data;
using System.Data.SqlClient;

namespace SaludAr.DAL
{
    public interface IBackupRestore
    {
        PuntoDeRestauracion CrearPuntoRestauracion(string nombre);
        IEnumerable<PuntoDeRestauracion> ListarPuntosRestauracion();
        bool Recuperar(PuntoDeRestauracion copiaDeSeguridad);
    }

    internal class BackupRestore : IBackupRestore
    {
        private class SqlServerBackupManager
        {
            private readonly string _databaseName;
            private readonly Database _currentDatabase;
            private readonly IDbConnection _masterDbConnection;

            public SqlServerBackupManager(DbContext context)
            {
                _currentDatabase = context.Database;
                _currentDatabase.Connection.Open();
                _databaseName = _currentDatabase.Connection.Database;
                _currentDatabase.Connection.Close();

                //Cambio a la master asociada
                var cnnStringBuilder = new SqlConnectionStringBuilder(_currentDatabase.Connection.ConnectionString)
                {
                    AttachDBFilename = "",
                    InitialCatalog = "master"
                };
                var masterCnnString = cnnStringBuilder.ToString();
                _masterDbConnection = new SqlConnection(masterCnnString);
            }

            public bool Backup(string name)
            {
                var sql = string.Format("BACKUP DATABASE [{0}] TO DISK = '{1}_{2:yyyyMMddhhmmss}.bak'", _databaseName, name, DateTime.Now);
                _currentDatabase.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, sql);
                return true;
            }

            public bool Restore(string name)
            {
                _masterDbConnection.Open();
                try
                {
                    var sql = string.Format("ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; RESTORE DATABASE [{0}] FROM DISK = '{1}' WITH RECOVERY, REPLACE", _databaseName, name);
                    var command = _masterDbConnection.CreateCommand();
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (_masterDbConnection.State != ConnectionState.Closed)
                        _masterDbConnection.Close();
                }

                return true;
            }

            public IList<string> GetAvailableBackups()
            {
                string sql;
                using (var stream = this.GetType().Assembly.GetManifestResourceStream(this.GetType(), "Scripts.ListAvailableBackups.sql"))
                    sql = new System.IO.StreamReader(stream).ReadToEnd();

                var backupSetInfos = _currentDatabase.SqlQuery<BackupSetInfo>(sql).ToArray();
                return backupSetInfos.Select(b => b.physical_device_name).ToList();
            }

            private class BackupSetInfo
            {
                public string Server { get; set; }
                public string physical_device_name { get; set; }
            }

        }

        private SqlServerBackupManager _backupManager;

        public BackupRestore(Internal.DatabaseContext contexto)
        {
            _backupManager = new DAL.BackupRestore.SqlServerBackupManager(contexto);
        }

        public PuntoDeRestauracion CrearPuntoRestauracion(string nombre)
        {
            var backup = _backupManager.Backup(nombre);
            return new PuntoDeRestauracion {Fecha = DateTime.Now, RutaDelArchivo = nombre + ".bak", Nombre = nombre};
        }

        public IEnumerable<PuntoDeRestauracion> ListarPuntosRestauracion()
        {
            return _backupManager.GetAvailableBackups().Select(b => new PuntoDeRestauracion
            {
                Fecha = DateTime.Now,
                Nombre = b,
                RutaDelArchivo = b
            });
        }

        public bool Recuperar(PuntoDeRestauracion copiaDeSeguridad)
        {
            return _backupManager.Restore(copiaDeSeguridad.Nombre);
        }
    }
}