using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoCompra.Models
{
    public class Persona
    {
        [Required(ErrorMessage = "You must enter {0}")]
        public int PersonaID { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        public string apellidoPaterno { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        public string apellidoMaterno { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        public string nombre { get; set; }

        [Display(Name = "Date Of Birth")]
        [Required(ErrorMessage = "You must enter {0}")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime fechaNacimiento { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        public string email { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        public string user { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        public string password { get; set; }

        public virtual ICollection<Compra> Compras { get; set; }

    }
}