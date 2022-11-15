using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio.Core
{
    [Table("libros")]
    public class libros
    {
        #region Miembro
        //private readonly List<autoresHasLibros> _autoresHasLibros = new List<autoresHasLibros>();
        #endregion

        #region Propiedades
        [Key]        
        public int isbn { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]//Obligatorio    
        public int editorialesId { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(80, ErrorMessage = "Longitud entre 2 y 80 caracteres.",
                      MinimumLength = 2)]//Longitud Maxima del campo       
        public string titulo { get; set; }

        [StringLength(150, ErrorMessage = "Longitud entre 5 y 150 caracteres.",
                      MinimumLength = 5)]
        public string sinopsis { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]        
        public int nPagina { get; set; }
        #endregion

        #region Relaciones
        // public IReadOnlyCollection<autoresHasLibros> autoresHasLibros => this._autoresHasLibros;
        public List<autoresHasLibros> autoreshaslibros { get; set; }
        #endregion



    }
}
