using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace SitioTaxis_API.Models
{
    [Table("Checador")]
    public class Checador
    {
        [Key]
        public int ChecadorID { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string NumeroTelefono { get; set; }
        [Required]
        public string CorreoElectronico { get; set; }
        [Required]
        public string Password { get; set; }


        public int SitioID { get; set; }
        public virtual Sitio Sitio { get; set; }
    }
}