namespace SurveyApp.Data
{
    using Microsoft.EntityFrameworkCore;
    using SurveyApp.Data.Models;

    public class SurveyContext : DbContext
    {
        public SurveyContext(DbContextOptions<SurveyContext> options)
            : base(options)
        {
        }

        public DbSet<UserEntity> User { get; set; }

        public DbSet<SurveyEntity> Survey { get; set; }

        public DbSet<CategoryEntity> Category { get; set; }
        
        public DbSet<CategoryTextMappingEntity> CategoryTextMapping { get; set; }
        
        public DbSet<TextEntryEntity> TextEntry { get; set; }

        public DbSet<VariantEntity> Variant { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.HasKey(e => e.Email);
                entity.Property(e => e.Email).IsRequired();
                entity.HasIndex(e => e.Email);
                entity.HasMany(e => e.Surveys);
                entity.Property(e => e.EnglishLevel);
                entity.Property(e => e.NativeLanguage);
                entity.Property(e => e.LastModifiedDate);
                entity.Property(e => e.Gender);
                entity.Property(e => e.CreatedDate).IsRequired();
            });

            modelBuilder.Entity<SurveyEntity>(entity =>
            {
                entity.HasKey(e => e.SurveyId);
                entity.Property(e => e.SurveyId).IsRequired();
                entity.Property(e => e.IsCompleted);
                entity.Property(e => e.IsDeleted);
                entity.Property(e => e.CreatedDate);
                entity.Property(e => e.LastModifiedDate);
                entity.Property(e => e.FinishedOnDate);
                entity.HasOne(e => e.User)
                      .WithMany(u => u.Surveys);
            });

            modelBuilder.Entity<TextEntryEntity>(entity =>
            {
                entity.HasKey(e => e.TextId);
                entity.Property(e => e.TextId).IsRequired();
                entity.Property(e => e.Text).IsRequired();
            });

            modelBuilder.Entity<CategoryEntity>(entity =>
            {
                entity.HasKey(e => e.CategoryId);
                entity.Property(e => e.CategoryId).IsRequired();
            });

            modelBuilder.Entity<VariantEntity>(entity =>
            {
                entity.HasKey(e => e.VariantId);
                entity.Property(e => e.VariantId).IsRequired();
                entity.Property(e => e.TotalCount).HasDefaultValue(0);
                entity.Property(e => e.Text1Id).IsRequired();
                entity.Property(e => e.Text2Id).IsRequired();
                entity.Property(e => e.Text3Id).IsRequired();
                entity.Property(e => e.Text4Id).IsRequired();
                entity.Property(e => e.Text5Id).IsRequired();
                entity.Property(e => e.Text6Id).IsRequired();
                entity.Property(e => e.Text7Id).IsRequired();
                entity.Property(e => e.Text8Id).IsRequired();
            });

            modelBuilder.Entity<CategoryTextMappingEntity>(entity => 
            {
                entity.HasKey(e => e.MappingId);
                entity.HasOne(e => e.Survey).WithMany(m => m.Mappings);
            });
            
            // This inserts all 20 texts into the db initially if they don't already exist.
            modelBuilder.SeedTexts();

            // This inserts all 5 categories.
            modelBuilder.SeedCategories();

            // This inserts all 400 variants into the db
            modelBuilder.SeedVariants();
        }
    }
}
