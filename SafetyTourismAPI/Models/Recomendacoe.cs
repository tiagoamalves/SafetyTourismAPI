using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SafetyTourismAPI.Models
{
    public class Recomendacoe
    {
        public long RecomendacoeId { get; set; }

        public string Info { get; set; }

        [ForeignKey("IDZona")]
        public long IdZona { get; set; }

        public Zona Zona { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        
        public int ValidadeNota { get; set; }
    }
}
