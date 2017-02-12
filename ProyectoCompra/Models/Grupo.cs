using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoCompra.Models
{
    public class Grupo
    {
        [Key]
        public int GrupoID {get;set;}
        public string descripcion { get; set; }

        public virtual ICollection<Compra> Compras { get; set; }

    }
}