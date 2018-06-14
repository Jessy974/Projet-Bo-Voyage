using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoVoyage.Framework.UI;

   

namespace BoVoyage.UI
{
    class ModuleGestionDossierReservation
    {
        public Menu menu;
        public void AfficherMenu ()
        {
            this.menu = new Menu("Gestion des dossiers réservation");
            this.menu.AjouterElement(new ElementMenu("1.", "Afficher les réservations")
            {
                FonctionAExecuter = this.AfficherMenu
            });
            this.menu.AjouterElement(new ElementMenu("2.", "Créer une réservation")
            {
                FonctionAExecuter = this.AfficherMenu
            });
            this.menu.AjouterElement(new ElementMenuQuitterMenu("R", "Revenir au menu principal"));
        }

        public void Demarrer()
        {
            if (this.menu == null)
            {
                this.InitialiserMenu();
            }

            this.menu.Afficher();
        }


    }
}
