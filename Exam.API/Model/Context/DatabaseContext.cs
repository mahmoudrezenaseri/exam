using Microsoft.EntityFrameworkCore;

namespace Exam.API.Model.Entity
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
     
        public DbSet<Users> Users { get; set; }

    }
}
