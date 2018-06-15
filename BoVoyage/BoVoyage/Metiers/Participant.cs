using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyage.Metiers
{
    [Table("Participants")]
    public class Participant : Personne
    {
        public int NumeroUnique { get; set; }
        public double Reduction
        {
            get
            { 
                if (this.Age <12)
                    return this.Reduction * 0.6;
                else
                    return 0;
            }
        }
    }

      
    }
}
