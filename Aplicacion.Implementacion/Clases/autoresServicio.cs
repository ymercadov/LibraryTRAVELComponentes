using Aplicacion.Contratos;
using Aplicacion.Core;
using AutoMapper;
using Dominio.Contratos;
using Dominio.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Implementacion.Clases
{
    public class autoresServicio : IAutoresServicio
    {
        #region Atributos
        private IAutoresRepositorio _autoresRepositorio;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public autoresServicio(IAutoresRepositorio pAutoresRepositorio, IMapper mapper)
        {
            _autoresRepositorio = pAutoresRepositorio;
            _mapper = mapper;
        }
        #endregion

        #region Metodos       
        public autoresDTO ObtenerUno(int id)
        {
            var lista = _autoresRepositorio.Obtener(id);
            return _mapper.Map<autores, autoresDTO>(lista);
        }
        private autores BuscarSingleOrDefault(Expression<Func<autores, bool>> predicado)
        {
            return _autoresRepositorio.BuscarSingleOrDefault(predicado);
        }
        public IEnumerable<autoresDTO> ObtenerTodas()
        {
            var lista = _autoresRepositorio.ObtenerTodas();
            return _mapper.Map<IEnumerable<autores>, IEnumerable<autoresDTO>>(lista);
        }
        public bool Agregar(autoresDTO entidad)
        {
            try
            {
                var _objeto = new autores();
                _mapper.Map(entidad, _objeto);
                _autoresRepositorio.Agregar(_objeto);
                _autoresRepositorio.unidadTrabajo.Completar();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public autoresDTO AgregarAutor(autoresDTO entidad)
        {
            autoresDTO UnAutor = new autoresDTO();
            try
            {
                var _objeto = new autores();
                _mapper.Map(entidad, _objeto);
                _autoresRepositorio.Agregar(_objeto);
                _autoresRepositorio.unidadTrabajo.Completar();

                UnAutor = ObtenerTodas().Select(s => s).Last();

                return (UnAutor != null ? UnAutor : null);
            }
            catch
            {
                return null;
            }
        }
        public autoresDTO Actualizar(autoresDTO entidad)
        {
            try
            {
                var _objeto = new autores();
                _mapper.Map(entidad, _objeto);
                _autoresRepositorio.Actualizar(_objeto);
                _autoresRepositorio.unidadTrabajo.Completar();
                var unlibro = _autoresRepositorio.BuscarSingleOrDefault(b => b.id == entidad.id);
                var _objetoDTO = new autoresDTO();
                _mapper.Map(unlibro, _objetoDTO);
                return _objetoDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public autoresDTO Eliminar(int id)
        {
            try
            {
                var unlibro = _autoresRepositorio.BuscarSingleOrDefault(b => b.id == id);
                _autoresRepositorio.Eliminar(unlibro);
                _autoresRepositorio.unidadTrabajo.Completar();
                var _objeto = new autoresDTO();
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

        ~autoresServicio() { }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_autoresRepositorio != null)
                {
                    _autoresRepositorio.Dispose();
                    _autoresRepositorio = null;
                }
            }
        }

        #endregion
    }
}
