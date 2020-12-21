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
        public string info { get; set; }

        [ForeignKey("CodigoZonaGeográfica")]
        public Zona zona { get; set; }
        public DateTime date { get; set; }
        public int ValidadeNota { get; set; }
    }
}
