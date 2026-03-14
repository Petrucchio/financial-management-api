using Microsoft.EntityFrameworkCore;
using FinancialManagementAPI.Models;

namespace FinancialManagementAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Description).IsRequired().HasMaxLength(200);
                entity.Property(t => t.Category).IsRequired().HasMaxLength(100);
                entity.Property(t => t.Amount).HasColumnType("decimal(18,2)");
            });
        }
    }
}