using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App1.Models
{
    public class Covoiturage
    {
        public int    Id { get; set; }
        public string ville_de_depart { get; set; }
        public string ville_d_arrivée { get; set; }
        public string date_du_voyage { get; set; }
        public string prix { get; set; }

        public string UserId { get; set; }

    }
}