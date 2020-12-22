using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SafetyTourismAPI.Models
{
    public class Surtos
    {
        [Key]
        public long SurtosID { get; set; }
        public long VirusID { get; set; }
        public long Id { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataInicio { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataFim { get; set; }

        public Virus Virus { get; set; }
        public Zona Zona { get; set; }
        public Pais pais { get; set; }

    }
}
