using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroSaga.Models;

namespace HeroSaga.Data
{
    public class HeroContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<Monster> Monsters { get; set; }
        public DbSet<Race> Races { get; set; }

        public HeroContext(): base("HeroContext")
        {
            
        }
    }
}
