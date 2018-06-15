using BoVoyage.Framework.UI;
using BoVoyage.Metiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyage.UI
{
    public class StrategieAffichage
    {
        public static List<InformationAffichage> AffichageClient()
        {
            return new List<InformationAffichage>
            {
                InformationAffichage.Creer<Client>(x=>x.Id, "Id", 3),
                InformationAffichage.Creer<Client>(x=>x.Civilite, "Civilite", 4),
                InformationAffichage.Creer<Client>(x=>x.Nom, "Nom", 20),
                InformationAffichage.Creer<Client>(x=>x.Prenom, "Prenom", 20),
                InformationAffichage.Creer<Client>(x=>x.Adresse, "Adresse", 50),
                InformationAffichage.Creer<Client>(x=>x.Telephone, "Telephone", 10),
                InformationAffichage.Creer<Client>(x=>x.Email, "Email", 50),
                InformationAffichage.Creer<Client>(x=>x.DateNaissance, "DateNaissance", 15),
                InformationAffichage.Creer<Client>(x=>x.Age, "Age", 3),
            };
        }

        public static List<InformationAffichage> AffichageParticipant()
        {
            return new List<InformationAffichage>
            {
                InformationAffichage.Creer<Participant>(x=>x.Id, "Id", 3),
                InformationAffichage.Creer<Participant>(x=>x.NumeroUnique, "NumeroUnique", 50),
                InformationAffichage.Creer<Participant>(x=>x.Civilite, "Civilite", 4),
                InformationAffichage.Creer<Participant>(x=>x.Nom, "Nom", 20),
                InformationAffichage.Creer<Participant>(x=>x.Prenom, "Prenom", 20),
                InformationAffichage.Creer<Participant>(x=>x.Adresse, "Adresse", 50),
                InformationAffichage.Creer<Participant>(x=>x.Telephone, "Telephone", 10),
                InformationAffichage.Creer<Participant>(x=>x.DateNaissance, "DateNaissance", 15),
                InformationAffichage.Creer<Participant>(x=>x.Age, "Age", 3),
            };
        }

        public static List<InformationAffichage> AffichageAgence()
        {
            return new List<InformationAffichage>
            {
                InformationAffichage.Creer<AgenceVoyage>(x=>x.Id, "Id", 3),
                InformationAffichage.Creer<AgenceVoyage>(x=>x.Nom, "Nom", 50),
            };
        }

        public static List<InformationAffichage> AffichageDestination()
        {
            return new List<InformationAffichage>
            {
                InformationAffichage.Creer<Destination>(x=>x.Id, "Id", 3),
                InformationAffichage.Creer<Destination>(x=>x.Continent, "Continent", 20),
                InformationAffichage.Creer<Destination>(x=>x.Pays, "Pays", 20),
                InformationAffichage.Creer<Destination>(x=>x.Region, "Region", 20),
                InformationAffichage.Creer<Destination>(x=>x.Description, "Description", 50),
            };
        }

        public static List<InformationAffichage> AffichageDossierReservation()
        {
            return new List<InformationAffichage>
            {
                InformationAffichage.Creer<DossierReservation>(x=>x.Id, "Id", 3),
                InformationAffichage.Creer<DossierReservation>(x=>x.IdVoyage, "IdVoyage", 3),
                InformationAffichage.Creer<DossierReservation>(x=>x.NumeroUnique, "NumerUnique", 3),
                InformationAffichage.Creer<DossierReservation>(x=>x.NumeroCarteBancaire, "NumeroCarteBancaire", 50),
                InformationAffichage.Creer<DossierReservation>(x=>x.PrixTotal, "PrixTotal", 20),
                InformationAffichage.Creer<DossierReservation>(x=>x.Id, "IdClient", 10),
                InformationAffichage.Creer<DossierReservation>(x=>x.Id, "IdParticipant", 10),
            };
        }

        public static List<InformationAffichage> AffichageGestionVoyages()
        {
            return new List<InformationAffichage>
            {
                InformationAffichage.Creer<Voyage>(x=>x.Id, "Id", 3),
                InformationAffichage.Creer<Voyage>(x=>x.DateAller, "DateAller", 10),
                InformationAffichage.Creer<Voyage>(x=>x.DateRetour, "DateRetour", 10),
                InformationAffichage.Creer<Voyage>(x=>x.PlacesDisponibles, "PlaceDisponibles", 5),
                InformationAffichage.Creer<Voyage>(x=>x.TarifToutCompris, "TarifToutCompris", 5),
                InformationAffichage.Creer<Voyage>(x=>x.IdAgence, "IdAgenceVoyage", 3),
                InformationAffichage.Creer<Voyage>(x=>x.IdDestination, "IdDestination", 3),
            };
        }
    }
}
