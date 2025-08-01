using Linkedlistsstory.UserDetails.AppStorage;
using Microsoft.EntityFrameworkCore;
namespace Linkedlistsstory.UserDetails.AppStorage
{
    public class APPDbContext : DbContext
    {
        public DbSet<AccountData> Accounts { get; set; }
        public DbSet<AccountSettings> AccountSettings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=localapp.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountData>()
                .HasIndex(a => a.Username)
                .IsUnique();

            modelBuilder.Entity<AccountData>()
                .HasOne(a => a.Settings)
                .WithOne(s => s.AccountData)
                .HasForeignKey<AccountSettings>(s => s.AccountId);
        }

    }

}