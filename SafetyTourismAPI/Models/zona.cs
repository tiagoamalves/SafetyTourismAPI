using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace SafetyTourismAPI.Models
{
    public class Zona
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }
    }
}
