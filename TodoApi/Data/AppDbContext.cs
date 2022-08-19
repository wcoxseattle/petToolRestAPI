using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Duende.IdentityServer.EntityFramework.Options;
using PetToolAPI.Models;

namespace PetToolAPI.Data
{
    public class AppDbContext : ApiAuthorizationDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options, IOptions<OperationalStoreOptions> operationalStoreOptions)
        : base(options, operationalStoreOptions)
        {

        }

        public DbSet<Activity> Activities { get; set; } = null!;
        public DbSet<ActivityType> ActivityTypes { get; set; } = null!;
        public DbSet<FlagType> FlagTypes { get; set; } = null!;
        public DbSet<Food> Foods { get; set; } = null!;
        public DbSet<Person> People { get; set; } = null!;
        public DbSet<Pet> Pets { get; set; } = null!;
        public DbSet<PetType> PetTypes { get; set; } = null!;
        public DbSet<Toy> Toys { get; set; } = null!;
        public DbSet<Visit> Visits { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Code to seed data
            modelBuilder.Entity<PetType>().HasData(
                new PetType { Id = 1, Description = "Dog" });
            modelBuilder.Entity<PetType>().HasData(
                new PetType { Id = 2, Description = "Cat" });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // You don't actually ever need to call this
        }
    }
}
