using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public partial class DatabaseContext : DbContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>().HasData(
             new Area { Id = 1, Name = "北北基宜地區" },
             new Area { Id = 2, Name = "桃竹苗地區" },
             new Area { Id = 3, Name = "雲嘉南地區" },
             new Area { Id = 4, Name = "高屏地區" },
             new Area { Id = 5, Name = "中彰投地區" },
             new Area { Id = 6, Name = "花東地區" },
             new Area { Id = 7, Name = "澎金馬地區" },
             new Area { Id = 8, Name = "香港" },
             new Area { Id = 9, Name = "澳門" },
             new Area { Id = 10, Name = "其他地區" }
             );
        }
    }
}
