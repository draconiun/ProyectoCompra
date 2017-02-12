﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoCompra.Models
{
    public class Categoria
    {
        [Key]
        public int CategoriaID { get; set; }
        public string nombre { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
    }
}