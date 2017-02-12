using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoCompra.Models
{
    public class Categoria
    {
        [Key]
        [Display(Name = "Categoria")]
        public int CategoriaID { get; set; }

        [Display(Name = "Nombre de la Categoria")]
        [Required(ErrorMessage = "You must enter {0}")]
        public string nombre { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
    }
}