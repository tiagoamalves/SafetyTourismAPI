using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafetyTourismAPI.Models
{
    public class Surtos
    {
        public long SurtosID { get; set; }
        public long VirusID { get; set; }
        public long Id { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public Virus Virus { get; set; }
        public Zona Zona { get; set; }
        public Pais pais { get; set; }

    }
}
