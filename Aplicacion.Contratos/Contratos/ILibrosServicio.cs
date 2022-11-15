using Aplicacion.Core;
using Dominio.Core;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Aplicacion.Contratos
{
    public interface ILibrosServicio: IDisposable
    {
        librosDTO ObtenerUno(int isbn); //Select * from libros where ....   
        IEnumerable<librosDTO> ObtenerTodas(); //Select * from libros
        mymodeloDTO ObtenerUnoporId(int isbn);
        bool Agregar(librosDTO entidad);
        librosDTO AgregarLibro(librosDTO entidad, List<int> autores);
        public librosDTO Actualizar(librosDTO entidad, List<int> autores);
        public librosDTO Eliminar(int id);

    }
}
