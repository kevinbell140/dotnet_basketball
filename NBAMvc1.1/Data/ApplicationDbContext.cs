using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NBAMvc1._1.Areas.Identity;
using NBAMvc1._1.Models;

namespace NBAMvc1._1.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<NBAMvc1._1.Models.Player> Player { get; set; }
        public DbSet<NBAMvc1._1.Models.Team> Team { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Player>()
                .Property(p => p.Height)
                .HasDefaultValue(0);
            builder.Entity<Player>()
                .Property(p => p.Weight)
                .HasDefaultValue(0);

            builder.Entity<PlayerMyTeam>()
                .HasKey(p => new { p.PlayerID, p.MyTeamID });
        }

        public DbSet<NBAMvc1._1.Models.PlayerSeasonStats> PlayerSeasonStats { get; set; }

        public DbSet<NBAMvc1._1.Models.Standings> Standings { get; set; }

        public DbSet<NBAMvc1._1.Models.Game> Game { get; set; }

        public DbSet<NBAMvc1._1.Models.PlayerGameStats> PlayerGameStats { get; set; }

    }
}
