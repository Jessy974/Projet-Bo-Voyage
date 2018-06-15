using BoVoyage.Framework.UI;
using BoVoyage.Metiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyage.UI
{
    class ModuleGestionDestinations
    {
        private Menu menu;

        private static readonly List<InformationAffichage> strategieAffichageGestionDestinations =
            new List<InformationAffichage>
            {
                InformationAffichage.Creer<Destination>(x=>x.Id, "Id", 3),
                InformationAffichage.Creer<Destination>(x=>x.Continent, "Continent", 20),
                InformationAffichage.Creer<Destination>(x=>x.Pays, "Pays", 20),
                InformationAffichage.Creer<Destination>(x=>x.Region, "Region", 20),
                InformationAffichage.Creer<Destination>(x=>x.Description, "Description", 50),
            };

        private void InitialiserMenu()
        {
            this.menu = new Menu("Gestion des agences");
            this.menu.AjouterElement(new ElementMenu("1", "Afficher les destinations")
            {
                FonctionAExecuter = this.AfficherDestinations
            });
            this.menu.AjouterElement(new ElementMenu("2", "Créer une nouvelle destination")
            {
                FonctionAExecuter = this.AjouterDestination
            });
            this.menu.AjouterElement(new ElementMenu("3", "Modifier une destination")
            {
                FonctionAExecuter = this.ModifierDestination
            });
            this.menu.AjouterElement(new ElementMenu("4", "Supprimer une destination")
            {
                FonctionAExecuter = this.SupprimerDestination
            });
            this.menu.AjouterElement(new ElementMenu("5", "Rechercher une destination")
            {
                FonctionAExecuter = this.RechercherDestination
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

        private void AfficherDestinations()
        {
            ConsoleHelper.AfficherEntete("Destinations");

            var liste = Application.GetBaseDonnees().Destinations.ToList();
            ConsoleHelper.AfficherListe(liste, strategieAffichageGestionDestinations);
        }

        public void AjouterDestination()
        {
            ConsoleHelper.AfficherEntete("Nouvelle destination");

            var destination = new Destination
            {
                Continent = ConsoleSaisie.SaisirChaineObligatoire("Entrez le Continent"),
                Pays = ConsoleSaisie.SaisirChaineObligatoire("Entrez le pays"),
                Region = ConsoleSaisie.SaisirChaineObligatoire("Entrez la region"),
                Description = ConsoleSaisie.SaisirChaineObligatoire("Entrez la description"),
            };

            using (var bd = Application.GetBaseDonnees())
            {
                bd.Destinations.Add(destination);
                bd.SaveChanges();
            }
        }

        private void ModifierDestination()
        {
            // Reste a faire
        }

        private void SupprimerDestination()
        {
            ConsoleHelper.AfficherEntete("Supprimer une destination");
            var liste = Application.GetBaseDonnees().Destinations.ToList();

            var id = ConsoleSaisie.SaisirEntierObligatoire("Numero id: ");

            using (var sup = Application.GetBaseDonnees())
            {
                var destination = sup.Destinations.Single(x => x.Id == id);
                sup.Destinations.Remove(destination);
                sup.SaveChanges();
            }
        }

        private void RechercherDestination()
        {
            ConsoleHelper.AfficherEntete("Rechercher une destination");

            var pays = ConsoleSaisie.SaisirChaineObligatoire("Pays de la destination recherchée : ");

            using (var recherche = Application.GetBaseDonnees())
            {
                var liste = recherche.Destinations.Where(x => x.Pays.Contains(pays));
            }
        }
    }
}
