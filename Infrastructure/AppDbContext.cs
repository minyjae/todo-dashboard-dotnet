using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Users> Users => Set<Users>();
    public DbSet<Lists> Lists => Set<Lists>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Lists>(e =>
        {
            e.HasKey(l => l.Id);
            e.HasIndex(l => l.UserId);
            e.Property(l => l.Title).IsRequired().HasMaxLength(200);
            e.Property(l => l.Description).HasMaxLength(200);
            e.HasOne(l => l.User)
             .WithMany(u => u.Lists)
             .HasForeignKey(l => l.UserId);
        });

        modelBuilder.Entity<Users>(e =>
        {
            e.HasKey(u => u.Id);
            e.Property(u => u.Email).IsRequired();
            e.HasIndex(u => u.Email).IsUnique();
        });
    }
}
