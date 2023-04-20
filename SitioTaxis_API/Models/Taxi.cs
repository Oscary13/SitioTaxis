using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SitioTaxis_API.Models
{
    [Table("Taxi")]
    public class Taxi
    {
        [Key]
        public int TaxiID { get; set; }
        [Required]
        public string NumeroPlaca { get; set; }
        [Required]
        public string Marca { get; set; }
        [Required]
        public string Modelo { get; set; }
        [Required]
        public string Year { get; set; }
        [Required]
        public string Horario { get; set; }
        [Required]
        public string Estatus { get; set; }
        public int SitioID { get; set; }
        public virtual Sitio Sitio { get; set; }

        public virtual List<TaxiChofer> Choferes { get; set; }

    }
}