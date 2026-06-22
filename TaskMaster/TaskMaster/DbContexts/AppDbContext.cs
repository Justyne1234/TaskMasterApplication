using Microsoft.EntityFrameworkCore;
using TaskMaster.Models;

namespace TaskMaster.DbContexts;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options){}

    public DbSet<TaskItem> Tasks { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskItem>()
            .HasOne(t => t.Owner)
            .WithMany(u => u.Tasks)
            .HasForeignKey(t => t.OwnerId);

        base.OnModelCreating(modelBuilder);
    }
}