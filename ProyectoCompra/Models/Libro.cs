using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoCompra.Models
{
    public class Libro
    {
        [Key]
        public int LibroID { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        [Display(Name = "Nombre del Libro")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        public int stock { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "You must enter {0}")]
        public decimal precio { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        [Display(Name = "Categoria")]
        public int CategoriaID { get; set; }

        public virtual ICollection<Compra> Compras { get; set; }

        public virtual Categoria Categoria { get; set; }

    }
}