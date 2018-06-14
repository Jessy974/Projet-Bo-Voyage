using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyage.Metiers
{
    class Clients : Personnes
    {
        public int IdClient { get; set; }
        public string Civilite { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public string Telephone { get; set; }
        public System.DateTime DateNaissance { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        public virtual DossiersReservations DossiersReservations { get; set; }
    }
}
