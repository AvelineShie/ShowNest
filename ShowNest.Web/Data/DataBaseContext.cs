namespace ShowNest.Web.Data
{
    public class DataBaseContext : DbContext
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

            ///預建資料
            modelBuilder.Entity<Area>().HasData(
                new Area { AreaId = 1, AreaName = "北北基宜地區" },
                new Area { AreaId = 2, AreaName = "桃竹苗地區" },
                new Area { AreaId = 3, AreaName = "雲嘉南地區" },
                new Area { AreaId = 4, AreaName = "高屏地區" },
                new Area { AreaId = 5, AreaName = "中彰投地區" },
                new Area { AreaId = 6, AreaName = "花東地區" },
                new Area { AreaId = 7, AreaName = "澎金馬地區" },
                new Area { AreaId = 8, AreaName = "香港" },
                new Area { AreaId = 9, AreaName = "澳門" },
                new Area { AreaId = 10, AreaName = "其他地區" }
                );
        }
    }
}
