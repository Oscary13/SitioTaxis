using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SitioTaxis_API.Models
{
    [Table("Viaje")]
    public class Viaje
    {
        [Key]
        public int ViajeID { get; set; }
        [Required]
        public string Fecha { get; set; }
        [Required]
        public String HoraInicio { get; set; }
        [Required]
        public string UbicacionInicio { get; set; }
        [Required]
        public string HoraFinal { get; set; }
        [Required]
        public string UbicacionFinal { get; set; }
        [Required]
        public string TiempoTotal { get; set; }
        [Required]
        public string Estatus { get; set; }

        public int PasajeroID { get; set; }
        public virtual Pasajero Pasajero { get; set; }

        [ForeignKey("TaxiChofer")]
        public int TaxiChoferID { get; set; }
        public virtual TaxiChofer TaxiChofer { get; set; }


    }
}