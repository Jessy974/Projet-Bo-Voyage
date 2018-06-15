using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoVoyage.Dal;
using BoVoyage.Framework.UI;
using BoVoyage.Metiers;

namespace BoVoyage.UI
{
    public class ModuleGestionVoyages
    {
        private Menu menu;




        private void InitialiserMenu()
        {
            this.menu = new Menu("Gestion des voyages");
            this.menu.AjouterElement(new ElementMenu("1", "Afficher les voyages")
            {
                FonctionAExecuter = this.AfficherVoyages
            });
            this.menu.AjouterElement(new ElementMenu("2", "Ajouter un voyage")
            {
                FonctionAExecuter = this.AjouterVoyage
            });
            this.menu.AjouterElement(new ElementMenu("3", "Modifier un voyage")
            {
                FonctionAExecuter = this.ModifierVoyage
            });
            this.menu.AjouterElement(new ElementMenu("4", "Supprimer un voyage")
            {
                FonctionAExecuter = this.SupprimerVoyage
            });
            this.menu.AjouterElement(new ElementMenu("5", "Rechercher un voyage")
            {
                FonctionAExecuter = this.RechercherVoyage
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

        public void AfficherVoyages()
        {
            ConsoleHelper.AfficherEntete("Voyage");
            var liste = Application.GetBaseDonnees().Voyages.ToList();
            ConsoleHelper.AfficherListe(liste, StrategieAffichage.AffichageGestiondesVoyages());

        }

        private void AjouterVoyage()
        {
            ConsoleHelper.AfficherEntete("Nouveau voyage");

            var voyage = new Voyage { };

            ConsoleHelper.AfficherEntete("liste des agences");
            var liste = Application.GetBaseDonnees().AgencesVoyages.ToList();
            ConsoleHelper.AfficherListe(liste, StrategieAffichage.AffichageAgence());
            using (var bd = Application.GetBaseDonnees())
            {
                voyage.IdAgence = ConsoleSaisie.SaisirEntierObligatoire("Entrer Id de l'agence");


                var listevoyage = bd.Voyages.Where(x => x.IdAgence == voyage.IdAgence);
                ConsoleHelper.AfficherListe(listevoyage, StrategieAffichage.AffichageDestination());


                ConsoleHelper.AfficherEntete("Liste des Destinations");
                var destinations = Application.GetBaseDonnees().Destinations.ToList();
                ConsoleHelper.AfficherListe(destinations, StrategieAffichage.AffichageDestination());

                voyage.IdDestination = ConsoleSaisie.SaisirEntierObligatoire("Entrer Id de la destination");

                voyage.DateAller = ConsoleSaisie.SaisirDateObligatoire("date d'aller");
                while (voyage.DateAller < DateTime.Today)
                {
                    ConsoleHelper.AfficherMessageErreur("date invalide");

                    voyage.DateAller = ConsoleSaisie.SaisirDateObligatoire("date d'aller");

                }
                voyage.DateRetour = ConsoleSaisie.SaisirDateObligatoire("date de retour");
                while (voyage.DateRetour < DateTime.Today)
                {
                    ConsoleHelper.AfficherMessageErreur("date invalide");

                    voyage.DateRetour = ConsoleSaisie.SaisirDateObligatoire("date de retour");
                }
                voyage.PlacesDisponibles = ConsoleSaisie.SaisirEntierObligatoire("Places disponibles : ");
                voyage.TarifToutCompris = ConsoleSaisie.SaisirDecimalObligatoire("Tarif tout compris : ");

                bd.Voyages.Add(voyage);
                bd.SaveChanges();
            }
        }

        private void SupprimerVoyage()
        {
            ConsoleHelper.AfficherEntete("Supprimer un voyage");
            var liste = new BaseDonnees().Voyages.ToList();

            var id = ConsoleSaisie.SaisirEntierObligatoire("ID du voyage à supprimer: ");

            using (var sup = Application.GetBaseDonnees())
            {
                var voyage = sup.Voyages.Single(x => x.Id == id);
                sup.Voyages.Remove(voyage);
                sup.SaveChanges();
            }
        }

        private void ModifierVoyage()
        {

        }

        private void RechercherVoyage()
        {

        }
    }
}
