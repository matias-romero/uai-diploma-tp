using System;
using SaludAr.BLL.Traductor;
using SaludAr.Services.Crypto;
using StructureMap;

namespace SaludAr.BLL.Dependencias
{
    internal class BllRegistry : Registry
    {
        public BllRegistry()
        {
            this.Scan(x =>
            {
                x.TheCallingAssembly();
                x.WithDefaultConventions();
            });

            this.For<ITraductorUsuario>().Singleton();
            this.For<ITraductor>().Use(ctx => ctx.GetInstance<ITraductorUsuario>());
            this.For<ICriptografia>().Use(() => Criptografia.Default);
            this.For<IBitacora>().Use(() => Bitacora.Default);
        }

    }
}
