using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEST.Models
{
    public class Covoiturages
    {
        public int Id { get; set; }


        public string Depart { get; set; }
        public string Arrivee { get; set; }

        public string Date { get; set; }
        public string Horaire { get; set; }

        public string Nombre_de_place { get; set; }

        public string UserId { get; set; }
    }
}