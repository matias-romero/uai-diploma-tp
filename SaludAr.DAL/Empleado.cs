using System;
using System.Data.Entity;
using System.Linq;
using RefactorThis.GraphDiff;
using SaludAr.DAL.Internal;
using SaludAr.Services;

namespace SaludAr.DAL
{
    public interface IEmpleado
    {
        BE.Empleados.Empleado BuscarPorId(Guid id);
        BE.Empleados.Empleado BuscarPorNombreUsuarioRelacionado(string nombreUsuario);
        BE.Empleados.Empleado CrearNuevo();
        void Actualizar(BE.Empleados.Empleado empleado);
        BE.Empleados.Empleado[] Listar();
        bool ExisteLegajo(BE.Empleados.Empleado empleado);
    }

    internal class Empleado : RepositorioABM<BE.Empleados.Empleado>, IEmpleado
    {
        public Empleado(Internal.DatabaseContext contexto)
            : base(contexto)
        {
        }

        public new BE.Empleados.Empleado[] Listar()
        {
            return this.MyDbSet()
                .Include(e => e.CredencialUsuario)
                .AsNoTracking()
                .ToArray();
        }

        public BE.Empleados.Empleado BuscarPorId(Guid id)
        {
            return this.MyDbSet()
                .Include(e => e.CredencialUsuario)
                .AsNoTracking()
                .FirstOrDefault(e => e.Id == id);
        }

        public BE.Empleados.Empleado BuscarPorNombreUsuarioRelacionado(string nombreUsuario)
        {
            return this.MyDbSet()
                .Include(e => e.CredencialUsuario)
                .AsNoTracking()
                .FirstOrDefault(e => e.CredencialUsuario.Nombre == nombreUsuario);
        }

        public bool ExisteLegajo(BE.Empleados.Empleado empleado)
        {
            return this.MyDbSet().Any(e => e.NroLegajo == empleado.NroLegajo && e.Id != empleado.Id);
        }

        protected override void DoEntityUpdate(DatabaseContext ctx, BE.Empleados.Empleado entidad)
        {
            ctx.UpdateEntityGraph(entidad,
                updated => Copiador.CopiarDeManeraSuperficial(updated, entidad),
                map => map.AssociatedEntity(e => e.CredencialUsuario));
        }
    }
}