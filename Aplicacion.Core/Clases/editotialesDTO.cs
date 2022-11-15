using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aplicacion.Core
{
    public class editotialesDTO
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]//Obligatorio        
        [StringLength(50, ErrorMessage = "Longitud entre 2 y 50 caracteres.",
                      MinimumLength = 2)]//Longitud Maxima del campo        
        public string nombre { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(30, ErrorMessage = "Longitud entre 2 y 30 caracteres.",
                      MinimumLength = 2)]
        public string sede { get; set; }
    }
}
