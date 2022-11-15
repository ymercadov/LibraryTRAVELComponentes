using Dominio.Core;
using System;

namespace Dominio.Contratos
{
    public interface ILibrosRepositorio:IRepositiorioBase<libros>,IDisposable
    {
    }
}
