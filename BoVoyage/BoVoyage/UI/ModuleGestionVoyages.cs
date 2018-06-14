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
            this.menu.AjouterElement(new ElementMenu("1.", "Afficher les voyages")
            {
                FonctionAExecuter = this.InitialiserMenu
            });
            this.menu.AjouterElement(new ElementMenu("2.", "Créer un voyage")
            {
                FonctionAExecuter = this.InitialiserMenu
            });
            this.menu.AjouterElement(new ElementMenu("3.", "Supprimer un voyage")
            {
                FonctionAExecuter = this.InitialiserMenu
            });
            this.menu.AjouterElement(new ElementMenu("4.", "Modifier un voyage")
            {
                FonctionAExecuter = this.InitialiserMenu
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

        private void AfficherVoyages()
        {
            ConsoleHelper.AfficherEntete("Voyages");

            var liste = new BaseDonnees().Clients.ToList();
        }

        private void AjouterVoyage()
        {
            ConsoleHelper.AfficherEntete("Nouveau voyage");

            var voyage = new Voyage
            {
                DateAller = ConsoleSaisie.SaisirDateObligatoire("Date Aller : "),
                DateRetour = ConsoleSaisie.SaisirDateObligatoire("Date Retour : "),
                PlacesDisponibles = ConsoleSaisie.SaisirEntierObligatoire("Places disponibles : "),
                TarifToutCompris = ConsoleSaisie.SaisirDecimalObligatoire("Tarif tout compris : ")
            };

            using (var bd = new BaseDonnees())
            {
                bd.Voyages.Add(voyage);
                bd.SaveChanges();
            }
        }

        private void SupprimerVoyage()
        {
            ConsoleHelper.AfficherEntete("Supprimer un voyage");
            var liste = new BaseDonnees().Voyages.ToList();

            var id = ConsoleSaisie.SaisirEntierObligatoire("ID du voyage à supprimer: ");

            using (var sup = new BaseDonnees())
            {
                var voyage = sup.Voyages.Single(x => x.IdVoyage == id);
                sup.Voyages.Remove(voyage);
                sup.SaveChanges();
            }
        }
    }
}
