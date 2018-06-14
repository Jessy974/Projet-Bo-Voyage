using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyage.Frameworks
{

    public sealed class InformationAffichageAttribute : Attribute
    {
        public int NombreCaracteres { get; set; }

        public string Entete { get; set; }
    }

}
