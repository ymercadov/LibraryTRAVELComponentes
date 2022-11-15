using Datos.Persistencia.Core;
using Datos.Persistencia.Repositorio;
using Dominio.Contratos;
using Dominio.Core;

namespace Datos.Persistencia.Implementacion
{
    public class editorialesRepositorio : RepositorioBase<editoriales>, IEditorialesRepositorio
    {
        public editorialesRepositorio(IContextoUnidaDeTrabajo unidaDeTrabajo) : base(unidaDeTrabajo) { }
    }

}
