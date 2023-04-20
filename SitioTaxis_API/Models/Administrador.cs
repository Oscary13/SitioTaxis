using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SitioTaxis_API.Models
{
    [Table("Administrador")]
    public class Administrador
    {
        [Key]
        public int AdministradorID { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string NumeroTelefono { get; set; }
        [Required]
        public string CorreoElecronico { get; set; }
        [Required]
        public string Password { get; set; }
    }
}