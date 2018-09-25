using System;
using System.Linq;
using AutoMoq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SaludAr.BE.Empleados;
using SaludAr.BLL.Traductor;
using SaludAr.DAL;

namespace SaludAr.Tests
{
    [TestClass]
    public class PruebasDePaciente
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
        public void PrueboRegistrarNuevoPaciente()
        {
            //ARRANGE
            _autoMoqer.SetInstance(_unidadDeTrabajo.NuevoRepositorio<DAL.IPaciente>());
            var pacienteBll = _autoMoqer.Resolve<BLL.Paciente>();

            var nuevoPaciente = pacienteBll.Nuevo();
            nuevoPaciente.Nombre = "Juan";
            nuevoPaciente.Apellido = "Perez";
            nuevoPaciente.FechaNacimiento = new DateTime(1987, 8, 12);
            nuevoPaciente.Sexo = Sexo.Masculino;
            nuevoPaciente.NumeroDocumento = "12000323";

            //ACT
            pacienteBll.Actualizar(nuevoPaciente);

            //ASSERT
            Assert.AreNotEqual(Guid.Empty, nuevoPaciente.Id);
        }

        [TestMethod]
        public void PrueboRegistrarDiferentesActosMedicos()
        {
            //ARRANGE
            _autoMoqer.SetInstance(_unidadDeTrabajo.NuevoRepositorio<DAL.IPaciente>());
            _autoMoqer.SetInstance(_unidadDeTrabajo.NuevoRepositorio<DAL.IHistoriaClinica>());
            var historiaClinicaBll = _autoMoqer.Resolve<BLL.HistoriaClinica>();
            var paciente = this.ObtenerPacienteDePrueba();

            //ACT & ASSERT
            var historiaClinica = historiaClinicaBll.Recuperar(paciente);
            Assert.IsNotNull(historiaClinica.Eventos);
            Assert.AreEqual(0, historiaClinica.Eventos.Count);

            var nuevaEvolucion = new BE.HistoriaClinica.EvolucionClinicaTurno
            {
                Fecha = DateTime.Now,
                Titulo = "Prueba",
                Evolucion = "El paciente se encuentra en optimas condiciones."
            };
            historiaClinica.Eventos.Add(nuevaEvolucion);

            var nuevoLaboratorio = new BE.HistoriaClinica.EstudioLaboratorio
            {
                Fecha = DateTime.Now.AddDays(-1),
                Titulo = "Hemograma Completo",
                NroProtocolo = "123456789"
            };
            historiaClinica.Eventos.Add(nuevoLaboratorio);
            historiaClinicaBll.Actualizar(historiaClinica);
            Assert.AreEqual(2, historiaClinica.Eventos.Count);

            var rxAgregadaEnVisitaPosterior = new BE.HistoriaClinica.EstudioImagenologia
            {
                Fecha = DateTime.Now.AddDays(1),
                Titulo = "Rx Perfil",
                InformeTecnico = "No se observan complicaciones en la radiografía"
            };
            historiaClinica.Eventos.Add(rxAgregadaEnVisitaPosterior);
            historiaClinicaBll.Actualizar(historiaClinica);

            //Vuelvo a cargarlo desde la DB y compruebo que los eventos se grabaron completos
            var hcRecargada = historiaClinicaBll.Recuperar(paciente);
            Assert.AreEqual(3, hcRecargada.Eventos.Count, "No se grabaron todos los eventos");
            Assert.IsTrue(hcRecargada.Eventos.OfType<BE.HistoriaClinica.EvolucionClinicaTurno>().Any());
            Assert.IsTrue(hcRecargada.Eventos.OfType<BE.HistoriaClinica.EstudioLaboratorio>().Any());
            Assert.IsTrue(hcRecargada.Eventos.OfType<BE.HistoriaClinica.EstudioImagenologia>().Any());
        }

        private BE.Paciente ObtenerPacienteDePrueba()
        {
            var paciente = _autoMoqer.Resolve<DAL.IPaciente>().Listar().FirstOrDefault();
            if (paciente == null)
            {
                //Si no tengo pacientes, me aseguro de correr el otro test primero
                this.PrueboRegistrarNuevoPaciente();
                paciente = _autoMoqer.Resolve<DAL.IPaciente>().Listar().Single();
            }

            return paciente;
        }
    }
}
