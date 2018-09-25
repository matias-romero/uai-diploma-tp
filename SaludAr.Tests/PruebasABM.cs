using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SaludAr.BE.Empleados;
using SaludAr.DAL;

namespace SaludAr.Tests
{
    [TestClass]
    public class PruebasABM
    {
        private static SqlHelper Sql = new SqlHelper();

        static PruebasABM()
        {
            var cnnString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SaludArDbTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //var cnnString = "Server=.\\SQL_UAI;Database=SaludArDb;Trusted_Connection=True;";
            SqlHelper.ConfigurarPorDefecto(cnnString);
            SqlHelper.EliminarBaseDeDatosSiExiste();
        }

        public static IUnidadDeTrabajo ResolverUnidadDeTrabajo()
        {
            return Sql.NuevaUnidadDeTrabajo();
        }

        [TestMethod]
        public void PruebaFactoriaDeRepositoriosDesdeUnidadDeTrabajo()
        {
            var unidadDeTrabajo = Sql.NuevaUnidadDeTrabajo();
        }

        [TestMethod]
        public void PruebaAltaEmpleado()
        {
            var unidadDeTrabajo = ResolverUnidadDeTrabajo();
            var empleadoDal = unidadDeTrabajo.NuevoRepositorio<DAL.IEmpleado>();

            var nuevoEmpleado = empleadoDal.CrearNuevo();
            nuevoEmpleado.Apellido = "Romero";
            nuevoEmpleado.Nombre = "Matias";
            nuevoEmpleado.NroLegajo = 123456;
            nuevoEmpleado.Sexo = Sexo.Masculino;
            nuevoEmpleado.Telefono = "5401155555555";

            empleadoDal.Actualizar(nuevoEmpleado);

            var empleadoGrabado = empleadoDal.BuscarPorId(nuevoEmpleado.Id);
            Assert.IsNotNull(empleadoGrabado);
            Assert.AreNotSame(empleadoGrabado, nuevoEmpleado, "No debe utilizar cache de objetos en modo desconectado");
            Assert.AreEqual(nuevoEmpleado.Apellido, empleadoGrabado.Apellido);
            Assert.AreEqual(nuevoEmpleado.Nombre, empleadoGrabado.Nombre);
        }

        [TestMethod]
        public void PruebaABMCentrosDeSalud()
        {
            var unidadDeTrabajo = ResolverUnidadDeTrabajo();
            var centroDeSaludDal = unidadDeTrabajo.NuevoRepositorio<DAL.ICentroDeSalud>();

            var centroDeSalud = centroDeSaludDal.CrearNuevo();
            centroDeSalud.Nombre = "Hospital Central";

            centroDeSaludDal.Actualizar(centroDeSalud);

            var centroDeSaludGrabado = centroDeSaludDal.BuscarPorId(centroDeSalud.Id);
            Assert.AreNotSame(centroDeSalud, centroDeSaludGrabado, "No debe utilizar cache de objetos en modo desconectado");
            Assert.AreEqual(centroDeSalud.Nombre, centroDeSaludGrabado.Nombre);
        }
    }
}