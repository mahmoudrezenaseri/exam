using Ackee.DataAccess.EfCore;
using DomainModel;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ExamDbContext : AckeeDbContext
{
    public ExamDbContext(DbContextOptions options) : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserMapping).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}