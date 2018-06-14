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

        public DbSet<AgencesVoyages> AgencesVoyages { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Destinations> Destinations { get; set; }
        public DbSet<DossierReservation> DossierReservations { get; set; }
        public DbSet<Participants> Participants { get; set; }
        public DbSet<Personnes> Personnes { get; set; }
        public DbSet<Voyages> Voyages { get; set; }
    }
}
