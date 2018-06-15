using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoVoyage.Framework.UI;
using BoVoyage.Metiers;

namespace BoVoyage.UI
{
    public class ModuleGestionDossiersReservations
    {
        private Menu menu;      

        private void InitialiserMenu ()
        {
            this.menu = new Menu("Gestion des dossiers réservation");
            this.menu.AjouterElement(new ElementMenu("1", "Afficher les réservations")
            {
                FonctionAExecuter = this.AfficherReservation
            });
            this.menu.AjouterElement(new ElementMenu("2", "Créer une réservation")
            {
                FonctionAExecuter = this.CreerReservation
            });
            this.menu.AjouterElement(new ElementMenu("3", "Modifier une réservation")
            {
                FonctionAExecuter = this.ModifierReservation
            });
            this.menu.AjouterElement(new ElementMenu("4", "Supprimer une réservation")
            {
                FonctionAExecuter = this.SupprimerReservation
            });
            this.menu.AjouterElement(new ElementMenu("5", "Rechercher une réservation")
            {
                FonctionAExecuter = this.RechercherReservation
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

        public void AfficherReservation()
        {

        }

        public void CreerReservation()
        { 
            
            /*using (var bd = Application.GetBaseDonnees())
            {
                var id = ConsoleSaisie.SaisirEntierObligatoire("Entrer Id du voyage");

                var liste = bd.Voyages.Where(x => x.Id == id);
                ConsoleHelper.AfficherListe(liste);

            }*/
        }

        public void ModifierReservation()
        {

        }

        public void SupprimerReservation()
        {

        }

        public void RechercherReservation()
        {

        }
    }
}
