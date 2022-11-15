using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio.Core
{

    [Table("autores_has_libros")]
    public class autoresHasLibros
    {
     
        public int autoresId { get; set; }     
        public int librosIsbn { get; set; }
        public libros libro { get; set; }
        public autores autor { get; set; }

        #region Relaciones

        #endregion
    }
}
