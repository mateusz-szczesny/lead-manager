
using Microsoft.EntityFrameworkCore;

namespace LeadManager.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Lead> Leads { get; set; }
        public DbSet<Activity> Activities { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.SetCommandTimeout(180);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lead>()
                .Property(l => l.CreatedDate)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Lead>()
                .Property(l => l.LastModifiedDate)
                .ValueGeneratedOnAddOrUpdate();

            modelBuilder.Entity<Lead>()
                .Property(l => l.Active)
                .HasDefaultValue(true);

            modelBuilder.HasPostgresEnum<ActivityType>();

            modelBuilder.Entity<Activity>()
                .Property(a => a.CreatedDate)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Activity>()
                .Property(a => a.LastModifiedDate)
                .ValueGeneratedOnAddOrUpdate();

        }

    }
}