using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyage.Metiers
{
    class DossiersReservations
    {
        public int IdDossier { get; set; }
        public string NumeroCarteBancaire { get; set; }
        public decimal PrixTotal { get; set; }

        public virtual Clients Clients { get; set; }
        public virtual Voyages Voyages { get; set; }
        public virtual Participants Participants { get; set; }
        /*
        void Annuler();
        void ValiderSolvabilité();
        void Accepter();
        /*/
    }
}
