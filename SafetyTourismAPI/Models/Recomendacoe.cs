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

        [ForeignKey("Id")]
        public Zona Zona { get; set; }
        public DateTime Data { get; set; }
        public string ValidadeNota { get; set; }
        public string info { get; set; }
    }
}
