using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyage.UI
{
    public class Application
    {
        private MenuPrincipal;
        private GestionVoyage gestionVoyage; 
        private GestionDossierReservation gestionDossierReservation;

        public GestionVoyage GetGestionVoyage
        {
            get => this.gestionVoyage;
        }

        public GestionDossierReservation GestionDossierReservation
        {
            get => this.gestionDossierReservation;
        }
    }
}
