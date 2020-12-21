using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SafetyTourismAPI.Models;

namespace SafetyTourismAPI.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<Pais> Pais { get; set; }

        public DbSet<SafetyTourismAPI.Models.Zona> Zona { get; set; }

        public DbSet<SafetyTourismAPI.Models.Recomendacoe> Recomendacoe { get; set; }
    }
}