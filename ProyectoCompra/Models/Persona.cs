using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoCompra.Models
{
    public class Persona
    {
        public int PersonaID { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string nombre { get; set; }
        public DateTime fechaNacimiento { get; set; }

        public string email { get; set; }
        public string user { get; set; }
        public string password { get; set; }

        public virtual ICollection<Compra> Compras { get; set; }

    }
}