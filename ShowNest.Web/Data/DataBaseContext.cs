namespace ShowNest.Web.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<AreaPreference> AreaPreferences { get; set; }
        public DbSet<Area> Areas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AreaPreference>()
                .HasKey(ap => new { ap.UserId, ap.AreaId });
        }
    }
}
