using Microsoft.EntityFrameworkCore;
using BookMinAPIs.Models.Entity;
namespace BookMinAPIs.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>option) : base(option) {}
        public DbSet<Book>? Books {get;set;}
        public DbSet<Author>? Authors {get;set;}
        public DbSet<Review>? Reviews {get;set;}
    }
}
