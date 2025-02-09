using Microsoft.EntityFrameworkCore;

public class ServiceDbContext : DbContext
{
    public DbSet<Subscription> Subscriptions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=subscriptions.db");
    }
}