using BoVoyage.Framework.UI;
using BoVoyage.Metiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyage.UI
{
    public class ModuleGestionDestinations
    {
        public Menu menu;

       
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
            StrategieAffichage.AffichageDestination();
           
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
            ConsoleHelper.AfficherEntete("Modifier une destination");
            var liste = Application.GetBaseDonnees().Destinations.ToList();
            StrategieAffichage.AffichageDestination();
            var id = ConsoleSaisie.SaisirEntierObligatoire("Id");


            using (var mod = Application.GetBaseDonnees())
            {
                var destination = mod.Destinations.Single(x => x.Id == id);
                ConsoleHelper.AfficherEntete("Choisir l'index à modifier :");
                var index = ConsoleSaisie.SaisirEntierOptionnel("index à modifier :  1=COntinent 2=Pays 3=Région 4=Description");


                switch (index)
                {
                    case 1:

                       destination.Continent = ConsoleSaisie.SaisirChaineObligatoire("nom");
                        break;

                    case 2:

                       destination.Pays = ConsoleSaisie.SaisirChaineObligatoire("prenom");
                        break;

                    case 3:

                        destination.Region = ConsoleSaisie.SaisirChaineObligatoire("Adresse");
                        break;
                    case 4:
                       destination.Description = ConsoleSaisie.SaisirChaineObligatoire("Téléphone");
                        break;
                    default:
                        Console.WriteLine("Erreur de saisie");
                        break;
                }



                mod.SaveChanges();
            }
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
