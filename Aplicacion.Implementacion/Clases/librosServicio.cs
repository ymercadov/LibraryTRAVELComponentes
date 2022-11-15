using Aplicacion.Contratos;
using Aplicacion.Core;
using AutoMapper;
using Dominio.Contratos;
using Dominio.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Aplicacion.Implementacion
{
    public class librosServicio : ILibrosServicio
    {
        #region Atributos
        private ILibrosRepositorio _librosRepositorio;
        private IAutoresHasLibrosRepositorio _autoresHasLibrosRepositorio;

        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public librosServicio(ILibrosRepositorio pLibrosRepositorio, IAutoresHasLibrosRepositorio autoresHasLibrosRepositorio,
                              IMapper mapper)
        {
            _librosRepositorio = pLibrosRepositorio;
            _autoresHasLibrosRepositorio = autoresHasLibrosRepositorio;
            _mapper = mapper;
        }
        #endregion

        #region Metodos       
        public librosDTO ObtenerUno(int isbn)
        {
            var lista = _librosRepositorio.Obtener(isbn);
            return _mapper.Map<libros, librosDTO>(lista);
        }

        public mymodeloDTO ObtenerUnoporId(int isbn)
        {
            var lista = _librosRepositorio.Obtener(isbn);
            var listaautolibro = _autoresHasLibrosRepositorio.Buscar(s => s.librosIsbn.Equals(isbn));

            mymodelo listatotal = new mymodelo();

            listatotal.isbn = lista.isbn;
            listatotal.editorialesId = lista.editorialesId;
            listatotal.titulo = lista.titulo;
            listatotal.sinopsis = lista.sinopsis;
            listatotal.nPagina = lista.nPagina;

            List<int> lstautores = new List<int>();
            foreach (autoresHasLibros item in listaautolibro.ToList())
            {
                lstautores.Add(item.autoresId);
            }           
            listatotal.autores = lstautores;

            return _mapper.Map<mymodelo, mymodeloDTO>(listatotal);



            
        }



        private libros BuscarSingleOrDefault(Expression<Func<libros, bool>> predicado)
        {
            return _librosRepositorio.BuscarSingleOrDefault(predicado);            
        }

        private libros BuscarSingleOrDefault()
        {
            return _librosRepositorio.BuscarSingleOrDefault();
        }

        public IEnumerable<librosDTO> ObtenerTodas()
        {
            var lista = _librosRepositorio.ObtenerTodas();
            return _mapper.Map<IEnumerable<libros>, IEnumerable<librosDTO>>(lista);
        }
        public bool Agregar(librosDTO entidad)
        {
            try
            {
                var _objeto = new libros();
                _mapper.Map(entidad, _objeto);
                _librosRepositorio.Agregar(_objeto);
                _librosRepositorio.unidadTrabajo.Completar();              
                return true;
            }
            catch
            {
                return false;
            }
        }
        public librosDTO AgregarLibro(librosDTO entidad, List<int> autores)
        {
            librosDTO UnLibro = new librosDTO();
            try
            {
                var _objeto = new libros();
                _mapper.Map(entidad, _objeto);
                _librosRepositorio.Agregar(_objeto);
                _librosRepositorio.unidadTrabajo.Completar();

                UnLibro = ObtenerTodas().Select(s => s).Last();

                autoresHasLibrosDTO autorlibro = new autoresHasLibrosDTO();              

                foreach (int item in autores)
                {
                    autorlibro.autoresId = item;
                    autorlibro.librosIsbn = UnLibro.isbn;
                    var _objetoautorlibro = new autoresHasLibros();
                    _mapper.Map(autorlibro, _objetoautorlibro);
                    _autoresHasLibrosRepositorio.Agregar(_objetoautorlibro);
                    _autoresHasLibrosRepositorio.unidadTrabajo.Completar();
                }

                return (UnLibro != null ? UnLibro : null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public librosDTO Actualizar(librosDTO entidad, List<int> autores)
        {
            try
            {
                var _objeto = new libros();
                _mapper.Map(entidad, _objeto);
                _librosRepositorio.Actualizar(_objeto);
                _librosRepositorio.unidadTrabajo.Completar();
                var unlibro = _librosRepositorio.BuscarSingleOrDefault(b => b.isbn == entidad.isbn);
                var _objetoDTO = new librosDTO();
                _mapper.Map(unlibro, _objetoDTO);


                var lstutolibro = _autoresHasLibrosRepositorio.Buscar(b => b.librosIsbn == entidad.isbn);
                var i = 0;
                while (i <= lstutolibro.Count())
                {
                    _autoresHasLibrosRepositorio.Eliminar(lstutolibro.First(s => s.librosIsbn == entidad.isbn));
                    _autoresHasLibrosRepositorio.unidadTrabajo.Completar();
                    i++;
                }
                
                autoresHasLibrosDTO autorlibro = new autoresHasLibrosDTO();

                foreach (int item in autores)
                {
                    autorlibro.autoresId = item;
                    autorlibro.librosIsbn = entidad.isbn;
                    var _objetoautorlibro = new autoresHasLibros();
                    _mapper.Map(autorlibro, _objetoautorlibro);
                    _autoresHasLibrosRepositorio.Agregar(_objetoautorlibro);
                    _autoresHasLibrosRepositorio.unidadTrabajo.Completar();
                }






                return _objetoDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public librosDTO Eliminar(int id)
        {
            try
            {
                var unlibro = _librosRepositorio.BuscarSingleOrDefault(b => b.isbn == id);
                _librosRepositorio.Eliminar(unlibro);
                _librosRepositorio.unidadTrabajo.Completar();
                var _objeto = new librosDTO();
                _mapper.Map(unlibro, _objeto);
                return _objeto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        #endregion

        #region Dispose

        ~librosServicio() { }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_librosRepositorio != null)
                {
                    _librosRepositorio.Dispose();
                    _librosRepositorio = null;
                }
            }
        }

        #endregion
    }
}
