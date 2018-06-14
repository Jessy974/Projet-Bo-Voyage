using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoVoyage.Framework.UI

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
