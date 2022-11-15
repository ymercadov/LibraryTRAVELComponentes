using Datos.Persistencia.Core;
using Datos.Persistencia.Implementacion;
using Dominio.Contratos;
using System.ComponentModel.Composition;
using Utilitarios.IoC;


namespace Datos.Persistencia.Implementacion
{
   
    [Export(typeof(IModule))]
    public class ModuleIInit : IModule
    {
        public void Initialize(IRegisterMoules register)
        {
            register.RegisterTyper<IContextoUnidaDeTrabajo, ContextoPrincipal>();
            register.RegisterTyper<IAutoresHasLibrosRepositorio, autoresHasLibrosRepositorio>();
            register.RegisterTyper<IAutoresRepositorio, autoresRepositorio>();
            register.RegisterTyper<ILibrosRepositorio, librosRepositorio>();
            register.RegisterTyper<IEditorialesRepositorio, editorialesRepositorio>();
        }
    }
}
