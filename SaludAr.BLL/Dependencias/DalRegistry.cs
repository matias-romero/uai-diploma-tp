using System;
using SaludAr.DAL;
using StructureMap;

namespace SaludAr.BLL.Dependencias
{
    internal class DalRegistry : Registry
    {
        public DalRegistry()
        {
            this.Scan(x =>
            {
                x.AssemblyContainingType<DAL.SqlHelper>();
                x.WithDefaultConventions();
            });

            SqlHelper.ConfigurarPorDefecto(ConfiguracionGlobal.Instance.CadenaDeConexionParaAccesoDatos);
            this.DefaultDataAccess<DAL.IPermiso>();
            this.DefaultDataAccess<DAL.IUsuario>();
            this.DefaultDataAccess<DAL.IEmpleado>();
            this.DefaultDataAccess<DAL.IProfesional>();
            this.DefaultDataAccess<DAL.IBackupRestore>();
            this.DefaultDataAccess<DAL.ICentroDeSalud>();
            this.DefaultDataAccess<DAL.IEspecialidad>();
            this.DefaultDataAccess<DAL.IAgenda>();
            this.DefaultDataAccess<DAL.IPaciente>();
            this.DefaultDataAccess<DAL.IHistoriaClinica>();
            this.DefaultDataAccess<DAL.ITurno>();
        }

        private void DefaultDataAccess<T>()
        {
            this.For<T>()
                .Use(ctx => ctx.GetInstance<DAL.SqlHelper>().NuevaUnidadDeTrabajo().NuevoRepositorio<T>());
        }
    }
}
