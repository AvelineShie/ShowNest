
namespace ShowNest.Web.Data
{
    public partial class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<AreaPreference> AreaPreferences { get; set; }
        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<PasswordHistory> PasswordHistories { get; set; }
        public virtual DbSet<PrefillsInfo> PrefillsInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ///設定主鍵及關聯
            modelBuilder.Entity<Area>()
                .HasKey(e => new { e.AreaId });
            modelBuilder.Entity<AreaPreference>()
                .HasKey(e => new { e.UserId, e.AreaId });
            modelBuilder.Entity<PasswordHistory>()
                .HasKey(e => new { e.UserId });
            modelBuilder.Entity<PrefillsInfo>()
                .HasKey(e => new { e.UserId });
            modelBuilder.Entity<User>()
                .HasKey(e => new { e.UserId });

            DataPrefilling(modelBuilder);
        }


    }
}
