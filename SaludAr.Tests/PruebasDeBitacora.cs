using System;
using AutoMoq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SaludAr.BE.Bitacora;
using SaludAr.BE.Infraestructura;
using SaludAr.BLL.Traductor;

namespace SaludAr.Tests
{
    [TestClass]
    public class PruebasDeBitacora
    {
        private AutoMoqer _autoMoqer;

        public static void ConfigurarBitacoraDefaultParaTesteosUnitarios()
        {
            var bitacoraDal = new Mock<DAL.IBitacora>(MockBehavior.Strict);
            bitacoraDal.Setup(b => b.RegistrarEnBitacora(It.IsAny<EntradaEnBitacora>()))
                .Callback<EntradaEnBitacora>(e => System.Diagnostics.Debug.Print(e.ToString()));

            BLL.Bitacora.ConfigurarProveedorDeDatosPorDefecto(bitacoraDal.Object);
        }

        [TestInitialize]
        public void Setup()
        {
            _autoMoqer = new AutoMoqer();
            _autoMoqer.GetMock<ITraductorUsuario>()
                .Setup(t => t.Traducir(It.IsAny<string>()))
                .Returns<string>(key => key);
        }

        [TestMethod]
        public void PruebaRegistrarEventoEnBitacora()
        {
            //ARRANGE
            const string mensajePrueba = "Mensaje de prueba";
            var usuarioDePrueba = new Usuario {Nombre = "Usuario"};
            var mockBitacoraDal = _autoMoqer.GetMock<DAL.IBitacora>();
            var bitacora = _autoMoqer.Resolve<BLL.Bitacora>();

            //ACT
            bitacora.RegistrarEnBitacora(Evento.UsuarioIngresoAlSistema, Severidad.Informativo, mensajePrueba, usuarioDePrueba);

            //ASSERT
            mockBitacoraDal.Verify(b => b.RegistrarEnBitacora(It.IsNotNull<EntradaEnBitacora>()), Times.Once);
        }

        [TestMethod]
        public void PrueboCambiarElRepositorioSubyacenteDelComponenteDeBitacora()
        {
            //ARRANGE
            var mockBitacoraDal = _autoMoqer.GetMock<DAL.IBitacora>();
            BLL.Bitacora.ConfigurarProveedorDeDatosPorDefecto(mockBitacoraDal.Object);

            //ACT
            BLL.Bitacora.Default.RegistrarEnBitacora(Evento.UsuarioIngresoAlSistema, "Un mensaje");

            //ASSERT
            mockBitacoraDal.Verify(b => b.RegistrarEnBitacora(It.IsNotNull<EntradaEnBitacora>()), Times.Once);
        }
    }
}
