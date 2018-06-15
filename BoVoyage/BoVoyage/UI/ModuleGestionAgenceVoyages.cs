﻿using BoVoyage.Framework.UI;
using BoVoyage.Metiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyage.UI
{
    class ModuleGestionAgenceVoyages
    {
        private Menu menu;

        private static readonly List<InformationAffichage> strategieAffichageGestionAgenceVoyages =
            new List<InformationAffichage>
            {
                InformationAffichage.Creer<AgenceVoyage>(x=>x.Id, "Id", 3),
                InformationAffichage.Creer<AgenceVoyage>(x=>x.Nom, "Nom", 50),
            };

        private void InitialiserMenu()
        {
            this.menu = new Menu("Gestion des agences");
            this.menu.AjouterElement(new ElementMenu("1", "Afficher les agences")
            {
                FonctionAExecuter = this.AfficherAgences
            });
            this.menu.AjouterElement(new ElementMenu("2", "Créer une nouvelle agences")
            {
                FonctionAExecuter = this.AjouterAgence
            });
            this.menu.AjouterElement(new ElementMenu("3", "Modifier une agences")
            {
                FonctionAExecuter = this.ModifierAgence
            });
            this.menu.AjouterElement(new ElementMenu("4", "Supprimer une agences")
            {
                FonctionAExecuter = this.SupprimerAgence
            });
            this.menu.AjouterElement(new ElementMenu("5", "Rechercher une agences")
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
            ConsoleHelper.AfficherListe(liste, strategieAffichageGestionAgenceVoyages);
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
            // Reste a faire
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
