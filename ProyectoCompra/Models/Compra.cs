using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoCompra.Models
{
    public class Compra
    {
        [Key]
        public int CompraID { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        public int PersonaID { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        public int LibroID { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        public int cantidad { get; set; }

        public int GrupoID { get; set; }

        public virtual Persona Persona { get; set; }
        public virtual Libro Libro { get; set; }
        public virtual Grupo Grupo { get; set; }

    }
}