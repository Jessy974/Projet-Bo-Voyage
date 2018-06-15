using BoVoyage.Framework.UI;
using BoVoyage.Metiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyage.UI
{
    public class ModuleGestionAgenceVoyages
    {
        private Menu menu;
            
        private void InitialiserMenu()
        {
            this.menu = new Menu("Gestion des agences");

            this.menu.AjouterElement(new ElementMenu("1", "Afficher les agences")
            {
                FonctionAExecuter = this.AfficherAgences
            });
            this.menu.AjouterElement(new ElementMenu("2", "Créer une agence")
            {
                FonctionAExecuter = this.AjouterAgence
            });
            this.menu.AjouterElement(new ElementMenu("3", "Modifier une agence")
            {
                FonctionAExecuter = this.ModifierAgence
            });
            this.menu.AjouterElement(new ElementMenu("4", "Supprimer une agence")
            {
                FonctionAExecuter = this.SupprimerAgence
            });
            this.menu.AjouterElement(new ElementMenu("5", "Rechercher une agence")
            {
                FonctionAExecuter = this.RechercherAgence
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

        private void AfficherAgences()
        {
            ConsoleHelper.AfficherEntete("Agences voyages");
            
            var liste = Application.GetBaseDonnees().AgencesVoyages.ToList();
            ConsoleHelper.AfficherListe(liste, StrategieAffichage.AffichageAgence());
        }

        public void AjouterAgence()
        {
            ConsoleHelper.AfficherEntete("Nouvelle agences");

            var agenceVoyage = new AgenceVoyage
            {
                Nom = ConsoleSaisie.SaisirChaineObligatoire("Entrez le nom de l'agence")
            };

            using (var bd = Application.GetBaseDonnees())
            {
                bd.AgencesVoyages.Add(agenceVoyage);
                bd.SaveChanges();
            }
        }

        private void ModifierAgence()
        {
            ConsoleHelper.AfficherEntete("Modifier l'agence");
            var liste = Application.GetBaseDonnees().AgencesVoyages.ToList();

            var nom = ConsoleSaisie.SaisirChaineObligatoire("Nom");

            using (var mod = Application.GetBaseDonnees())
            {
                var agenceVoyage =  mod.AgencesVoyages.Single(x => x.Nom.Contains(nom));
                mod.SaveChanges();
            }
        }

        private void SupprimerAgence()
        {
            ConsoleHelper.AfficherEntete("Supprimer une agence");
            var liste = Application.GetBaseDonnees().AgencesVoyages.ToList();

            var id = ConsoleSaisie.SaisirEntierObligatoire("Numero id: ");

            using (var sup = Application.GetBaseDonnees())
            { 
                var agenceVoyage = sup.AgencesVoyages.Single(x => x.Id == id);
                sup.AgencesVoyages.Remove(agenceVoyage);
                sup.SaveChanges();
            }
        }

        private void RechercherAgence()
        {
            ConsoleHelper.AfficherEntete("Rechercher une agence");

            var nom = ConsoleSaisie.SaisirChaineObligatoire("Nom de l'agence recherchée : ");

            using (var recherche = Application.GetBaseDonnees())
            {
                var liste = recherche.AgencesVoyages.Where(x => x.Nom.Contains(nom));
            }
        }
    }
}
