using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio.Core
{
    
        [Table("autores")]
        public class autores
        {
            #region Miembro
           // private readonly List<autoresHasLibros> _autoresHasLibros = new List<autoresHasLibros>();
            #endregion

            #region Propiedades
            [Key]
            public int id { get; set; }
            public string nombre { get; set; }
            public string apellido { get; set; }
        #endregion

        #region Relaciones
        public List<autoresHasLibros> autoreshaslibros { get; set; }
        //public IReadOnlyCollection<autoresHasLibros> autoresHasLibros => this._autoresHasLibros;
        #endregion
    }
    
}
