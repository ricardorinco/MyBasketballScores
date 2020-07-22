using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using MyBasketballScores.Domain.Entities;
using MyBasketballScores.Infra.Data.Persistences.DataContext.Maps;
using MyBasketballScores.Shared;

namespace MyBasketballScores.Infra.Data.Persistences.DataContext
{
    public class MyBasketballScoresContext : DbContext
    {
        public DbSet<Score> Scores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                Settings.ConnectionString,
                options => options.EnableRetryOnFailure()
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<Notification>();

            modelBuilder.ApplyConfiguration(new ScoreMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
