using MarketDataService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarketDataService.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Asset> Assets => Set<Asset>();
        public DbSet<Price> Prices => Set<Price>();

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asset>()
                .HasIndex(a => a.Symbol)
                .IsUnique();

            modelBuilder.Entity<Price>()
                .Property(p => p.Value)
                .HasPrecision(18, 6);
        }
    }
}