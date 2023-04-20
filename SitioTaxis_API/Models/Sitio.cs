using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SitioTaxis_API.Models
{
    [Table("Sitio")]
    public class Sitio
    {
        [Key]
        public int SitioID { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string HorarioAtencion { get; set; }

        public virtual List<AdministradorSitio> AdministradorSitios { get; set; }
        public virtual List<Checador> Checadores { get; set; }
        public virtual List<Taxi> Taxis { get; set; }
        public virtual List<Chofer> Choferes { get; set; }

        //public int AdministradorSitioID { get; set; }
        //public virtual AdministradorSitio AdministradorSitio { get; set; }
        //public int ChecadorID { get; set; }
        //public virtual Checador Checador { get; set; }
        //public int TaxiID { get; set; }
        //public virtual Taxi Taxi { get; set; }
        //public int ChoferID { get; set; }
        //public virtual Chofer Chofer { get; set; }

    }
}