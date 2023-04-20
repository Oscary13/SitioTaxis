using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SitioTaxis_API.Models
{
    [Table("Pasajero")]
    public class Pasajero
    {
        [Key]
        public int PasajeroID { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string NumeroTelefono { get; set; }
        [Required]
        public string CorreoElectronico { get; set; }
        [Required]
        public string Password { get; set; }

        public virtual List<Viaje> Viajes { get; set; }

    }
}