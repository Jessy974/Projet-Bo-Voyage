﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyage.Metiers
{
    public class DossierReservation
    {
        public int IdDossier { get; set; }
        public int NumeroUnique { get; set; }
        public string NumeroCarteBancaire { get; set; }
        public decimal PrixTotal { get; set; }

        [ForeignKey("IdVoyage")]
        public virtual Voyage Voyages { get; set; }
        public int IdVoyage { get; set; }

        [ForeignKey("IdClient")]
        public virtual Client Clients { get; set; }
        public int IdClient { get; set; }

        [ForeignKey("IdParticipant")]
        public virtual Participant Participants { get; set; }
        public int IdParticipant { get; set; }

        /*
        void Annuler();
        void ValiderSolvabilité();
        void Accepter();
        /*/
    }
}