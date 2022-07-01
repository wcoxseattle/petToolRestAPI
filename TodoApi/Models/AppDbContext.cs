using Microsoft.EntityFrameworkCore;

namespace PetToolAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        public DbSet<Activity> Activities { get; set; } = null!;
        public DbSet<ActivityType> ActivityTypes { get; set; } = null!;
        public DbSet<FlagType> FlagTypes { get; set; } = null!;
        public DbSet<Food> Food { get; set; } = null!;
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
    }
}
