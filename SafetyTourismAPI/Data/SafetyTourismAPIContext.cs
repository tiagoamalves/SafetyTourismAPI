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
        public SafetyTourismAPIContext(DbContextOptions<SafetyTourismAPIContext> options)
            : base(options)
        {
            /*
            LoadVirus();
            LoadPaises();
            LoadRecomendacoes();
            LoadSurtos();
            LoadZonas();
            */
        }
        /*
        public List<Virus> GetVirus() => Virus.Local.ToList<Virus>();
        private void LoadVirus()
        {
            Virus.Add(new Virus { VirusID = 1, NomeVirus = "Flu" });
        }

        public List<Pais> GetPaises() => Pais.Local.ToList<Pais>();
        private void LoadPaises()
        {
            Pais.Add(new Pais { Id = 1, Name = "Portugal" });
        }

        public List<Zona> GetZonas() => Zonas.Local.ToList<Zona>();
        private void LoadZonas()
        {
            Zonas.Add(new Zona { Id = 1, Name = "Porto" });
        }

        public List<Recomendacoe> GetRecomendacoes() => Recomendacoes.Local.ToList<Recomendacoe>();
        private void LoadRecomendacoes()
        {
            Recomendacoes.Add(new Recomendacoe { RecomendacoeId = 1, Info = "Lavar maos", IdZona = 1, ValidadeNota = 14});
        }
      
        public List<Surtos> Get() => Surtos.Local.ToList<Surtos>();
        private void LoadSurtos()
        {
            Surtos.Add(new Surtos { SurtosID = 1, VirusID = 1, Id = 1 });
        }
        */

        public DbSet<SafetyTourismAPI.Models.Virus> Virus { get; set; }

        public DbSet<SafetyTourismAPI.Models.Pais> Pais { get; set; }

        public DbSet<SafetyTourismAPI.Models.Recomendacoe> Recomendacoes { get; set; }

        public DbSet<SafetyTourismAPI.Models.Surtos> Surtos { get; set; }

        public DbSet<SafetyTourismAPI.Models.Zona> Zonas { get; set; }
    }
}
