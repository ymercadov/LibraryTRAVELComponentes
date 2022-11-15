using AutoMapper;
using Dominio.Core;

namespace Aplicacion.Core
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<libros, librosDTO>();
            CreateMap<librosDTO,libros>();
            CreateMap<editoriales, editotialesDTO>();
            CreateMap<editotialesDTO,editoriales >();
            CreateMap<autores, autoresDTO>();
            CreateMap<autoresDTO,autores>();
            CreateMap<autoresHasLibros, autoresHasLibrosDTO>();
            CreateMap<autoresHasLibrosDTO,autoresHasLibros>();

            CreateMap<mymodelo, mymodeloDTO>();
            CreateMap<mymodeloDTO, mymodelo>();
        }
    }
}
