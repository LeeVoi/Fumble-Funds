using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Match> Matches { get; set; } = null!;
    public DbSet<Bet> Bets { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Stop EF from creating Matches.Id as IDENTITY; we'll supply our own IDs
        modelBuilder.Entity<Match>()
            .Property(m => m.Id)
            .ValueGeneratedNever();
    }
}