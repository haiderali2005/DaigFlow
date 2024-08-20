using Microsoft.EntityFrameworkCore;

namespace DaigFlow.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions option):base(option)
        {
            
        }
        public DbSet<Daig> Daigs { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<User> table_Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Transactions>()
              .HasOne(t => t.Daig)
              .WithMany(d => d.Transactions)
              .HasForeignKey(f => f.DaigId)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
