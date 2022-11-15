using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Core
{
    public class mymodeloDTO
    {
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

        public List<int> autores { get; set; }
    }
}
