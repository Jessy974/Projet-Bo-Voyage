using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyage.Metiers
{
    [Table("DossiersReservations")]
    public class DossierReservation
    {
        public int Id { get; set; }
        public int NumeroUnique { get; set; }
        public string NumeroCarteBancaire { get; set; }
        public decimal PrixTotal { get; set; }

        [ForeignKey("IdVoyage")]
        public virtual Voyage Voyages { get; set; }
        public int IdVoyage { get; set; }


        public enum EtatDossierReservation { }

        public enum RaisonAnnulationDossier { }
        /*
        void Annuler();
        void ValiderSolvabilité();
        void Accepter();
        /*/
    }
}
