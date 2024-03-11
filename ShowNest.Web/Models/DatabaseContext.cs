namespace ShowNest.Web.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<AreaPreference> AreaPreferences { get; set; }
        public virtual DbSet<Area> Areas { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AreaPreference>()
                .HasKey(e => new { e.UserId, e.AreaId });
        }
    }
}
