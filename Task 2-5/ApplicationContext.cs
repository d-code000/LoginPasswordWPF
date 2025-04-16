using Microsoft.EntityFrameworkCore;

namespace Task_2_5
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=BDreg.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();
                entity.HasIndex(e => e.Login)
                    .IsUnique();
                entity.Property(e => e.Login)
                    .IsRequired();
                entity.Property(e => e.PassHash)
                    .IsRequired();
            });
            
            base.OnModelCreating(modelBuilder);
        }
        
        public void EnsureDbCreated()
        {
            Database.EnsureCreated();
        }
    }
}