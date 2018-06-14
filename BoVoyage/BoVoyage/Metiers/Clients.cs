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
        public string Email { get; set; }

        public virtual DossiersReservations DossiersReservations { get; set; }
    }
}
