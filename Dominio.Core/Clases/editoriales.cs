using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio.Core
{

    [Table("editoriales")]
    public class editoriales
    {
        #region Miembro
        private readonly List<libros> _libros = new List<libros>();
        #endregion

        #region Propiedades
        public int id { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]//Obligatorio        
        [StringLength(50, ErrorMessage = "Longitud entre 2 y 50 caracteres.",
                      MinimumLength = 2)]//Longitud Maxima del campo        
        public string nombre { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(30, ErrorMessage = "Longitud entre 2 y 30 caracteres.",
                      MinimumLength = 2)]
        public string sede { get; set; }
        #endregion

        #region Relaciones
        public IReadOnlyCollection<libros> libros => this._libros;
        #endregion
    }
}
