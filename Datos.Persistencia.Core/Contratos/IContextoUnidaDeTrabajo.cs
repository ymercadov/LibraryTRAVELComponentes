using Dominio.Core;
using Microsoft.EntityFrameworkCore;
using System;

namespace Datos.Persistencia.Core
{

    public interface IContextoUnidaDeTrabajo : IUnidadTrabajo, IDisposable
    {

        DbSet<libros> libros { get;  }
        DbSet<editoriales> editoriales { get; }
        DbSet<autores> autores { get; }
        DbSet<autoresHasLibros> autoresHasLibros { get; }
        
        DbSet<Entidad> Set<Entidad>() where Entidad : class;

        void Attach<Entidad>(Entidad item) where Entidad : class;

        void SetModified<Entidad>(Entidad item) where Entidad : class;


    }
}
