using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SafetyTourismAPI.Models
{
    public class Pais
    {
            public long Id { get; set; }
            public string Name { get; set; }

            [ForeignKey("IDZonaGeografica")]
            public Zona Zona { get; set; }
    }
}
