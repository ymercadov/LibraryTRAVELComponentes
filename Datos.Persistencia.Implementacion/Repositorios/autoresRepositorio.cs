using Datos.Persistencia.Core;
using Datos.Persistencia.Repositorio;
using Dominio.Contratos;
using Dominio.Core;

namespace Datos.Persistencia.Implementacion
{


    public class autoresRepositorio : RepositorioBase<autores>, IAutoresRepositorio
    {
        public autoresRepositorio(IContextoUnidaDeTrabajo unidaDeTrabajo) : base(unidaDeTrabajo) { }
    }
}
