using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace BoVoyage.Metiers
{
    [Table("Voyages")]
    public class Voyage
    {
        public int IdVoyage { get; set; }
        public DateTime DateAller { get; set; }
        public DateTime DateRetour { get; set; }
        public int PlacesDisponibles { get; set; }
        public decimal TarifToutCompris { get; set; }

        [ForeignKey("IdAgenceVoyage")]
        public virtual  AgenceVoyage AgenceVoyage { get; set; }
        public int IdAgenceVoyage { get; set; }

        [ForeignKey("IdDestination")]
        public virtual Destination Destination { get; set; }
        public int IdDestination { get; set; }



        /*
        void Reserver
        /*/
    }
}
