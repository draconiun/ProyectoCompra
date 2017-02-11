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
        public string nombre { get; set; }
        public int stock { get; set; }
        public decimal precio { get; set; }

        public virtual ICollection<Compra> Compras { get; set; }

    }
}