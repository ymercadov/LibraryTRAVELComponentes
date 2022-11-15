using Aplicacion.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Contratos
{
    public interface IAutoresServicio: IDisposable
    {
        autoresDTO ObtenerUno(int isbn); //Select * from libros where ....   
        IEnumerable<autoresDTO> ObtenerTodas(); //Select * from autores   
        bool Agregar(autoresDTO entidad);
        autoresDTO AgregarAutor(autoresDTO entidad);
        public autoresDTO Actualizar(autoresDTO entidad);
        public autoresDTO Eliminar(int id);
    }
}
