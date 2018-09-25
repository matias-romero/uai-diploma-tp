using System.Linq;
using AutoMoq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SaludAr.BLL.Traductor;
using SaludAr.DAL;

namespace SaludAr.Tests
{
    [TestClass]
    public class PruebasDeAcceso
    {
        private AutoMoqer _autoMoqer;
        private IUnidadDeTrabajo _unidadDeTrabajo;

        [TestInitialize]
        public void Setup()
        {
            PruebasDeBitacora.ConfigurarBitacoraDefaultParaTesteosUnitarios();

            _autoMoqer = new AutoMoqer();
            _autoMoqer.GetMock<ITraductorUsuario>()
                .Setup(t => t.Traducir(It.IsAny<string>()))
                .Returns<string>(key => key);

            _unidadDeTrabajo = PruebasABM.ResolverUnidadDeTrabajo();
        }

        [TestMethod]
        public void ProbarInicioDeSesion()
        {
            //ARRANGE
            var credencialesValidas = new[]
            {
                new BE.Infraestructura.Usuario {Nombre = "mromero", Contraseña = "abcd1234"}
            };

            _autoMoqer.GetMock<DAL.IUsuario>()
                .Setup(u => u.ObtenerPorNombre(It.IsAny<string>()))
                .Returns<string>(nombreUsuario => credencialesValidas.SingleOrDefault(c => c.Nombre.Equals(nombreUsuario)));

            var usuarioBll = _autoMoqer.Resolve<BLL.Usuario>();

            //ACT - ASSERT Esperando que falle
            var usuario = usuarioBll.IniciarSesion("mromero", "abc1234");
            Assert.IsNull(usuario, "Si no especifique la clave correcta debe frenar el proceso");

            //ACT - ASSERT Esperando que pase
            var usuario2 = usuarioBll.IniciarSesion("mromero", "abcd1234");
            Assert.IsNotNull(usuario2, "Si la clave es correcta debe dejarlo continuar");
        }
    }
}
