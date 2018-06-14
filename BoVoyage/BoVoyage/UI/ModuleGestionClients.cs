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
            this.menu.AjouterElement(new ElementMenu("1.", "Afficher les clients")
            {
                FonctionAExecuter = this.AfficherClients
            });
            this.menu.AjouterElement(new ElementMenu("2.", "Créer un nouveau client")
            {
                FonctionAExecuter = this.AjouterClient
            });
            this.menu.AjouterElement(new ElementMenu("3.", "Modifier un client")
            {
                FonctionAExecuter = this.InitialiserMenu
            });
            this.menu.AjouterElement(new ElementMenu("4.", "Supprimer un client")
            {
                FonctionAExecuter = this.SupprimerClient
            });
            this.menu.AjouterElement(new ElementMenu("5.", "Rechercher un client")
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

            var liste = new BaseDonnees().Clients.ToList();
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
                Age = ConsoleSaisie.SaisirEntierObligatoire("Age : "),
                Email = ConsoleSaisie.SaisirChaineObligatoire("Email : ")

            };

            using (var bd = new BaseDonnees())
            {
                bd.Clients.Add(client);
                bd.SaveChanges();
            }
        }

        private void SupprimerClient()
        {
            ConsoleHelper.AfficherEntete("Supprimer un client");
            var liste = new BaseDonnees().Clients.ToList();

            var id = ConsoleSaisie.SaisirEntierObligatoire("Numero id: ");

            using (var sup = new BaseDonnees())
            {
                var client = sup.Clients.Single(x => x.IdClient == id);
                sup.Clients.Remove(client);
                sup.SaveChanges();
            }
        }

        private void RechercherClient()
        {
            ConsoleHelper.AfficherEntete("Rechercher un client");

            var nom = ConsoleSaisie.SaisirChaineObligatoire("Nom du client recherché : ");

            using (var recherche = new BaseDonnees())
            {
                var liste = recherche.Clients.Where(x => x.Nom.Contains(nom));
            }
        }
    }
}
