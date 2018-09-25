using System;
using System.Collections.Generic;
using System.Linq;
using SaludAr.BE.Seguridad;
using SaludAr.DAL.DigitosVerificadores;

namespace SaludAr.BLL
{
    /// <summary>
    /// Encapsula funciones de rutina basada en dígitos verificadores para determinar la integridad del repositorio de datos
    /// </summary>
    public class IntegridadSistema
    {
        private readonly bool _estaCorrupto;

        public class SistemaCorruptoException : Exception
        {
            public string ConstanteError { get; set; }
            public string[] EntidadesAfectadas { get; set; }

            public SistemaCorruptoException(IEnumerable<string> entidadesAfectadas)
            {
                this.ConstanteError = "SistemaCorruptoException";
                this.EntidadesAfectadas = entidadesAfectadas.ToArray();
            }
        }

        //TODO: Este constructor esta solo a modo de ejemplo
        public IntegridadSistema(bool estaCorrupto)
        {
            _estaCorrupto = estaCorrupto;
        }

        public void ComprobarIntegridad()
        {
            var unidadDeTrabajo = new DAL.SqlHelper().NuevaUnidadDeTrabajo();
            var calculadoraIntegridadDV = unidadDeTrabajo.NuevoRepositorio<ICalculadoraIntegridadDV>();

            var corruptedEntityNames = new List<string>();
            var tipoEntidadConDigitoVerificador = typeof(IEntidadConDigitoVerificador);
            var tiposSoportadosConDigitoVerificador = this.EnumerarTiposCompatibles(tipoEntidadConDigitoVerificador);
            foreach (var tipoEntidad in tiposSoportadosConDigitoVerificador)
            {
                if(calculadoraIntegridadDV.ComprobarIntegridad(tipoEntidad))
                    corruptedEntityNames.Add(tipoEntidad.FullName);
            }

            //Reviento si al menos existe una entidad corrupta
            if (_estaCorrupto || corruptedEntityNames.Any())
                throw new SistemaCorruptoException(corruptedEntityNames);

            (unidadDeTrabajo as IDisposable)?.Dispose();
        }
        
        private IEnumerable<Type> EnumerarTiposCompatibles(Type tipoEsperado)
        {
            return typeof(BE.Infraestructura.Usuario).Assembly
                .GetTypes()
                .Where(entityType => entityType.IsClass 
                                     && !entityType.IsAbstract
                                     && tipoEsperado.IsAssignableFrom(entityType));
        }
    }
}