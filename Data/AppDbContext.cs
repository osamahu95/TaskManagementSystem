using TaskApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options): base(options)
        {
        }

        public DbSet<TaskApi.Domain.Models.Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
