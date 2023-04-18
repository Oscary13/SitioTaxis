using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SitioTaxis_API.Models
{
    [Table("TaxiChofer")]
    public class TaxiChofer
    {
        public int TaxiChoferID { get; set; }
        public int ChoferID { get; set; }
        public virtual Chofer Chofer { get; set; }
        public int TaxiID { get; set; }
        public virtual Taxi Taxi { get; set; }
        //public int ViajeID { get; set; }
        public virtual Viaje Viaje { get; set; }
    }
}