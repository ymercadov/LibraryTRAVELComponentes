using Datos.Persistencia.Core;
using Datos.Persistencia.Repositorio;
using Dominio.Contratos;
using Dominio.Core;


namespace Datos.Persistencia.Implementacion
{
    public class autoresHasLibrosRepositorio: RepositorioBase<autoresHasLibros>, IAutoresHasLibrosRepositorio
    {
        public autoresHasLibrosRepositorio(IContextoUnidaDeTrabajo unidaDeTrabajo) : base(unidaDeTrabajo) { }
    }
}
