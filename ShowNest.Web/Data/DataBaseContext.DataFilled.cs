namespace ShowNest.Web.Data
{
    public partial class DataBaseContext
    {
        private void DataPrefilling(ModelBuilder modelBuilder)
        {
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
