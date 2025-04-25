    using Microsoft.EntityFrameworkCore;
    
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User>   Users   { get; set; } = null!;
        public DbSet<Match>  Matches { get; set; } = null!;
        public DbSet<Bet>    Bets    { get; set; } = null!;
    }