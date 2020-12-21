using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SafetyTourismAPI.Models;

namespace SafetyTourismAPI.Data
{
    public class SafetyTourismAPIContext : DbContext
    {
        public SafetyTourismAPIContext (DbContextOptions<SafetyTourismAPIContext> options)
            : base(options)
        {
        }

        public DbSet<SafetyTourismAPI.Models.Virus> Virus { get; set; }
    }
}
