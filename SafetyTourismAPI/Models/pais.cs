using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SafetyTourismAPI.Models
{
    public class Pais

    {
            [Key]
            public long Id { get; set; }

            public string Name { get; set; }

            public long IdZona { get; set; }

            [ForeignKey("IdZona")]
            public Zona Zona { get; set; }
    }
}
