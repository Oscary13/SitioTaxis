using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SitioTaxis_API.Models
{
    [Table("TaxiChofer")]
    public class TaxiChofer
    {
        [Key]
        public int TaxiChoferID { get; set; }
        [ForeignKey("Taxi")]
        public int TaxiID { get; set; }
        public virtual Taxi Taxi { get; set; }
        [ForeignKey("Chofer")]
        public int ChoferID { get; set; }
        public virtual Chofer Chofer { get; set; }

        public virtual List<Viaje> Viajes { get; set; }

    }
}