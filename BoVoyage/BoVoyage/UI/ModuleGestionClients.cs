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
    public class ModuleGestionClients
    {
        private Menu menu;

        

        private void InitialiserMenu()
        {
            this.menu = new Menu("Gestion des clients");
            this.menu.AjouterElement(new ElementMenu("1", "Afficher les clients")
            {
                FonctionAExecuter = this.AfficherClients
            });
            this.menu.AjouterElement(new ElementMenu("2", "Créer un nouveau client")
            {
                FonctionAExecuter = this.AjouterClient
            });
            this.menu.AjouterElement(new ElementMenu("3", "Modifier un client")
            {
                FonctionAExecuter = this.ModifierClient
            });
            this.menu.AjouterElement(new ElementMenu("4", "Supprimer un client")
            {
                FonctionAExecuter = this.SupprimerClient
            });
            this.menu.AjouterElement(new ElementMenu("5", "Rechercher un client")
            {
                FonctionAExecuter = this.RechercherClient
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

        private void AfficherClients()
        {
            ConsoleHelper.AfficherEntete("Clients");

            var liste = Application.GetBaseDonnees().Clients.ToList();
            ConsoleHelper.AfficherListe(liste, strategieAffichageGestionDossiersClients);
        }

        public void AjouterClient()
        {
            ConsoleHelper.AfficherEntete("Nouveau client");

            var client = new Client
            {
                Civilite = ConsoleSaisie.SaisirChaineObligatoire("Entrez votre civilité : "),
                Nom = ConsoleSaisie.SaisirChaineObligatoire("Nom : "),
                Prenom = ConsoleSaisie.SaisirChaineObligatoire("Prénom : "),
                Adresse = ConsoleSaisie.SaisirChaineObligatoire("Adresse : "),
                Telephone = ConsoleSaisie.SaisirChaineObligatoire("Telephone : "),
                DateNaissance = ConsoleSaisie.SaisirDateObligatoire("Date de naissance : "),
                Email = ConsoleSaisie.SaisirChaineObligatoire("Email : ")

            };
           
            using (var bd = Application.GetBaseDonnees())
            {
                bd.Clients.Add(client);
                bd.SaveChanges();
            }
        }

        private void SupprimerClient()
        {
            ConsoleHelper.AfficherEntete("Supprimer un client");
            var liste = Application.GetBaseDonnees().Clients.ToList();

            var id = ConsoleSaisie.SaisirEntierObligatoire("Numero id: ");

            using (var sup = Application.GetBaseDonnees())
            {
                var client = sup.Clients.Single(x => x.Id == id);
                sup.Clients.Remove(client);
                sup.SaveChanges();
            }
        }

        private void RechercherClient()
        {
            ConsoleHelper.AfficherEntete("Rechercher un client");

            var nom = ConsoleSaisie.SaisirChaineObligatoire("Nom du client recherché : ");

            using (var recherche = Application.GetBaseDonnees())
            {
                var liste = recherche.Clients.Where(x => x.Nom.Contains(nom));
            }
        }

        private void ModifierClient()
        {
            ConsoleHelper.AfficherEntete("Modifier un client");
            var liste = Application.GetBaseDonnees().Clients.ToList();
            ConsoleHelper.AfficherListe(liste, strategieAffichageGestionDossiersClients);
            var id = ConsoleSaisie.SaisirEntierObligatoire("Id");

            using (var mod = Application.GetBaseDonnees())
            {
                var client = mod.Clients.Single(x => x.Id == id);
                ConsoleHelper.AfficherEntete("Choisir l'index à modifier :");
                var index = ConsoleSaisie.SaisirEntierOptionnel("index à modifier :  1=Nom 2=Prénom 3=Adresse 4=Telephone 5=Datedenaissance 6=Email");

                switch (index)
                {
                    case 1:

                        client.Nom = ConsoleSaisie.SaisirChaineObligatoire("nom");
                        break;

                    case 2:

                        client.Prenom = ConsoleSaisie.SaisirChaineObligatoire("prenom");
                        break;

                    case 3:

                        client.Adresse = ConsoleSaisie.SaisirChaineObligatoire("Adresse");
                        break;
                    case 4:
                        client.Telephone = ConsoleSaisie.SaisirChaineObligatoire("Téléphone");
                        break;
                    case 5:
                        client.DateNaissance = ConsoleSaisie.SaisirDateObligatoire("../../..");
                        break;
                    case 6:
                        client.Adresse = ConsoleSaisie.SaisirChaineObligatoire("Email :");
                        break;
                    default:
                        Console.WriteLine("Erreur de saisie");
                        break;
                }

                mod.SaveChanges();
            }

        }
    }
}
