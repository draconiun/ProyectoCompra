using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProyectoCompra.Models
{
    public class ProyectoCompraContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ProyectoCompraContext() : base("name=ProyectoCompraContext")
        {
        }

        public System.Data.Entity.DbSet<ProyectoCompra.Models.Libro> Libroes { get; set; }

        public System.Data.Entity.DbSet<ProyectoCompra.Models.Persona> Personas { get; set; }

        public System.Data.Entity.DbSet<ProyectoCompra.Models.Compra> Compras { get; set; }
    
    }
}
