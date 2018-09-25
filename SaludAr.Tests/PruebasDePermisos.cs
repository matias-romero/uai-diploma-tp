using System;
using System.Linq;
using AutoMoq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SaludAr.BE.Infraestructura;
using SaludAr.BLL;
using SaludAr.BLL.Traductor;
using SaludAr.DAL;
using IPermiso = SaludAr.DAL.IPermiso;

namespace SaludAr.Tests
{
    [TestClass]
    public class PruebasDePermisos
    {
        private AutoMoqer _autoMoqer;
        private IUnidadDeTrabajo _unidadDeTrabajo;

        [TestInitialize]
        public void Setup()
        {
            _autoMoqer = new AutoMoqer();
            _autoMoqer.GetMock<ITraductorUsuario>()
                .Setup(t => t.Traducir(It.IsAny<string>()))
                .Returns<string>(key => key);

            _unidadDeTrabajo = PruebasABM.ResolverUnidadDeTrabajo();
        }

        [TestMethod]
        public void EnumerarPermisosDisponiblesDelSistema()
        {
            //ARRANGE
            _autoMoqer.GetMock<DAL.IPermiso>()
                .Setup(p => p.PatentesExistentes)
                .Returns(_unidadDeTrabajo.NuevoRepositorio<IPermiso>().PatentesExistentes);

            var gestorDePermisos = _autoMoqer.Resolve<GestorDePermisos>();
            
            //ACT
            var permisosDisponibles = gestorDePermisos.PatentesDisponibles;

            //ASSERT
            Assert.AreEqual(23, permisosDisponibles.Length);
            Assert.IsTrue(permisosDisponibles.All(p => !string.IsNullOrEmpty(p.Descripcion)), "No realizó la traducción de las patentes");
        }

        [TestMethod]
        public void EnumerarFamiliasPorDefecto()
        {
            //ARRANGE
            var permisoDal = _unidadDeTrabajo.NuevoRepositorio<IPermiso>();

            //ACT
            var familiasPorDefecto = permisoDal.FamiliasPorDefecto;

            //ASSERT
            Assert.AreEqual(familiasPorDefecto.Any(f => f.Codigo == "SUPER") ? 6 : 5, familiasPorDefecto.Length);
            Assert.IsTrue(familiasPorDefecto.All(p => !string.IsNullOrEmpty(p.Descripcion)), "No se cargó la descripción de alguna familia por defecto");
        }

        [TestMethod]
        public void PruebaCrearNuevasFamilias()
        {
            //ARRANGE
            const string familiaDePrueba = "Familia de Prueba";
            var permisoDal = _unidadDeTrabajo.NuevoRepositorio<DAL.IPermiso>();
            var gestorPermisos = new BLL.GestorDePermisos(_autoMoqer.Resolve<ITraductorUsuario>(), permisoDal);
    
            //ACT & ASSERT
            var nuevaFamilia = gestorPermisos.NuevaFamilia(familiaDePrueba);
            Assert.IsNotNull(nuevaFamilia.Codigo, "Las familias creadas por el usuario deben llevar un código autogenerado");
            Assert.AreEqual(familiaDePrueba, nuevaFamilia.Descripcion, "No cargó la descripción de la familia creada");

            nuevaFamilia.Permisos.Add(new Patente { Codigo = ControlDePatentes.RegistrarNuevoEmpleado });
            nuevaFamilia.Permisos.Add(new Patente{ Codigo =  ControlDePatentes.EditarDatosDelEmpleado });

            gestorPermisos.Actualizar(nuevaFamilia);

            var familiasExistentes = gestorPermisos.ListarFamilias();
            var familiaCreada = familiasExistentes.SingleOrDefault(f => f.Codigo == nuevaFamilia.Codigo);
            Assert.IsNotNull(familiaCreada);
            Assert.IsTrue(familiaCreada.ConcederAcceso(ControlDePatentes.RegistrarNuevoEmpleado));
            Assert.IsTrue(familiaCreada.ConcederAcceso(ControlDePatentes.EditarDatosDelEmpleado));
            Assert.IsFalse(familiaCreada.ConcederAcceso(ControlDePatentes.BuscarTurnoLibre), "familiaCreada.ConcederAcceso(ControlDePatentes.BuscarTurnoLibre)");

            //Debe fallar si intento crear otra familia con el mismo nombre
            try
            {
                gestorPermisos.NuevaFamilia(familiaDePrueba);
                Assert.Fail("Ya existe una familia con el nombre {0} y no me frenó", familiaDePrueba);
            }
            catch (DAL.Validaciones.ElementoRepetidoException ex)
            {
                //Se esperaba esto
            }
        }
    }
}
