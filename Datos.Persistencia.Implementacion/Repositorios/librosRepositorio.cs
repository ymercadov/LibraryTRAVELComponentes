using Datos.Persistencia.Core;
using Datos.Persistencia.Repositorio;
using Dominio.Contratos;
using Dominio.Core;


namespace Datos.Persistencia.Implementacion
{
   

    public class librosRepositorio : RepositorioBase<libros>, ILibrosRepositorio
    {
        public librosRepositorio(IContextoUnidaDeTrabajo unidaDeTrabajo) : base(unidaDeTrabajo) { }
    }
}
