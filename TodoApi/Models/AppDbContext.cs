using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace PetToolAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<TodoItem> TodoItems { get; set; } = null!;



    }
}
