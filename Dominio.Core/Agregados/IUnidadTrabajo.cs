using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Core
{
    public interface IUnidadTrabajo : IDisposable
    {
        int Completar(); //Confirmar, guardar cambios

    }
}
