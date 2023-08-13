using dotnet_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_backend.Data
{
    public class IssueDbContext : DbContext
    {
        public IssueDbContext(DbContextOptions<IssueDbContext> options):base(options)
        {

        }

        public DbSet<Issue> Issues { get; set; }
        public DbSet<User> Users { get; set; }
    }
}