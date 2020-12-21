using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace SafetyTourismAPI.Models
{
    public class Recomendacoe
    {
        public long NotaId { get; set; }
        public string Info { get; set; }
        public Zona Zona { get; set; }
        public DateTime Date { get; set; }
        public int ValidadeNota { get; set; }
    }
}
