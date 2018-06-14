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
        private static readonly List<InformationAffichage> strategieAffichageDossiersReservations =
            new List<InformationAffichage>
            {
                InformationAffichage.Creer<DossiersReservations>(x=>x.IdDossier, "Id", 3),
                InformationAffichage.Creer<DossiersReservations>(x=>x.NumeroCarteBancaire, "Id", 20),
                InformationAffichage.Creer<DossiersReservations>(x=>x.PrixTotal, "Id", 10),
                InformationAffichage.Creer<DossiersReservations>(x=>x.PrixTotal, "Id", 10),
            };

        private Menu menu;
        private void InitialiserMenu ()
        {
            this.menu = new Menu("Gestion des dossiers réservation");
            this.menu.AjouterElement(new ElementMenu("1.", "Afficher les réservations")
            {
                FonctionAExecuter = this.InitialiserMenu
            });
            this.menu.AjouterElement(new ElementMenu("2.", "Créer une réservation")
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


    }
}
