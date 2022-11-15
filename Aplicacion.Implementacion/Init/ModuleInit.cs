using Aplicacion.Contratos;
using Dominio.Contratos;
using System.ComponentModel.Composition;
using Utilitarios.IoC;

namespace Aplicacion.Implementacion
{
    [Export(typeof(IModule))]
    public class ModuleIInit : IModule
    {
        public void Initialize(IRegisterMoules register)
        {
            register.RegisterTyper<IEditorialesServicio, editorialesServicio>();
            register.RegisterTyper<ILibrosServicio, librosServicio>();
        }
    }
}
