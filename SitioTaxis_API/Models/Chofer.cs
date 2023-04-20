using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace SitioTaxis_API.Models
{
    [Table("Chofer")]
    public class Chofer
    {
        [Key]
        public int ChoferID { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string NumeroLicencia { get; set; }
        [Required]
        public string NumeroTelefono { get; set; }
        [Required]
        public string CorreoElectronico { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int SitioID { get; set; }

        public virtual Sitio Sitio { get; set; }
        public virtual List<TaxiChofer> Taxis { get; set; }
    }
}