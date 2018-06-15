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
        private Menu menu;

        private void InitialiserMenu()
        {
            this.menu = new Menu("Gestion des dossiers réservation");
            this.menu.AjouterElement(new ElementMenu("1", "Afficher les réservations")
            {
                FonctionAExecuter = this.AfficherReservation
            });
            this.menu.AjouterElement(new ElementMenu("2", "Créer une réservation")
            {
                FonctionAExecuter = this.CreerReservation
            });
            this.menu.AjouterElement(new ElementMenu("3", "Modifier une réservation")
            {
                FonctionAExecuter = this.ModifierReservation
            });
            this.menu.AjouterElement(new ElementMenu("4", "Supprimer une réservation")
            {
                FonctionAExecuter = this.SupprimerReservation
            });
            this.menu.AjouterElement(new ElementMenu("5", "Rechercher une réservation")
            {
                FonctionAExecuter = this.RechercherReservation
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

        public void AfficherReservation()
        {
            ConsoleHelper.AfficherEntete("Dossier Réservation");
            var liste = Application.GetBaseDonnees().DossiersReservations.ToList();
            ConsoleHelper.AfficherListe(liste, StrategieAffichage.AffichageDossierReservation());
        }

        public void CreerReservation()
        {
            ConsoleHelper.AfficherEntete("Nouvelle réservation");

            var reservation = new DossierReservation { };

            ConsoleHelper.AfficherEntete("liste des participants");
            var liste = Application.GetBaseDonnees().Participants.ToList();
            ConsoleHelper.AfficherListe(liste, StrategieAffichage.AffichageParticipant());
            using (var bd = Application.GetBaseDonnees())
            {
                reservation.IdParticipant = ConsoleSaisie.SaisirEntierObligatoire("Entrer Id du participant");

                var listeparticipant = bd.Participants.Where(x => x.Id == reservation.IdParticipant);
                ConsoleHelper.AfficherListe(listeparticipant, StrategieAffichage.AffichageParticipant());


                ConsoleHelper.AfficherEntete("Liste des Voyages");
                var listevoyage = Application.GetBaseDonnees().Voyages.ToList();
                var listes = bd.Voyages.Where(x => x.Id == reservation.IdVoyage);
                ConsoleHelper.AfficherListe(listes, StrategieAffichage.AffichageGestionVoyages());
                reservation.IdVoyage = ConsoleSaisie.SaisirEntierObligatoire("Entrer Id du voyage");
                


                reservation.NumeroUnique = ConsoleSaisie.SaisirEntierObligatoire("Entrez le numéro unique:");
                reservation.NumeroCarteBancaire = ConsoleSaisie.SaisirChaineObligatoire("Entrez numéro de carte bancaire:");

                bd.DossiersReservations.Add(reservation);
                bd.SaveChanges();
            }
        }

        public void ModifierReservation()
        {
            ConsoleHelper.AfficherEntete("Modifier une reservation");
            var liste = Application.GetBaseDonnees().DossiersReservations.ToList();
            StrategieAffichage.AffichageDossierReservation();
            var id = ConsoleSaisie.SaisirEntierObligatoire("Id");

            using (var mod = Application.GetBaseDonnees())
            {
                var reservation = mod.DossiersReservations.Single(x => x.Id == id);
                ConsoleHelper.AfficherEntete("Choix du champ à modifier :");
                var index = ConsoleSaisie.SaisirEntierOptionnel("Choix :  1.NumeroUnique, 2.NumeroCarteBancaire, 3.PrixTotal, 4.IdVoyage, 5.IdParticipant, 6.IdClient");

                switch (index)
                {
                    case 1:
                        reservation.NumeroUnique = ConsoleSaisie.SaisirEntierObligatoire("Numero");
                        break;

                    case 2:
                        reservation.NumeroCarteBancaire = ConsoleSaisie.SaisirChaineObligatoire("Numero C.B");
                        break;

                    case 3:
                        reservation.PrixTotal = ConsoleSaisie.SaisirDecimalObligatoire("Prix total");
                        break;

                    case 4:
                        reservation.IdVoyage = ConsoleSaisie.SaisirEntierObligatoire("Id voyage");
                        break;

                    case 5:
                        reservation.IdParticipant = ConsoleSaisie.SaisirEntierObligatoire("Id participant");
                        break;

                    case 6:
                        reservation.IdClient = ConsoleSaisie.SaisirEntierObligatoire("Id client");
                        break;

                    default:
                        Console.WriteLine("Erreur de saisie");
                        break;
                }
                mod.SaveChanges();
            }
        }

        public void SupprimerReservation()
        {
            ConsoleHelper.AfficherEntete("Supprimer une reservation");
            var liste = Application.GetBaseDonnees().DossiersReservations.ToList();

            var id = ConsoleSaisie.SaisirEntierObligatoire("Numero id: ");

            using (var sup = Application.GetBaseDonnees())
            {
                var dossiersReservations = sup.DossiersReservations.Single(x => x.Id == id);
                sup.DossiersReservations.Remove(dossiersReservations);
                sup.SaveChanges();
            }
        }

        public void RechercherReservation()
        {
            ConsoleHelper.AfficherEntete("Rechercher une reservation");

            var id = ConsoleSaisie.SaisirEntierObligatoire("ID de la reservation recherchée : ");

            using (var recherche = Application.GetBaseDonnees())
            {
                var liste = recherche.DossiersReservations.Where(x => x.Id == id);
            }
        }
    }
}
