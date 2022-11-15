using Aplicacion.Contratos;
using Aplicacion.Core;
using AutoMapper;
using Dominio.Contratos;
using Dominio.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aplicacion.Implementacion
{
    public class editorialesServicio : IEditorialesServicio
    {
        
        #region Atributos
        private IEditorialesRepositorio _editorialesRepositorio;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public editorialesServicio(IEditorialesRepositorio pEditorialesRepositorio, IMapper mapper)
        {
            this._editorialesRepositorio = pEditorialesRepositorio;
            this._mapper = mapper;
        }
        #endregion

        #region Metodos
            
        public editotialesDTO ObtenerUno(int id)
        {
            var objetoRecuperado = _editorialesRepositorio.Obtener(id);
            return _mapper.Map<editoriales, editotialesDTO>(objetoRecuperado);
        }
        public IEnumerable<editotialesDTO> ObtenerTodas()
        {
            var lista = _editorialesRepositorio.ObtenerTodas();
            return _mapper.Map<IEnumerable<editoriales>, IEnumerable<editotialesDTO>>(lista);
        }

        public IEnumerable<editotialesDTO> BuscarPorNombre(string nombre) {
            var lista = _editorialesRepositorio.Buscar(x => x.nombre.ToUpper().Equals(nombre.ToUpper()));
            return _mapper.Map<IEnumerable<editoriales>, IEnumerable<editotialesDTO>>(lista);

        }
        
        public editotialesDTO BuscarPorSede(string sede) {
            var objetoRecuperado = _editorialesRepositorio.BuscarSingleOrDefault(x => x.sede.ToUpper().Equals(sede.ToUpper()));
            return _mapper.Map<editoriales, editotialesDTO>(objetoRecuperado);
        }
                     
        public bool Agregar(editotialesDTO entidad)
        {
            try
            {
                var _objeto = new editoriales();
                _mapper.Map(entidad, _objeto);
                _editorialesRepositorio.Agregar(_objeto);
                _editorialesRepositorio.unidadTrabajo.Completar();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public editotialesDTO AgregarEditorial(editotialesDTO entidad)
        {
            editotialesDTO unaEditorial = new editotialesDTO();
            try
            {
                var _objeto = new editoriales();
                _mapper.Map(entidad, _objeto);
                _editorialesRepositorio.Agregar(_objeto);
                _editorialesRepositorio.unidadTrabajo.Completar();
                unaEditorial = ObtenerTodas().Select(s => s).Last();

                return (unaEditorial != null ? unaEditorial : null);
            }
            catch
            {
                return null; ;
            }
        }

        public editotialesDTO Actualizar(editotialesDTO entidad)
        {
            try
            {
                var _objeto = new editoriales();
                _mapper.Map(entidad, _objeto);
                _editorialesRepositorio.Actualizar(_objeto);
                _editorialesRepositorio.unidadTrabajo.Completar();
                var unlibro = _editorialesRepositorio.BuscarSingleOrDefault(b => b.id == entidad.id);
                var _objetoDTO = new editotialesDTO();
                _mapper.Map(unlibro, _objetoDTO);
                return _objetoDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }





        public editotialesDTO Eliminar(int id) {
            try
            {
                var uneditorial = _editorialesRepositorio.BuscarSingleOrDefault(b => b.id == id);
                _editorialesRepositorio.Eliminar(uneditorial);
                _editorialesRepositorio.unidadTrabajo.Completar();
                var _objeto = new editotialesDTO();
                _mapper.Map(uneditorial, _objeto);
                return _objeto;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }


        #endregion

        #region Dispose

        ~editorialesServicio() { }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_editorialesRepositorio != null)
                {
                    _editorialesRepositorio.Dispose();
                    _editorialesRepositorio = null;
                }
            }
        }

        #endregion
        
    }
}
