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
    }
}