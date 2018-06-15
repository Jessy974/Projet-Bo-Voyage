﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoVoyage.Metiers
{
    [Table("Clients")]
    public class Client : Personne
    {
        public string Email { get; set; }
        [ForeignKey("IdClient")]
        public virtual Client Clients { get; set; }
        public int IdClient { get; set; }
    }
}
