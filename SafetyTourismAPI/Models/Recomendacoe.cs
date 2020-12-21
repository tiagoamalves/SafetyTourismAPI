using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafetyTourismAPI.Models
{
    public class Recomendacoe
    {
        public long NotaId { get; set; }

        [ForeignKey]
        public Zona zona { get; set; }
        public DateTime date { get; set; }
        public string ValidadeNota { get; set; }
        public string info { get; set; }
    }
}
