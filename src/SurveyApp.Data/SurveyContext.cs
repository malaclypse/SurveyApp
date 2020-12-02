using Microsoft.EntityFrameworkCore;
using SurveyApp.Data.Models;

namespace SurveyApp.Data
{
    public class SurveyContext : DbContext
    {
        private string _connectionString;

        public SurveyContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<User> User { get; set; }

        public DbSet<Survey> Survey { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Email);
                entity.Property(e => e.Email).IsRequired();
                entity.HasMany(e => e.Surveys);
            });

            modelBuilder.Entity<Survey>(entity =>
            {
                entity.HasKey(e => e.SurveyId);
                entity.HasOne(e => e.User)
                      .WithMany(u => u.Surveys);
            });

            //TODO: add all model mappings
        }
    }
}
