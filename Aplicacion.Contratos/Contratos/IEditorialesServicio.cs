using Aplicacion.Core;
using System;
using System.Collections.Generic;

namespace Aplicacion.Contratos
{
  
    public interface IEditorialesServicio: IDisposable
    {
        editotialesDTO ObtenerUno(int id);
        IEnumerable<editotialesDTO> ObtenerTodas(); //Select * from editoriales   
        IEnumerable<editotialesDTO> BuscarPorNombre(string nombre);
        editotialesDTO BuscarPorSede(string sede);
        bool Agregar(editotialesDTO entidad);
        editotialesDTO AgregarEditorial(editotialesDTO entidad);
        editotialesDTO Actualizar(editotialesDTO entidad);
        public editotialesDTO Eliminar(int id);

    }
}
