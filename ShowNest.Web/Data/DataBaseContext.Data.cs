namespace ShowNest.Web.Data
{
    public partial class DataBaseContext
    {
        /// <summary>
        /// Prefill the data
        /// Only for the first time
        /// </summary>
        /// <param name="modelBuilder"></param>
        private void DataFilling(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>().HasData(
             new Area { Id = 1, AreaName = "北北基宜地區" },
             new Area { Id = 2, AreaName = "桃竹苗地區" },
             new Area { Id = 3, AreaName = "雲嘉南地區" },
             new Area { Id = 4, AreaName = "高屏地區" },
             new Area { Id = 5, AreaName = "中彰投地區" },
             new Area { Id = 6, AreaName = "花東地區" },
             new Area { Id = 7, AreaName = "澎金馬地區" },
             new Area { Id = 8, AreaName = "香港" },
             new Area { Id = 9, AreaName = "澳門" },
             new Area { Id = 10, AreaName = "其他地區" }
             );
        }
    }
}
