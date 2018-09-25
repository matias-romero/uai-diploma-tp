using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SaludAr.BE.Infraestructura;
using SaludAr.BLL.Traductor;

namespace SaludAr.Tests
{
    [TestClass]
    public class PruebasDeIdioma
    {
        private class FakeSubscriptorIdioma : ISubscriptorCambioIdioma
        {
            public void IdiomaCambiado(Idioma nuevoIdioma)
            {
                this.UltimoIdiomaCambiado = nuevoIdioma;
            }

            public Idioma UltimoIdiomaCambiado { get; set; }
        }

        [TestMethod]
        public void DebeNotificarLosCambioDeIdiomaASubscriptores()
        {
            //ARRANGE
            var subscriptor = new FakeSubscriptorIdioma();
            var traductorUsuario = this.ObtenerTraductorUsuario();
            traductorUsuario.Subscribirse(subscriptor);

            //ACT
            traductorUsuario.IdiomaPreferido = traductorUsuario.IdiomasSoportados.Last();

            //ASSERT
            Assert.AreEqual(traductorUsuario.IdiomaPreferido, subscriptor.UltimoIdiomaCambiado);
        }

        //[TestMethod]
        //public void ComprobarConstantesDeTextoDefinidasEnRecursos()
        //{
        //    //ARRANGE
        //    var constantesDeTexto = typeof(ConstantesDeTexto).GetFields().Select(f => f.Name).ToArray();
        //    var traductorUsuario = this.ObtenerTraductorUsuario();
        //    //Como es un TEST necesito cargar el ensamblado satelite manualmente antes de usarlo
        //    //var a = traductorUsuario.GetType().Assembly.GetSatelliteAssembly(System.Globalization.CultureInfo.GetCultureInfo(traductorUsuario.IdiomaPreferido.CodigoIso));

        //    //ACT & ASSERT
        //    foreach (var constante in constantesDeTexto)
        //    {
        //        var traduccion = traductorUsuario.Traducir(constante);
        //        Assert.IsFalse(string.IsNullOrWhiteSpace(traduccion), "La constante '{0}' no fue definida en el recurso");
        //    }
        //}

        [TestMethod]
        public void BuscarLaTraduccionConvenidaDeAcuerdoAlCampoDeUnaEntidad()
        {
            var expectedKey = "Empleado_Apellido";
            var traductorMock = new Mock<ITraductor>();

            var textoTraducido = GUI.Editores.ExtensionesTraductor.TraducirCampoEntidad<BE.Empleados.Empleado>(traductorMock.Object, m => m.Apellido);

            traductorMock.Verify(t => t.Traducir(expectedKey));
        }

        private ITraductorUsuario ObtenerTraductorUsuario()
        {
            var traductorUsuario = new TraductorUsuario();
            traductorUsuario.IdiomaPreferido = traductorUsuario.IdiomasSoportados.First();
            return traductorUsuario;
        }
    }
}
