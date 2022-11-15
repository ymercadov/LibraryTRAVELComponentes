using Dominio.Core;
using Microsoft.EntityFrameworkCore;

namespace Datos.Persistencia.Core
{
    public class ContextoPrincipal : DbContext, IContextoUnidaDeTrabajo
    {
        
        public ContextoPrincipal(DbContextOptions<ContextoPrincipal> options) : base(options) { }


        #region -IContextoUnidaDeTrabajo-
       
        //Atributos
        DbSet<libros> _libros;
        DbSet<autores> _autores;
        DbSet<editoriales> _editoriales;
        DbSet<autoresHasLibros> _autoresHasLibros;
        
        //Propiedades
        public DbSet<libros> libros { get { return _libros ?? (_libros = base.Set<libros>()); } }
        public DbSet<autores> autores { get { return _autores ?? (_autores = base.Set<autores>()); } }
        public DbSet<editoriales> editoriales { get { return _editoriales ?? (_editoriales = base.Set<editoriales>()); } }
        public DbSet<autoresHasLibros> autoresHasLibros { get { return _autoresHasLibros ?? (_autoresHasLibros = base.Set<autoresHasLibros>()); } }


      
        public new DbSet<Entidad> Set<Entidad>() where Entidad : class {
            return base.Set<Entidad>();
        }
        public new void Attach<Entidad>(Entidad item) where Entidad : class {
            if (Entry(item).State == EntityState.Detached)
            {
                base.Set<Entidad>().Attach(item);
                
            }
        }

        public void SetModified<Entidad>(Entidad item) where Entidad : class
        {
            Entry(item).State = EntityState.Modified;           
        }

        public int Completar()
        {
            return base.SaveChanges();
        }

        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<autoresHasLibros>().HasKey(x => new { x.autoresId, x.librosIsbn });
            base.OnModelCreating(modelBuilder);
        }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }*/


    }
}
