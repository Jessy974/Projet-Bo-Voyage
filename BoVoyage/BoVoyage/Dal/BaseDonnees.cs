using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoVoyage.Metiers;

namespace BoVoyage.Dal
{
    class BaseDonnees : DbContext
    {
        public BaseDonnees(string connectionString = "Connexion")
            : base(connectionString)
        {
        }

        public DbSet<AgenceVoyage> AgencesVoyages { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Destinations> Destinations { get; set; }
        public DbSet<DossierReservation> DossierReservations { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Personne> Personnes { get; set; }
        public DbSet<Voyage> Voyages { get; set; }
    }
}
