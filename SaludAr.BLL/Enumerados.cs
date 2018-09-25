using System;
using System.Collections.Generic;
using SaludAr.BLL.Traductor;

namespace SaludAr.BLL
{
    public interface IEnumerados
    {
        BE.Infraestructura.ValorDeEnumeracion[] Listar(Type tipoEnum);
    }

    internal class Enumerados : IEnumerados
    {
        private readonly ITraductor _traductor;

        public Enumerados(ITraductor traductor)
        {
            _traductor = traductor;
        }

        public BE.Infraestructura.ValorDeEnumeracion[] Listar(Type tipoEnum)
        {
            if(!tipoEnum.IsEnum)
                throw new NotSupportedException("El tipo indicado no corresponde con un Enum");

            var listado = new List<BE.Infraestructura.ValorDeEnumeracion>();
            var nombreEnum = tipoEnum.Name;
            foreach (var valorEnum in Enum.GetValues(tipoEnum))
            {
                listado.Add(new BE.Infraestructura.ValorDeEnumeracion
                {
                    Valor = (int)valorEnum,
                    Descripcion = _traductor.Traducir(string.Format("{0}_{1:G}", nombreEnum, valorEnum))
                });
            }

            return listado.ToArray();
        }
    }
}
