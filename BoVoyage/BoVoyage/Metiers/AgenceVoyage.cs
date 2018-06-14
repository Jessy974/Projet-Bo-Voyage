using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyage.Metiers
{
    class AgenceVoyage
    {
        public int IdAgence { get; set; }
        public string Nom { get; set; }

        public virtual Voyage Voyages { get; set; }
    }
}
