using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SportsLeague.Models
{
    public class SportsDbContext : DbContext
    {
        public SportsDbContext()
        {
        }

        public DbSet<Division> Divisions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }

        public SportsDbContext(DbContextOptions<SportsDbContext> options) : base(options)
        {
        }
    }
}
