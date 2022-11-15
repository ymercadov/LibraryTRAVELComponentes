using NUnit.Framework;
using Aplicacion.Contratos;
using Aplicacion.Core;
using Moq;
using Datos.Persistencia.Core;
using Datos.Persistencia.Implementacion;
using Aplicacion.Implementacion;
using Microsoft.EntityFrameworkCore;
using Dominio.Core;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Aplicacion.Test
{
    public class bibliotecaUnitTest
    {
        public ServiceCollection Services { get; private set; }
        public ServiceProvider ServiceProvider { get; protected set; }
        [SetUp]

        public void Setup()
        {
            Services = new ServiceCollection();
            Services.AddDbContext<ContextoPrincipal>(opt => opt.UseInMemoryDatabase(databaseName: "TestDB"),
                ServiceLifetime.Scoped,
                ServiceLifetime.Scoped);

            ServiceProvider = Services.BuildServiceProvider();           
        }



        [Test]
        public void Editoriales_Crear()
        {
            using (var dbContext = ServiceProvider.GetService<ContextoPrincipal>())
            {
                dbContext.editoriales.Add(new editoriales
                {
                    id = 1,
                    nombre = "Editorial",
                    sede = "sede 1"
                });
                dbContext.SaveChanges();
                Assert.IsTrue(dbContext.editoriales.Count() == 1);               
            }
        }

        [Test]
        public void Libros_Crear()
        {
            using (var dbContext = ServiceProvider.GetService<ContextoPrincipal>())
            {
                dbContext.libros.Add(new libros
                {
                   isbn=9789295,
                   editorialesId=1,
                   titulo="Cien años de soledad",
                   sinopsis="Trata la historia de una familia por generaciones",
                   nPagina=450
                });
                dbContext.SaveChanges();
                Assert.IsTrue(dbContext.libros.Count() == 1);
            }
        }
    }
}