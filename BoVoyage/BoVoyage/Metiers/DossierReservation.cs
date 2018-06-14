using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyage.Metiers
{
    class DossierReservation
    {
        public int NumeroUnique { get; set; }
        public string NumeroCarteBancaire { get; set; }
        public decimal PrixTotal { get; set; }

        /*
        void Annuler();
        void ValiderSolvabilité();
        void Accepter();
        /*/
    }
}
