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

        public DbSet<GroupEntity> Group { get; set; }
        
        public DbSet<GroupTextMappingEntity> GroupTextMapping { get; set; }
        
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
                entity.Property(e => e.Email).IsRequired().HasMaxLength(254);
                entity.HasIndex(e => e.Email);
                entity.HasMany(e => e.Surveys);
                entity.Property(e => e.EnglishLevel);
                entity.Property(e => e.NativeLanguage).IsRequired();
                entity.Property(e => e.Country).IsRequired();
                entity.Property(e => e.LastModifiedDate);
                entity.Property(e => e.Gender);
                entity.Property(e => e.CreatedDate).IsRequired();
            });

            modelBuilder.Entity<SurveyEntity>(entity =>
            {
                entity.HasKey(e => new { e.SurveyId });
                entity.HasIndex(e => new { e.UserEmail, e.VariantId }).IsUnique();
                entity.Property(e => e.SurveyId).IsRequired().ValueGeneratedOnAdd();
                entity.Property(e => e.UserEmail).IsRequired();
                entity.Property(e => e.IsCompleted);
                entity.Property(e => e.IsDeleted);
                entity.Property(e => e.CreatedDate);
                entity.Property(e => e.LastModifiedDate);
                entity.Property(e => e.FinishedOnDate);
                entity.HasOne(e => e.User)
                      .WithMany(u => u.Surveys);
                entity.HasOne(e => e.Variant);
            });

            modelBuilder.Entity<TextEntryEntity>(entity =>
            {
                entity.HasKey(e => e.TextId);
                entity.Property(e => e.TextId).IsRequired().ValueGeneratedOnAdd();
                entity.Property(e => e.Text).IsRequired();
            });

            modelBuilder.Entity<GroupEntity>(entity =>
            {
                entity.HasKey(e => e.GroupId);
                entity.Property(e => e.GroupId).IsRequired().ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<VariantEntity>(entity =>
            {
                entity.HasKey(e => e.VariantId);
                entity.Property(e => e.VariantId).IsRequired().ValueGeneratedOnAdd().HasMaxLength(100);
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

            modelBuilder.Entity<GroupTextMappingEntity>(entity => 
            {
                entity.HasKey(e => e.MappingId);
                entity.Property(e => e.MappingId).IsRequired().ValueGeneratedOnAdd();
                entity.HasOne(e => e.Survey).WithMany(m => m.Mappings);
                entity.HasOne(e => e.TextEntry);
                entity.HasOne(e => e.Group);
            });
            
            // This inserts all 20 texts into the db initially if they don't already exist.
            modelBuilder.SeedTexts();

            // This inserts all 5 categories.
            modelBuilder.SeedGroups();

            // This inserts all 400 variants into the db
            modelBuilder.SeedVariants();
        }
    }
}
