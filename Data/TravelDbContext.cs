using Microsoft.EntityFrameworkCore;
using ProjectV.Domain;

namespace ProjectV.Data
{
    public class TravelDbContext : DbContext
    {
        public TravelDbContext(DbContextOptions<TravelDbContext> options)
            : base(options)
        {

        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Continent> Continent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>()
                .HasOne(c => c.Capital)
                .WithOne()
                .HasForeignKey<Country>(c => c.CapitalId);

            modelBuilder.Entity<Country>()
                .HasOne(c => c.Continent)
                .WithMany()
                .HasForeignKey(c => c.ContinentId);

            modelBuilder.Entity<City>()
                .HasOne(c => c.Country)
                .WithMany()
                .HasForeignKey(c => c.CountryId);
        }

    }
}
