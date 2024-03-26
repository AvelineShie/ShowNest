using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Channels;


namespace Infrastructure.Data
{
    public partial class DatabaseContext : DbContext
    {
        public object EventDetails { get; set; }

        static void FakeDataFilling(ModelBuilder modelBuilder)
        {

            //--------------------SEAT-----------------------------------
            modelBuilder.Entity<Seat>().HasData(
               new Seat
               {
                   Id = 1,
                   SeatAreaId = 1,
                   Number = "1排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 2,
                   SeatAreaId = 1,
                   Number = "1排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 3,
                   SeatAreaId = 1,
                   Number = "1排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 4,
                   SeatAreaId = 1,
                   Number = "1排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 5,
                   SeatAreaId = 1,
                   Number = "1排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 6,
                   SeatAreaId = 1,
                   Number = "1排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 7,
                   SeatAreaId = 1,
                   Number = "1排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 8,
                   SeatAreaId = 1,
                   Number = "1排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 9,
                   SeatAreaId = 1,
                   Number = "1排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 10,
                   SeatAreaId = 1,
                   Number = "1排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 11,
                   SeatAreaId = 1,
                   Number = "1排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 12,
                   SeatAreaId = 1,
                   Number = "1排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 13,
                   SeatAreaId = 1,
                   Number = "1排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 14,
                   SeatAreaId = 1,
                   Number = "1排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 15,
                   SeatAreaId = 1,
                   Number = "1排15號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 16,
                   SeatAreaId = 1,
                   Number = "1排16號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 17,
                   SeatAreaId = 1,
                   Number = "1排17號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 18,
                   SeatAreaId = 1,
                   Number = "2排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 19,
                   SeatAreaId = 1,
                   Number = "2排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 20,
                   SeatAreaId = 1,
                   Number = "2排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 21,
                   SeatAreaId = 1,
                   Number = "2排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 22,
                   SeatAreaId = 1,
                   Number = "2排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 23,
                   SeatAreaId = 1,
                   Number = "2排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 24,
                   SeatAreaId = 1,
                   Number = "2排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 25,
                   SeatAreaId = 1,
                   Number = "2排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 26,
                   SeatAreaId = 1,
                   Number = "2排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 27,
                   SeatAreaId = 1,
                   Number = "2排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 28,
                   SeatAreaId = 1,
                   Number = "2排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 29,
                   SeatAreaId = 1,
                   Number = "2排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 30,
                   SeatAreaId = 1,
                   Number = "2排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 31,
                   SeatAreaId = 1,
                   Number = "2排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 32,
                   SeatAreaId = 1,
                   Number = "2排15號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 33,
                   SeatAreaId = 1,
                   Number = "2排16號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 34,
                   SeatAreaId = 1,
                   Number = "2排17號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 35,
                   SeatAreaId = 1,
                   Number = "3排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 36,
                   SeatAreaId = 1,
                   Number = "3排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 37,
                   SeatAreaId = 1,
                   Number = "3排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 38,
                   SeatAreaId = 1,
                   Number = "3排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 39,
                   SeatAreaId = 1,
                   Number = "3排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 40,
                   SeatAreaId = 1,
                   Number = "3排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 41,
                   SeatAreaId = 1,
                   Number = "3排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 42,
                   SeatAreaId = 1,
                   Number = "3排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 43,
                   SeatAreaId = 1,
                   Number = "3排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 44,
                   SeatAreaId = 1,
                   Number = "3排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 45,
                   SeatAreaId = 1,
                   Number = "3排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 46,
                   SeatAreaId = 1,
                   Number = "3排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 47,
                   SeatAreaId = 1,
                   Number = "3排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 48,
                   SeatAreaId = 1,
                   Number = "3排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 49,
                   SeatAreaId = 1,
                   Number = "3排16號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 50,
                   SeatAreaId = 1,
                   Number = "3排17號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 51,
                   SeatAreaId = 1,
                   Number = "4排1號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 52,
                   SeatAreaId = 1,
                   Number = "4排2號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 53,
                   SeatAreaId = 1,
                   Number = "4排3號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 54,
                   SeatAreaId = 1,
                   Number = "4排4號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 55,
                   SeatAreaId = 1,
                   Number = "4排5號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 56,
                   SeatAreaId = 1,
                   Number = "4排6號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 57,
                   SeatAreaId = 1,
                   Number = "4排7號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 58,
                   SeatAreaId = 1,
                   Number = "4排8號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 59,
                   SeatAreaId = 1,
                   Number = "4排9號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 60,
                   SeatAreaId = 1,
                   Number = "4排10號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 61,
                   SeatAreaId = 1,
                   Number = "4排11號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 62,
                   SeatAreaId = 1,
                   Number = "4排12號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 63,
                   SeatAreaId = 1,
                   Number = "4排13號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 1,
                   SeatAreaId = 2,
                   Number = "1排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 2,
                   SeatAreaId = 2,
                   Number = "1排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 3,
                   SeatAreaId = 2,
                   Number = "1排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 4,
                   SeatAreaId = 2,
                   Number = "1排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 5,
                   SeatAreaId = 2,
                   Number = "1排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 6,
                   SeatAreaId = 2,
                   Number = "1排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 7,
                   SeatAreaId = 2,
                   Number = "1排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 8,
                   SeatAreaId = 2,
                   Number = "1排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 9,
                   SeatAreaId = 2,
                   Number = "1排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 10,
                   SeatAreaId = 2,
                   Number = "1排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 11,
                   SeatAreaId = 2,
                   Number = "1排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 12,
                   SeatAreaId = 2,
                   Number = "1排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 13,
                   SeatAreaId = 2,
                   Number = "1排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 14,
                   SeatAreaId = 2,
                   Number = "1排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 15,
                   SeatAreaId = 2,
                   Number = "1排15號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 16,
                   SeatAreaId = 2,
                   Number = "1排16號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 17,
                   SeatAreaId = 2,
                   Number = "1排17號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 18,
                   SeatAreaId = 2,
                   Number = "2排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 19,
                   SeatAreaId = 2,
                   Number = "2排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 20,
                   SeatAreaId = 2,
                   Number = "2排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 21,
                   SeatAreaId = 2,
                   Number = "2排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 22,
                   SeatAreaId = 2,
                   Number = "2排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 23,
                   SeatAreaId = 2,
                   Number = "2排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 24,
                   SeatAreaId = 2,
                   Number = "2排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 25,
                   SeatAreaId = 2,
                   Number = "2排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 26,
                   SeatAreaId = 2,
                   Number = "2排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 27,
                   SeatAreaId = 2,
                   Number = "2排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 28,
                   SeatAreaId = 2,
                   Number = "2排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 29,
                   SeatAreaId = 2,
                   Number = "2排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 30,
                   SeatAreaId = 2,
                   Number = "2排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 31,
                   SeatAreaId = 2,
                   Number = "2排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 32,
                   SeatAreaId = 2,
                   Number = "2排15號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 33,
                   SeatAreaId = 2,
                   Number = "2排16號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 34,
                   SeatAreaId = 2,
                   Number = "2排17號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 35,
                   SeatAreaId = 2,
                   Number = "3排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 36,
                   SeatAreaId = 2,
                   Number = "3排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 37,
                   SeatAreaId = 2,
                   Number = "3排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 38,
                   SeatAreaId = 2,
                   Number = "3排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 39,
                   SeatAreaId = 2,
                   Number = "3排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 40,
                   SeatAreaId = 2,
                   Number = "3排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 41,
                   SeatAreaId = 2,
                   Number = "3排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 42,
                   SeatAreaId = 2,
                   Number = "3排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 43,
                   SeatAreaId = 2,
                   Number = "3排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 44,
                   SeatAreaId = 2,
                   Number = "3排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 45,
                   SeatAreaId = 2,
                   Number = "3排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 46,
                   SeatAreaId = 2,
                   Number = "3排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 47,
                   SeatAreaId = 2,
                   Number = "3排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 48,
                   SeatAreaId = 2,
                   Number = "3排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 49,
                   SeatAreaId = 2,
                   Number = "3排16號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 50,
                   SeatAreaId = 2,
                   Number = "3排17號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 51,
                   SeatAreaId = 2,
                   Number = "4排1號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 52,
                   SeatAreaId = 2,
                   Number = "4排2號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 53,
                   SeatAreaId = 2,
                   Number = "4排3號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 54,
                   SeatAreaId = 2,
                   Number = "4排4號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 55,
                   SeatAreaId = 2,
                   Number = "4排5號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 56,
                   SeatAreaId = 2,
                   Number = "4排6號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 57,
                   SeatAreaId = 2,
                   Number = "4排7號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 58,
                   SeatAreaId = 2,
                   Number = "4排8號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 59,
                   SeatAreaId = 2,
                   Number = "4排9號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 60,
                   SeatAreaId = 2,
                   Number = "4排10號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 61,
                   SeatAreaId = 2,
                   Number = "4排11號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 62,
                   SeatAreaId = 2,
                   Number = "4排12號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 63,
                   SeatAreaId = 2,
                   Number = "4排13號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 1,
                   SeatAreaId = 3,
                   Number = "1排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 2,
                   SeatAreaId = 3,
                   Number = "1排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 3,
                   SeatAreaId = 3,
                   Number = "1排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 4,
                   SeatAreaId = 3,
                   Number = "1排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 5,
                   SeatAreaId = 3,
                   Number = "1排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 6,
                   SeatAreaId = 3,
                   Number = "1排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 7,
                   SeatAreaId = 3,
                   Number = "1排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 8,
                   SeatAreaId = 3,
                   Number = "1排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 9,
                   SeatAreaId = 3,
                   Number = "1排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 10,
                   SeatAreaId = 3,
                   Number = "1排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 11,
                   SeatAreaId = 3,
                   Number = "1排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 12,
                   SeatAreaId = 3,
                   Number = "1排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 13,
                   SeatAreaId = 3,
                   Number = "1排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 14,
                   SeatAreaId = 3,
                   Number = "1排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 15,
                   SeatAreaId = 3,
                   Number = "1排15號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 16,
                   SeatAreaId = 3,
                   Number = "1排16號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 17,
                   SeatAreaId = 3,
                   Number = "1排17號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 18,
                   SeatAreaId = 3,
                   Number = "2排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 19,
                   SeatAreaId = 3,
                   Number = "2排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 20,
                   SeatAreaId = 3,
                   Number = "2排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 21,
                   SeatAreaId = 3,
                   Number = "2排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 22,
                   SeatAreaId = 3,
                   Number = "2排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 23,
                   SeatAreaId = 3,
                   Number = "2排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 24,
                   SeatAreaId = 3,
                   Number = "2排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 25,
                   SeatAreaId = 3,
                   Number = "2排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 26,
                   SeatAreaId = 3,
                   Number = "2排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 27,
                   SeatAreaId = 3,
                   Number = "2排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 28,
                   SeatAreaId = 3,
                   Number = "2排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 29,
                   SeatAreaId = 3,
                   Number = "2排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 30,
                   SeatAreaId = 3,
                   Number = "2排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 31,
                   SeatAreaId = 3,
                   Number = "2排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 32,
                   SeatAreaId = 3,
                   Number = "2排15號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 33,
                   SeatAreaId = 3,
                   Number = "2排16號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 34,
                   SeatAreaId = 3,
                   Number = "2排17號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 35,
                   SeatAreaId = 3,
                   Number = "3排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 36,
                   SeatAreaId = 3,
                   Number = "3排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 37,
                   SeatAreaId = 3,
                   Number = "3排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 38,
                   SeatAreaId = 3,
                   Number = "3排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 39,
                   SeatAreaId = 3,
                   Number = "3排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 40,
                   SeatAreaId = 3,
                   Number = "3排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 41,
                   SeatAreaId = 3,
                   Number = "3排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 42,
                   SeatAreaId = 3,
                   Number = "3排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 43,
                   SeatAreaId = 3,
                   Number = "3排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 44,
                   SeatAreaId = 3,
                   Number = "3排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 45,
                   SeatAreaId = 3,
                   Number = "3排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 46,
                   SeatAreaId = 3,
                   Number = "3排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 47,
                   SeatAreaId = 3,
                   Number = "3排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 48,
                   SeatAreaId = 3,
                   Number = "3排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 49,
                   SeatAreaId = 3,
                   Number = "3排16號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 50,
                   SeatAreaId = 3,
                   Number = "3排17號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 51,
                   SeatAreaId = 3,
                   Number = "4排1號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 52,
                   SeatAreaId = 3,
                   Number = "4排2號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 53,
                   SeatAreaId = 3,
                   Number = "4排3號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 54,
                   SeatAreaId = 3,
                   Number = "4排4號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 55,
                   SeatAreaId = 3,
                   Number = "4排5號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 56,
                   SeatAreaId = 3,
                   Number = "4排6號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 57,
                   SeatAreaId = 3,
                   Number = "4排7號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 58,
                   SeatAreaId = 3,
                   Number = "4排8號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 59,
                   SeatAreaId = 3,
                   Number = "4排9號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 60,
                   SeatAreaId = 3,
                   Number = "4排10號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 61,
                   SeatAreaId = 3,
                   Number = "4排11號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 62,
                   SeatAreaId = 3,
                   Number = "4排12號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 63,
                   SeatAreaId = 3,
                   Number = "4排13號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 1,
                   SeatAreaId = 4,
                   Number = "1排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 2,
                   SeatAreaId = 4,
                   Number = "1排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 3,
                   SeatAreaId = 4,
                   Number = "1排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 4,
                   SeatAreaId = 4,
                   Number = "1排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 5,
                   SeatAreaId = 4,
                   Number = "1排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 6,
                   SeatAreaId = 4,
                   Number = "1排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 7,
                   SeatAreaId = 4,
                   Number = "1排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 8,
                   SeatAreaId = 4,
                   Number = "1排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 9,
                   SeatAreaId = 4,
                   Number = "1排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 10,
                   SeatAreaId = 4,
                   Number = "1排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 11,
                   SeatAreaId = 4,
                   Number = "1排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 12,
                   SeatAreaId = 4,
                   Number = "1排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 13,
                   SeatAreaId = 4,
                   Number = "1排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 14,
                   SeatAreaId = 4,
                   Number = "1排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 15,
                   SeatAreaId = 4,
                   Number = "1排15號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 16,
                   SeatAreaId = 4,
                   Number = "1排16號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 17,
                   SeatAreaId = 4,
                   Number = "1排17號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 18,
                   SeatAreaId = 4,
                   Number = "2排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 19,
                   SeatAreaId = 4,
                   Number = "2排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 20,
                   SeatAreaId = 4,
                   Number = "2排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 21,
                   SeatAreaId = 4,
                   Number = "2排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 22,
                   SeatAreaId = 4,
                   Number = "2排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 23,
                   SeatAreaId = 4,
                   Number = "2排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 24,
                   SeatAreaId = 4,
                   Number = "2排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 25,
                   SeatAreaId = 4,
                   Number = "2排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 26,
                   SeatAreaId = 4,
                   Number = "2排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 27,
                   SeatAreaId = 4,
                   Number = "2排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 28,
                   SeatAreaId = 4,
                   Number = "2排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 29,
                   SeatAreaId = 4,
                   Number = "2排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 30,
                   SeatAreaId = 4,
                   Number = "2排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 31,
                   SeatAreaId = 4,
                   Number = "2排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 32,
                   SeatAreaId = 4,
                   Number = "2排15號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 33,
                   SeatAreaId = 4,
                   Number = "2排16號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 34,
                   SeatAreaId = 4,
                   Number = "2排17號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 35,
                   SeatAreaId = 4,
                   Number = "3排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 36,
                   SeatAreaId = 4,
                   Number = "3排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 37,
                   SeatAreaId = 4,
                   Number = "3排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 38,
                   SeatAreaId = 4,
                   Number = "3排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 39,
                   SeatAreaId = 4,
                   Number = "3排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 40,
                   SeatAreaId = 4,
                   Number = "3排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 41,
                   SeatAreaId = 4,
                   Number = "3排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 42,
                   SeatAreaId = 4,
                   Number = "3排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 43,
                   SeatAreaId = 4,
                   Number = "3排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 44,
                   SeatAreaId = 4,
                   Number = "3排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 45,
                   SeatAreaId = 4,
                   Number = "3排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 46,
                   SeatAreaId = 4,
                   Number = "3排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 47,
                   SeatAreaId = 4,
                   Number = "3排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 48,
                   SeatAreaId = 4,
                   Number = "3排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 49,
                   SeatAreaId = 4,
                   Number = "3排16號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 50,
                   SeatAreaId = 4,
                   Number = "3排17號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 51,
                   SeatAreaId = 4,
                   Number = "4排1號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 52,
                   SeatAreaId = 4,
                   Number = "4排2號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 53,
                   SeatAreaId = 4,
                   Number = "4排3號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 54,
                   SeatAreaId = 4,
                   Number = "4排4號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 55,
                   SeatAreaId = 4,
                   Number = "4排5號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 56,
                   SeatAreaId = 4,
                   Number = "4排6號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 57,
                   SeatAreaId = 4,
                   Number = "4排7號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 58,
                   SeatAreaId = 4,
                   Number = "4排8號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 59,
                   SeatAreaId = 4,
                   Number = "4排9號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 60,
                   SeatAreaId = 4,
                   Number = "4排10號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 61,
                   SeatAreaId = 4,
                   Number = "4排11號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 62,
                   SeatAreaId = 4,
                   Number = "4排12號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 63,
                   SeatAreaId = 4,
                   Number = "4排13號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               }, 
               new Seat
               {
                   Id = 1,
                   SeatAreaId = 5,
                   Number = "1排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 2,
                   SeatAreaId = 5,
                   Number = "1排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 3,
                   SeatAreaId = 5,
                   Number = "1排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 4,
                   SeatAreaId = 5,
                   Number = "1排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 5,
                   SeatAreaId = 5,
                   Number = "1排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 6,
                   SeatAreaId = 5,
                   Number = "1排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 7,
                   SeatAreaId = 5,
                   Number = "1排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 8,
                   SeatAreaId = 5,
                   Number = "1排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 9,
                   SeatAreaId = 5,
                   Number = "1排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 10,
                   SeatAreaId = 5,
                   Number = "1排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 11,
                   SeatAreaId = 5,
                   Number = "1排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 12,
                   SeatAreaId = 5,
                   Number = "1排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 13,
                   SeatAreaId = 5,
                   Number = "1排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 14,
                   SeatAreaId = 5,
                   Number = "1排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 15,
                   SeatAreaId = 5,
                   Number = "1排15號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 16,
                   SeatAreaId = 5,
                   Number = "1排16號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 17,
                   SeatAreaId = 5,
                   Number = "1排17號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 18,
                   SeatAreaId = 5,
                   Number = "2排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 19,
                   SeatAreaId = 5,
                   Number = "2排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 20,
                   SeatAreaId = 5,
                   Number = "2排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 21,
                   SeatAreaId = 5,
                   Number = "2排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 22,
                   SeatAreaId = 5,
                   Number = "2排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 23,
                   SeatAreaId = 5,
                   Number = "2排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 24,
                   SeatAreaId = 5,
                   Number = "2排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 25,
                   SeatAreaId = 5,
                   Number = "2排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 26,
                   SeatAreaId = 5,
                   Number = "2排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 27,
                   SeatAreaId = 5,
                   Number = "2排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 28,
                   SeatAreaId = 5,
                   Number = "2排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 29,
                   SeatAreaId = 5,
                   Number = "2排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 30,
                   SeatAreaId = 5,
                   Number = "2排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 31,
                   SeatAreaId = 5,
                   Number = "2排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 32,
                   SeatAreaId = 5,
                   Number = "2排15號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 33,
                   SeatAreaId = 5,
                   Number = "2排16號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 34,
                   SeatAreaId = 5,
                   Number = "2排17號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 35,
                   SeatAreaId = 5,
                   Number = "3排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 36,
                   SeatAreaId = 5,
                   Number = "3排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 37,
                   SeatAreaId = 5,
                   Number = "3排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 38,
                   SeatAreaId = 5,
                   Number = "3排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 39,
                   SeatAreaId = 5,
                   Number = "3排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 40,
                   SeatAreaId = 5,
                   Number = "3排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 41,
                   SeatAreaId = 5,
                   Number = "3排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 42,
                   SeatAreaId = 5,
                   Number = "3排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 43,
                   SeatAreaId = 5,
                   Number = "3排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 44,
                   SeatAreaId = 5,
                   Number = "3排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 45,
                   SeatAreaId = 5,
                   Number = "3排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 46,
                   SeatAreaId = 5,
                   Number = "3排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 47,
                   SeatAreaId = 5,
                   Number = "3排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 48,
                   SeatAreaId = 5,
                   Number = "3排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 49,
                   SeatAreaId = 5,
                   Number = "3排16號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 50,
                   SeatAreaId = 5,
                   Number = "3排17號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 51,
                   SeatAreaId = 5,
                   Number = "4排1號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 52,
                   SeatAreaId = 5,
                   Number = "4排2號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 53,
                   SeatAreaId = 5,
                   Number = "4排3號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 54,
                   SeatAreaId = 5,
                   Number = "4排4號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 55,
                   SeatAreaId = 5,
                   Number = "4排5號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 56,
                   SeatAreaId = 5,
                   Number = "4排6號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 57,
                   SeatAreaId = 5,
                   Number = "4排7號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 58,
                   SeatAreaId = 5,
                   Number = "4排8號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 59,
                   SeatAreaId = 5,
                   Number = "4排9號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 60,
                   SeatAreaId = 5,
                   Number = "4排10號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 61,
                   SeatAreaId = 5,
                   Number = "4排11號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 62,
                   SeatAreaId = 5,
                   Number = "4排12號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 63,
                   SeatAreaId = 5,
                   Number = "4排13號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               }, 
               new Seat
               {
                   Id = 1,
                   SeatAreaId = 6,
                   Number = "1排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 2,
                   SeatAreaId = 6,
                   Number = "1排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 3,
                   SeatAreaId = 6,
                   Number = "1排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 4,
                   SeatAreaId = 6,
                   Number = "1排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 5,
                   SeatAreaId = 6,
                   Number = "1排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 6,
                   SeatAreaId = 6,
                   Number = "1排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 7,
                   SeatAreaId = 6,
                   Number = "1排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 8,
                   SeatAreaId = 6,
                   Number = "1排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 9,
                   SeatAreaId = 6,
                   Number = "1排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 10,
                   SeatAreaId = 6,
                   Number = "1排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 11,
                   SeatAreaId = 6,
                   Number = "1排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 12,
                   SeatAreaId = 6,
                   Number = "1排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 13,
                   SeatAreaId = 6,
                   Number = "1排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 14,
                   SeatAreaId = 6,
                   Number = "1排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 15,
                   SeatAreaId = 6,
                   Number = "1排15號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 16,
                   SeatAreaId = 6,
                   Number = "1排16號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 17,
                   SeatAreaId = 6,
                   Number = "1排17號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 18,
                   SeatAreaId = 6,
                   Number = "2排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 19,
                   SeatAreaId = 6,
                   Number = "2排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 20,
                   SeatAreaId = 6,
                   Number = "2排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 21,
                   SeatAreaId = 6,
                   Number = "2排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 22,
                   SeatAreaId = 6,
                   Number = "2排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 23,
                   SeatAreaId = 6,
                   Number = "2排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 24,
                   SeatAreaId = 6,
                   Number = "2排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 25,
                   SeatAreaId = 6,
                   Number = "2排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 26,
                   SeatAreaId = 6,
                   Number = "2排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 27,
                   SeatAreaId = 6,
                   Number = "2排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 28,
                   SeatAreaId = 6,
                   Number = "2排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 29,
                   SeatAreaId = 6,
                   Number = "2排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 30,
                   SeatAreaId = 6,
                   Number = "2排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 31,
                   SeatAreaId = 6,
                   Number = "2排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 32,
                   SeatAreaId = 6,
                   Number = "2排15號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 33,
                   SeatAreaId = 6,
                   Number = "2排16號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 34,
                   SeatAreaId = 6,
                   Number = "2排17號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 35,
                   SeatAreaId = 6,
                   Number = "3排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 36,
                   SeatAreaId = 6,
                   Number = "3排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 37,
                   SeatAreaId = 6,
                   Number = "3排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 38,
                   SeatAreaId = 6,
                   Number = "3排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 39,
                   SeatAreaId = 6,
                   Number = "3排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 40,
                   SeatAreaId = 6,
                   Number = "3排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 41,
                   SeatAreaId = 6,
                   Number = "3排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 42,
                   SeatAreaId = 6,
                   Number = "3排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 43,
                   SeatAreaId = 6,
                   Number = "3排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 44,
                   SeatAreaId = 6,
                   Number = "3排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 45,
                   SeatAreaId = 6,
                   Number = "3排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 46,
                   SeatAreaId = 6,
                   Number = "3排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 47,
                   SeatAreaId = 6,
                   Number = "3排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 48,
                   SeatAreaId = 6,
                   Number = "3排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 49,
                   SeatAreaId = 6,
                   Number = "3排16號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 50,
                   SeatAreaId = 6,
                   Number = "3排17號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 51,
                   SeatAreaId = 6,
                   Number = "4排1號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 52,
                   SeatAreaId = 6,
                   Number = "4排2號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 53,
                   SeatAreaId = 6,
                   Number = "4排3號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 54,
                   SeatAreaId = 6,
                   Number = "4排4號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 55,
                   SeatAreaId = 6,
                   Number = "4排5號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 56,
                   SeatAreaId = 6,
                   Number = "4排6號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 57,
                   SeatAreaId = 6,
                   Number = "4排7號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 58,
                   SeatAreaId = 6,
                   Number = "4排8號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 59,
                   SeatAreaId = 6,
                   Number = "4排9號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 60,
                   SeatAreaId = 6,
                   Number = "4排10號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 61,
                   SeatAreaId = 6,
                   Number = "4排11號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 62,
                   SeatAreaId = 6,
                   Number = "4排12號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 63,
                   SeatAreaId = 6,
                   Number = "4排13號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               }, 
               new Seat
               {
                   Id = 1,
                   SeatAreaId = 7,
                   Number = "1排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 2,
                   SeatAreaId = 7,
                   Number = "1排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 3,
                   SeatAreaId = 7,
                   Number = "1排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 4,
                   SeatAreaId = 7,
                   Number = "1排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 5,
                   SeatAreaId = 7,
                   Number = "1排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 6,
                   SeatAreaId = 7,
                   Number = "1排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 7,
                   SeatAreaId = 7,
                   Number = "1排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 8,
                   SeatAreaId = 7,
                   Number = "1排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 9,
                   SeatAreaId = 7,
                   Number = "1排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 10,
                   SeatAreaId = 7,
                   Number = "1排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 11,
                   SeatAreaId = 7,
                   Number = "1排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 12,
                   SeatAreaId = 7,
                   Number = "1排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 13,
                   SeatAreaId = 7,
                   Number = "1排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 14,
                   SeatAreaId = 7,
                   Number = "1排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 15,
                   SeatAreaId = 7,
                   Number = "1排15號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 16,
                   SeatAreaId = 7,
                   Number = "1排16號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 17,
                   SeatAreaId = 7,
                   Number = "1排17號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 18,
                   SeatAreaId = 7,
                   Number = "2排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 19,
                   SeatAreaId = 7,
                   Number = "2排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 20,
                   SeatAreaId = 7,
                   Number = "2排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 21,
                   SeatAreaId = 7,
                   Number = "2排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 22,
                   SeatAreaId = 7,
                   Number = "2排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 23,
                   SeatAreaId = 7,
                   Number = "2排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 24,
                   SeatAreaId = 7,
                   Number = "2排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 25,
                   SeatAreaId = 7,
                   Number = "2排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 26,
                   SeatAreaId = 7,
                   Number = "2排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 27,
                   SeatAreaId = 7,
                   Number = "2排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 28,
                   SeatAreaId = 7,
                   Number = "2排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 29,
                   SeatAreaId = 7,
                   Number = "2排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 30,
                   SeatAreaId = 7,
                   Number = "2排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 31,
                   SeatAreaId = 7,
                   Number = "2排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 32,
                   SeatAreaId = 7,
                   Number = "2排15號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 33,
                   SeatAreaId = 7,
                   Number = "2排16號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 34,
                   SeatAreaId = 7,
                   Number = "2排17號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 35,
                   SeatAreaId = 7,
                   Number = "3排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 36,
                   SeatAreaId = 7,
                   Number = "3排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 37,
                   SeatAreaId = 7,
                   Number = "3排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 38,
                   SeatAreaId = 7,
                   Number = "3排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 39,
                   SeatAreaId = 7,
                   Number = "3排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 40,
                   SeatAreaId = 7,
                   Number = "3排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 41,
                   SeatAreaId = 7,
                   Number = "3排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 42,
                   SeatAreaId = 7,
                   Number = "3排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 43,
                   SeatAreaId = 7,
                   Number = "3排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 44,
                   SeatAreaId = 7,
                   Number = "3排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 45,
                   SeatAreaId = 7,
                   Number = "3排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 46,
                   SeatAreaId = 7,
                   Number = "3排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 47,
                   SeatAreaId = 7,
                   Number = "3排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 48,
                   SeatAreaId = 7,
                   Number = "3排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 49,
                   SeatAreaId = 7,
                   Number = "3排16號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 50,
                   SeatAreaId = 7,
                   Number = "3排17號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 51,
                   SeatAreaId = 7,
                   Number = "4排1號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 52,
                   SeatAreaId = 7,
                   Number = "4排2號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 53,
                   SeatAreaId = 7,
                   Number = "4排3號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 54,
                   SeatAreaId = 7,
                   Number = "4排4號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 55,
                   SeatAreaId = 7,
                   Number = "4排5號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 56,
                   SeatAreaId = 7,
                   Number = "4排6號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 57,
                   SeatAreaId = 7,
                   Number = "4排7號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 58,
                   SeatAreaId = 7,
                   Number = "4排8號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 59,
                   SeatAreaId = 7,
                   Number = "4排9號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 60,
                   SeatAreaId = 7,
                   Number = "4排10號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 61,
                   SeatAreaId = 7,
                   Number = "4排11號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 62,
                   SeatAreaId = 7,
                   Number = "4排12號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 63,
                   SeatAreaId = 7,
                   Number = "4排13號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               }, 
               new Seat
               {
                   Id = 1,
                   SeatAreaId = 8,
                   Number = "1排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 2,
                   SeatAreaId = 8,
                   Number = "1排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 3,
                   SeatAreaId = 8,
                   Number = "1排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 4,
                   SeatAreaId = 8,
                   Number = "1排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 5,
                   SeatAreaId = 8,
                   Number = "1排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 6,
                   SeatAreaId = 8,
                   Number = "1排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 7,
                   SeatAreaId = 8,
                   Number = "1排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 8,
                   SeatAreaId = 8,
                   Number = "1排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 9,
                   SeatAreaId = 8,
                   Number = "1排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 10,
                   SeatAreaId = 8,
                   Number = "1排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 11,
                   SeatAreaId = 8,
                   Number = "1排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 12,
                   SeatAreaId = 8,
                   Number = "1排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 13,
                   SeatAreaId = 8,
                   Number = "1排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 14,
                   SeatAreaId = 8,
                   Number = "1排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 15,
                   SeatAreaId = 8,
                   Number = "1排15號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 16,
                   SeatAreaId = 8,
                   Number = "1排16號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 17,
                   SeatAreaId = 8,
                   Number = "1排17號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 18,
                   SeatAreaId = 8,
                   Number = "2排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 19,
                   SeatAreaId = 8,
                   Number = "2排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 20,
                   SeatAreaId = 8,
                   Number = "2排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 21,
                   SeatAreaId = 8,
                   Number = "2排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 22,
                   SeatAreaId = 8,
                   Number = "2排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 23,
                   SeatAreaId = 8,
                   Number = "2排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 24,
                   SeatAreaId = 8,
                   Number = "2排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 25,
                   SeatAreaId = 8,
                   Number = "2排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 26,
                   SeatAreaId = 8,
                   Number = "2排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 27,
                   SeatAreaId = 8,
                   Number = "2排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 28,
                   SeatAreaId = 8,
                   Number = "2排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 29,
                   SeatAreaId = 8,
                   Number = "2排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 30,
                   SeatAreaId = 8,
                   Number = "2排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 31,
                   SeatAreaId = 8,
                   Number = "2排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 32,
                   SeatAreaId = 8,
                   Number = "2排15號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 33,
                   SeatAreaId = 8,
                   Number = "2排16號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 34,
                   SeatAreaId = 8,
                   Number = "2排17號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 35,
                   SeatAreaId = 8,
                   Number = "3排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 36,
                   SeatAreaId = 8,
                   Number = "3排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 37,
                   SeatAreaId = 8,
                   Number = "3排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 38,
                   SeatAreaId = 8,
                   Number = "3排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 39,
                   SeatAreaId = 8,
                   Number = "3排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 40,
                   SeatAreaId = 8,
                   Number = "3排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 41,
                   SeatAreaId = 8,
                   Number = "3排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 42,
                   SeatAreaId = 8,
                   Number = "3排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 43,
                   SeatAreaId = 8,
                   Number = "3排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 44,
                   SeatAreaId = 8,
                   Number = "3排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 45,
                   SeatAreaId = 8,
                   Number = "3排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 46,
                   SeatAreaId = 8,
                   Number = "3排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 47,
                   SeatAreaId = 8,
                   Number = "3排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 48,
                   SeatAreaId = 8,
                   Number = "3排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 49,
                   SeatAreaId = 8,
                   Number = "3排16號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 50,
                   SeatAreaId = 8,
                   Number = "3排17號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 51,
                   SeatAreaId = 8,
                   Number = "4排1號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 52,
                   SeatAreaId = 8,
                   Number = "4排2號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 53,
                   SeatAreaId = 8,
                   Number = "4排3號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 54,
                   SeatAreaId = 8,
                   Number = "4排4號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 55,
                   SeatAreaId = 8,
                   Number = "4排5號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 56,
                   SeatAreaId = 8,
                   Number = "4排6號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 57,
                   SeatAreaId = 8,
                   Number = "4排7號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 58,
                   SeatAreaId = 8,
                   Number = "4排8號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 59,
                   SeatAreaId = 8,
                   Number = "4排9號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 60,
                   SeatAreaId = 8,
                   Number = "4排10號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 61,
                   SeatAreaId = 8,
                   Number = "4排11號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 62,
                   SeatAreaId = 8,
                   Number = "4排12號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 63,
                   SeatAreaId = 8,
                   Number = "4排13號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               }, 
               new Seat
               {
                   Id = 1,
                   SeatAreaId = 9,
                   Number = "1排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 2,
                   SeatAreaId = 9,
                   Number = "1排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 3,
                   SeatAreaId = 9,
                   Number = "1排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 4,
                   SeatAreaId = 9,
                   Number = "1排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 5,
                   SeatAreaId = 9,
                   Number = "1排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 6,
                   SeatAreaId = 9,
                   Number = "1排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 7,
                   SeatAreaId = 9,
                   Number = "1排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 8,
                   SeatAreaId = 9,
                   Number = "1排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 9,
                   SeatAreaId = 9,
                   Number = "1排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 10,
                   SeatAreaId = 9,
                   Number = "1排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 11,
                   SeatAreaId = 9,
                   Number = "1排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 12,
                   SeatAreaId = 9,
                   Number = "1排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 13,
                   SeatAreaId = 9,
                   Number = "1排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 14,
                   SeatAreaId = 9,
                   Number = "1排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 15,
                   SeatAreaId = 9,
                   Number = "1排15號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 16,
                   SeatAreaId = 9,
                   Number = "1排16號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 17,
                   SeatAreaId = 9,
                   Number = "1排17號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 18,
                   SeatAreaId = 9,
                   Number = "2排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 19,
                   SeatAreaId = 9,
                   Number = "2排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 20,
                   SeatAreaId = 9,
                   Number = "2排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 21,
                   SeatAreaId = 9,
                   Number = "2排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 22,
                   SeatAreaId = 9,
                   Number = "2排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 23,
                   SeatAreaId = 9,
                   Number = "2排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 24,
                   SeatAreaId = 9,
                   Number = "2排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 25,
                   SeatAreaId = 9,
                   Number = "2排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 26,
                   SeatAreaId = 9,
                   Number = "2排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 27,
                   SeatAreaId = 9,
                   Number = "2排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 28,
                   SeatAreaId = 9,
                   Number = "2排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 29,
                   SeatAreaId = 9,
                   Number = "2排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 30,
                   SeatAreaId = 9,
                   Number = "2排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 31,
                   SeatAreaId = 9,
                   Number = "2排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 32,
                   SeatAreaId = 9,
                   Number = "2排15號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 33,
                   SeatAreaId = 9,
                   Number = "2排16號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 34,
                   SeatAreaId = 9,
                   Number = "2排17號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 35,
                   SeatAreaId = 9,
                   Number = "3排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 36,
                   SeatAreaId = 9,
                   Number = "3排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 37,
                   SeatAreaId = 9,
                   Number = "3排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 38,
                   SeatAreaId = 9,
                   Number = "3排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 39,
                   SeatAreaId = 9,
                   Number = "3排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 40,
                   SeatAreaId = 9,
                   Number = "3排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 41,
                   SeatAreaId = 9,
                   Number = "3排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 42,
                   SeatAreaId = 9,
                   Number = "3排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 43,
                   SeatAreaId = 9,
                   Number = "3排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 44,
                   SeatAreaId = 9,
                   Number = "3排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 45,
                   SeatAreaId = 9,
                   Number = "3排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 46,
                   SeatAreaId = 9,
                   Number = "3排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 47,
                   SeatAreaId = 9,
                   Number = "3排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 48,
                   SeatAreaId = 9,
                   Number = "3排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 49,
                   SeatAreaId = 9,
                   Number = "3排16號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 50,
                   SeatAreaId = 9,
                   Number = "3排17號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 51,
                   SeatAreaId = 9,
                   Number = "4排1號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 52,
                   SeatAreaId = 9,
                   Number = "4排2號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 53,
                   SeatAreaId = 9,
                   Number = "4排3號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 54,
                   SeatAreaId = 9,
                   Number = "4排4號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 55,
                   SeatAreaId = 9,
                   Number = "4排5號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 56,
                   SeatAreaId = 9,
                   Number = "4排6號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 57,
                   SeatAreaId = 9,
                   Number = "4排7號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 58,
                   SeatAreaId = 9,
                   Number = "4排8號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 59,
                   SeatAreaId = 9,
                   Number = "4排9號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 60,
                   SeatAreaId = 9,
                   Number = "4排10號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 61,
                   SeatAreaId = 9,
                   Number = "4排11號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 62,
                   SeatAreaId = 9,
                   Number = "4排12號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 63,
                   SeatAreaId = 9,
                   Number = "4排13號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               }, 
               new Seat
               {
                   Id = 1,
                   SeatAreaId = 10,
                   Number = "1排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 2,
                   SeatAreaId = 10,
                   Number = "1排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 3,
                   SeatAreaId = 10,
                   Number = "1排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 4,
                   SeatAreaId = 10,
                   Number = "1排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 5,
                   SeatAreaId = 10,
                   Number = "1排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 6,
                   SeatAreaId = 10,
                   Number = "1排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 7,
                   SeatAreaId = 10,
                   Number = "1排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 8,
                   SeatAreaId = 10,
                   Number = "1排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 9,
                   SeatAreaId = 10,
                   Number = "1排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 10,
                   SeatAreaId = 10,
                   Number = "1排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 11,
                   SeatAreaId = 10,
                   Number = "1排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 12,
                   SeatAreaId = 10,
                   Number = "1排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 13,
                   SeatAreaId = 10,
                   Number = "1排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 14,
                   SeatAreaId = 10,
                   Number = "1排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 15,
                   SeatAreaId = 10,
                   Number = "1排15號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 16,
                   SeatAreaId = 10,
                   Number = "1排16號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 17,
                   SeatAreaId = 10,
                   Number = "1排17號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 18,
                   SeatAreaId = 10,
                   Number = "2排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 19,
                   SeatAreaId = 10,
                   Number = "2排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 20,
                   SeatAreaId = 10,
                   Number = "2排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 21,
                   SeatAreaId = 10,
                   Number = "2排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 22,
                   SeatAreaId = 10,
                   Number = "2排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 23,
                   SeatAreaId = 10,
                   Number = "2排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 24,
                   SeatAreaId = 10,
                   Number = "2排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 25,
                   SeatAreaId = 10,
                   Number = "2排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 26,
                   SeatAreaId = 10,
                   Number = "2排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 27,
                   SeatAreaId = 10,
                   Number = "2排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 28,
                   SeatAreaId = 10,
                   Number = "2排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 29,
                   SeatAreaId = 10,
                   Number = "2排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 30,
                   SeatAreaId = 10,
                   Number = "2排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 31,
                   SeatAreaId = 10,
                   Number = "2排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 32,
                   SeatAreaId = 10,
                   Number = "2排15號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 33,
                   SeatAreaId = 10,
                   Number = "2排16號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 34,
                   SeatAreaId = 10,
                   Number = "2排17號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 35,
                   SeatAreaId = 10,
                   Number = "3排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 36,
                   SeatAreaId = 10,
                   Number = "3排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 37,
                   SeatAreaId = 10,
                   Number = "3排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 38,
                   SeatAreaId = 10,
                   Number = "3排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 39,
                   SeatAreaId = 10,
                   Number = "3排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 40,
                   SeatAreaId = 10,
                   Number = "3排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 41,
                   SeatAreaId = 10,
                   Number = "3排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 42,
                   SeatAreaId = 10,
                   Number = "3排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 43,
                   SeatAreaId = 10,
                   Number = "3排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 44,
                   SeatAreaId = 10,
                   Number = "3排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 45,
                   SeatAreaId = 10,
                   Number = "3排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 46,
                   SeatAreaId = 10,
                   Number = "3排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 47,
                   SeatAreaId = 10,
                   Number = "3排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 48,
                   SeatAreaId = 10,
                   Number = "3排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 49,
                   SeatAreaId = 10,
                   Number = "3排16號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 50,
                   SeatAreaId = 10,
                   Number = "3排17號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 51,
                   SeatAreaId = 10,
                   Number = "4排1號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 52,
                   SeatAreaId = 10,
                   Number = "4排2號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 53,
                   SeatAreaId = 10,
                   Number = "4排3號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 54,
                   SeatAreaId = 10,
                   Number = "4排4號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 55,
                   SeatAreaId = 10,
                   Number = "4排5號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 56,
                   SeatAreaId = 10,
                   Number = "4排6號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 57,
                   SeatAreaId = 10,
                   Number = "4排7號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 58,
                   SeatAreaId = 10,
                   Number = "4排8號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 59,
                   SeatAreaId = 10,
                   Number = "4排9號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 60,
                   SeatAreaId = 10,
                   Number = "4排10號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 61,
                   SeatAreaId = 10,
                   Number = "4排11號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 62,
                   SeatAreaId = 10,
                   Number = "4排12號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 63,
                   SeatAreaId = 10,
                   Number = "4排13號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               }, 
               new Seat
               {
                   Id = 1,
                   SeatAreaId = 11,
                   Number = "1排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 2,
                   SeatAreaId = 11,
                   Number = "1排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 3,
                   SeatAreaId = 11,
                   Number = "1排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 4,
                   SeatAreaId = 11,
                   Number = "1排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 5,
                   SeatAreaId = 11,
                   Number = "1排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 6,
                   SeatAreaId = 11,
                   Number = "1排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 7,
                   SeatAreaId = 11,
                   Number = "1排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 8,
                   SeatAreaId = 11,
                   Number = "1排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 9,
                   SeatAreaId = 11,
                   Number = "1排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 10,
                   SeatAreaId = 11,
                   Number = "1排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 11,
                   SeatAreaId = 11,
                   Number = "1排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 12,
                   SeatAreaId = 11,
                   Number = "1排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 13,
                   SeatAreaId = 11,
                   Number = "1排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 14,
                   SeatAreaId = 11,
                   Number = "1排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 15,
                   SeatAreaId = 11,
                   Number = "1排15號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 16,
                   SeatAreaId = 11,
                   Number = "1排16號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 17,
                   SeatAreaId = 11,
                   Number = "1排17號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 18,
                   SeatAreaId = 11,
                   Number = "2排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 19,
                   SeatAreaId = 11,
                   Number = "2排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 20,
                   SeatAreaId = 11,
                   Number = "2排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 21,
                   SeatAreaId = 11,
                   Number = "2排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 22,
                   SeatAreaId = 11,
                   Number = "2排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 23,
                   SeatAreaId = 11,
                   Number = "2排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 24,
                   SeatAreaId = 11,
                   Number = "2排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 25,
                   SeatAreaId = 11,
                   Number = "2排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 26,
                   SeatAreaId = 11,
                   Number = "2排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 27,
                   SeatAreaId = 11,
                   Number = "2排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 28,
                   SeatAreaId = 11,
                   Number = "2排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 29,
                   SeatAreaId = 11,
                   Number = "2排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 30,
                   SeatAreaId = 11,
                   Number = "2排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 31,
                   SeatAreaId = 11,
                   Number = "2排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 32,
                   SeatAreaId = 11,
                   Number = "2排15號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 33,
                   SeatAreaId = 11,
                   Number = "2排16號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 34,
                   SeatAreaId = 11,
                   Number = "2排17號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 35,
                   SeatAreaId = 11,
                   Number = "3排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 36,
                   SeatAreaId = 11,
                   Number = "3排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 37,
                   SeatAreaId = 11,
                   Number = "3排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 38,
                   SeatAreaId = 11,
                   Number = "3排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 39,
                   SeatAreaId = 11,
                   Number = "3排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 40,
                   SeatAreaId = 11,
                   Number = "3排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 41,
                   SeatAreaId = 11,
                   Number = "3排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 42,
                   SeatAreaId = 11,
                   Number = "3排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 43,
                   SeatAreaId = 11,
                   Number = "3排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 44,
                   SeatAreaId = 11,
                   Number = "3排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 45,
                   SeatAreaId = 11,
                   Number = "3排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 46,
                   SeatAreaId = 11,
                   Number = "3排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 47,
                   SeatAreaId = 11,
                   Number = "3排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 48,
                   SeatAreaId = 11,
                   Number = "3排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 49,
                   SeatAreaId = 11,
                   Number = "3排16號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 50,
                   SeatAreaId = 11,
                   Number = "3排17號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 51,
                   SeatAreaId = 11,
                   Number = "4排1號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 52,
                   SeatAreaId = 11,
                   Number = "4排2號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 53,
                   SeatAreaId = 11,
                   Number = "4排3號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 54,
                   SeatAreaId = 11,
                   Number = "4排4號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 55,
                   SeatAreaId = 11,
                   Number = "4排5號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 56,
                   SeatAreaId = 11,
                   Number = "4排6號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 57,
                   SeatAreaId = 11,
                   Number = "4排7號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 58,
                   SeatAreaId = 11,
                   Number = "4排8號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 59,
                   SeatAreaId = 11,
                   Number = "4排9號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 60,
                   SeatAreaId = 11,
                   Number = "4排10號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 61,
                   SeatAreaId = 11,
                   Number = "4排11號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 62,
                   SeatAreaId = 11,
                   Number = "4排12號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 63,
                   SeatAreaId = 11,
                   Number = "4排13號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               }, 
               new Seat
               {
                   Id = 1,
                   SeatAreaId = 12,
                   Number = "1排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 2,
                   SeatAreaId = 12,
                   Number = "1排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 3,
                   SeatAreaId = 12,
                   Number = "1排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 4,
                   SeatAreaId = 12,
                   Number = "1排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 5,
                   SeatAreaId = 12,
                   Number = "1排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 6,
                   SeatAreaId = 12,
                   Number = "1排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 7,
                   SeatAreaId = 12,
                   Number = "1排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 8,
                   SeatAreaId = 12,
                   Number = "1排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 9,
                   SeatAreaId = 12,
                   Number = "1排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 10,
                   SeatAreaId = 12,
                   Number = "1排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 11,
                   SeatAreaId = 12,
                   Number = "1排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 12,
                   SeatAreaId = 12,
                   Number = "1排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 13,
                   SeatAreaId = 12,
                   Number = "1排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 14,
                   SeatAreaId = 12,
                   Number = "1排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 15,
                   SeatAreaId = 12,
                   Number = "1排15號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 16,
                   SeatAreaId = 12,
                   Number = "1排16號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 17,
                   SeatAreaId = 12,
                   Number = "1排17號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 18,
                   SeatAreaId = 12,
                   Number = "2排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 19,
                   SeatAreaId = 12,
                   Number = "2排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 20,
                   SeatAreaId = 12,
                   Number = "2排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 21,
                   SeatAreaId = 12,
                   Number = "2排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 22,
                   SeatAreaId = 12,
                   Number = "2排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 23,
                   SeatAreaId = 12,
                   Number = "2排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 24,
                   SeatAreaId = 12,
                   Number = "2排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 25,
                   SeatAreaId = 12,
                   Number = "2排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 26,
                   SeatAreaId = 12,
                   Number = "2排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 27,
                   SeatAreaId = 12,
                   Number = "2排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 28,
                   SeatAreaId = 12,
                   Number = "2排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 29,
                   SeatAreaId = 12,
                   Number = "2排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 30,
                   SeatAreaId = 12,
                   Number = "2排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 31,
                   SeatAreaId = 12,
                   Number = "2排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 32,
                   SeatAreaId = 12,
                   Number = "2排15號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 33,
                   SeatAreaId = 12,
                   Number = "2排16號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 34,
                   SeatAreaId = 12,
                   Number = "2排17號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 35,
                   SeatAreaId = 12,
                   Number = "3排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 36,
                   SeatAreaId = 12,
                   Number = "3排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 37,
                   SeatAreaId = 12,
                   Number = "3排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 38,
                   SeatAreaId = 12,
                   Number = "3排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 39,
                   SeatAreaId = 12,
                   Number = "3排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 40,
                   SeatAreaId = 12,
                   Number = "3排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 41,
                   SeatAreaId = 12,
                   Number = "3排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 42,
                   SeatAreaId = 12,
                   Number = "3排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 43,
                   SeatAreaId = 12,
                   Number = "3排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 44,
                   SeatAreaId = 12,
                   Number = "3排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 45,
                   SeatAreaId = 12,
                   Number = "3排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 46,
                   SeatAreaId = 12,
                   Number = "3排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 47,
                   SeatAreaId = 12,
                   Number = "3排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 48,
                   SeatAreaId = 12,
                   Number = "3排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 49,
                   SeatAreaId = 12,
                   Number = "3排16號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 50,
                   SeatAreaId = 12,
                   Number = "3排17號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 51,
                   SeatAreaId = 12,
                   Number = "4排1號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 52,
                   SeatAreaId = 12,
                   Number = "4排2號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 53,
                   SeatAreaId = 12,
                   Number = "4排3號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 54,
                   SeatAreaId = 12,
                   Number = "4排4號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 55,
                   SeatAreaId = 12,
                   Number = "4排5號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 56,
                   SeatAreaId = 12,
                   Number = "4排6號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 57,
                   SeatAreaId = 12,
                   Number = "4排7號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 58,
                   SeatAreaId = 12,
                   Number = "4排8號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 59,
                   SeatAreaId = 12,
                   Number = "4排9號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 60,
                   SeatAreaId = 12,
                   Number = "4排10號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 61,
                   SeatAreaId = 12,
                   Number = "4排11號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 62,
                   SeatAreaId = 12,
                   Number = "4排12號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 63,
                   SeatAreaId = 12,
                   Number = "4排13號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               }, 
               new Seat
               {
                   Id = 1,
                   SeatAreaId = 13,
                   Number = "1排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 2,
                   SeatAreaId = 13,
                   Number = "1排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 3,
                   SeatAreaId = 13,
                   Number = "1排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 4,
                   SeatAreaId = 13,
                   Number = "1排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 5,
                   SeatAreaId = 13,
                   Number = "1排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 6,
                   SeatAreaId = 13,
                   Number = "1排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 7,
                   SeatAreaId = 13,
                   Number = "1排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 8,
                   SeatAreaId = 13,
                   Number = "1排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 9,
                   SeatAreaId = 13,
                   Number = "1排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 10,
                   SeatAreaId = 13,
                   Number = "1排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 11,
                   SeatAreaId = 13,
                   Number = "1排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 12,
                   SeatAreaId = 13,
                   Number = "1排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 13,
                   SeatAreaId = 13,
                   Number = "1排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 14,
                   SeatAreaId = 13,
                   Number = "1排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 15,
                   SeatAreaId = 13,
                   Number = "1排15號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 16,
                   SeatAreaId = 13,
                   Number = "1排16號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 17,
                   SeatAreaId = 13,
                   Number = "1排17號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 18,
                   SeatAreaId = 13,
                   Number = "2排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 19,
                   SeatAreaId = 13,
                   Number = "2排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 20,
                   SeatAreaId = 13,
                   Number = "2排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 21,
                   SeatAreaId = 13,
                   Number = "2排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 22,
                   SeatAreaId = 13,
                   Number = "2排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 23,
                   SeatAreaId = 13,
                   Number = "2排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 24,
                   SeatAreaId = 13,
                   Number = "2排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 25,
                   SeatAreaId = 13,
                   Number = "2排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 26,
                   SeatAreaId = 13,
                   Number = "2排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 27,
                   SeatAreaId = 13,
                   Number = "2排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 28,
                   SeatAreaId = 13,
                   Number = "2排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 29,
                   SeatAreaId = 13,
                   Number = "2排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 30,
                   SeatAreaId = 13,
                   Number = "2排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 31,
                   SeatAreaId = 13,
                   Number = "2排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 32,
                   SeatAreaId = 13,
                   Number = "2排15號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 33,
                   SeatAreaId = 13,
                   Number = "2排16號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 34,
                   SeatAreaId = 13,
                   Number = "2排17號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 35,
                   SeatAreaId = 13,
                   Number = "3排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 36,
                   SeatAreaId = 13,
                   Number = "3排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 37,
                   SeatAreaId = 13,
                   Number = "3排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 38,
                   SeatAreaId = 13,
                   Number = "3排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 39,
                   SeatAreaId = 13,
                   Number = "3排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 40,
                   SeatAreaId = 13,
                   Number = "3排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 41,
                   SeatAreaId = 13,
                   Number = "3排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 42,
                   SeatAreaId = 13,
                   Number = "3排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 43,
                   SeatAreaId = 13,
                   Number = "3排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 44,
                   SeatAreaId = 13,
                   Number = "3排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 45,
                   SeatAreaId = 13,
                   Number = "3排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 46,
                   SeatAreaId = 13,
                   Number = "3排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 47,
                   SeatAreaId = 13,
                   Number = "3排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 48,
                   SeatAreaId = 13,
                   Number = "3排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 49,
                   SeatAreaId = 13,
                   Number = "3排16號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 50,
                   SeatAreaId = 13,
                   Number = "3排17號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 51,
                   SeatAreaId = 13,
                   Number = "4排1號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 52,
                   SeatAreaId = 13,
                   Number = "4排2號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 53,
                   SeatAreaId = 13,
                   Number = "4排3號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 54,
                   SeatAreaId = 13,
                   Number = "4排4號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 55,
                   SeatAreaId = 13,
                   Number = "4排5號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 56,
                   SeatAreaId = 13,
                   Number = "4排6號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 57,
                   SeatAreaId = 13,
                   Number = "4排7號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 58,
                   SeatAreaId = 13,
                   Number = "4排8號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 59,
                   SeatAreaId = 13,
                   Number = "4排9號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 60,
                   SeatAreaId = 13,
                   Number = "4排10號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 61,
                   SeatAreaId = 13,
                   Number = "4排11號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 62,
                   SeatAreaId = 13,
                   Number = "4排12號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 63,
                   SeatAreaId = 13,
                   Number = "4排13號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               }
           );

            //--------------------SeatArea---------------------------------

            modelBuilder.Entity<SeatArea>().HasData(
              new SeatArea()
              {
                  Id = 1,
                  Name = "1A區",
                  CreatedAt = DateTime.Now.AddDays(-15),
                  EditedAt = null,
                  IsDeleted = false
              },
               new SeatArea()
               {
                   Id = 1,
                   Name = "2A區",
                   CreatedAt = DateTime.Now.AddDays(-15),
                   EditedAt = null,
                   IsDeleted = false
               },
                new SeatArea()
                {
                    Id = 1,
                    Name = "2A區",
                    CreatedAt = DateTime.Now.AddDays(-15),
                    EditedAt = null,
                    IsDeleted = false
                },
             new SeatArea()
             {
                 Id = 2,
                 Name = "2B區",
                 CreatedAt = DateTime.Now.AddDays(-14),
                 EditedAt = null,
                 IsDeleted = false
             },
               new SeatArea()
               {
                   Id = 2,
                   Name = "2C區",
                   CreatedAt = DateTime.Now.AddDays(-13),
                   EditedAt = null,
                   IsDeleted = false
               },
              new SeatArea()
              {
                  Id = 3,
                  Name = "2D區",
                  CreatedAt = DateTime.Now.AddDays(-12),
                  EditedAt = null,
                  IsDeleted = false
              },
              new SeatArea()
              {
                  Id = 4,
                  Name = "2E區",
                  CreatedAt = DateTime.Now.AddDays(-11),
                  EditedAt = null,
                  IsDeleted = false
              }, new SeatArea()
              {
                  Id = 5,
                  Name = "2F區",
                  CreatedAt = DateTime.Now.AddDays(-10),
                  EditedAt = null,
                  IsDeleted = false
              },
               new SeatArea()
               {
                   Id = 6,
                   Name = "2G區",
                   CreatedAt = DateTime.Now.AddDays(-9),
                   EditedAt = null,
                   IsDeleted = false
               },
               new SeatArea()
               {
                   Id = 7,
                   Name = "3A區",
                   CreatedAt = DateTime.Now.AddDays(-8),
                   EditedAt = null,
                   IsDeleted = false
               },
               new SeatArea()
               {
                   Id = 8,
                   Name = "3B區",
                   CreatedAt = DateTime.Now.AddDays(-7),
                   EditedAt = null,
                   IsDeleted = false
               },
               new SeatArea()
               {
                   Id = 9,
                   Name = "3C區",
                   CreatedAt = DateTime.Now.AddDays(-6),
                   EditedAt = null,
                   IsDeleted = false
               },
               new SeatArea()
               {
                   Id = 10,
                   Name = "3D區",
                   CreatedAt = DateTime.Now.AddDays(-5),
                   EditedAt = null,
                   IsDeleted = false
               },
                new SeatArea()
                {
                    Id = 11,
                    Name = "3E區",
                    CreatedAt = DateTime.Now.AddDays(-5),
                    EditedAt = null,
                    IsDeleted = false
                },
                 new SeatArea()
                 {
                     Id = 12,
                     Name = "3F區",
                     CreatedAt = DateTime.Now.AddDays(-7),
                     EditedAt = null,
                     IsDeleted = false
                 },
                  new SeatArea()
                  {
                      Id = 13,
                      Name = "3G區",
                      CreatedAt = DateTime.Now.AddDays(-8),
                      EditedAt = null,
                      IsDeleted = false
                  }
               );
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Nickname = "Alice",
                    Mobile = "0912345678",
                    Birthday = new DateTime(1990, 1, 1),
                    Gender = 1,
                    PersonalUrl = "https://alice.com",
                    PersonalProfile = "I'm Alice!",
                    EdmSubscription = true,
                    Image = "https://image.com/alice.jpg",
                    LastLogInAt = DateTime.Now,
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now
                },
                new User
                {
                    Id = 2,
                    Nickname = "Bob",
                    Mobile = "0987654321",
                    Birthday = new DateTime(1985, 7, 25),
                    Gender = 2,
                    PersonalUrl = null,
                    PersonalProfile = null,
                    EdmSubscription = false,
                    Image = null,
                    LastLogInAt = null,
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = null
                },
                new User
                {
                    Id = 3,
                    Nickname = "Charlie",
                    Mobile = "0955555555",
                    Birthday = new DateTime(1995, 10, 12),
                    Gender = 2,
                    PersonalUrl = "https://charlie.com",
                    PersonalProfile = "Hello world!",
                    EdmSubscription = true,
                    Image = "https://image.com/charlie.png",
                    LastLogInAt = DateTime.Now.AddDays(-5),
                    Status = 1,
                    CreatedAt = DateTime.Now.AddDays(-10),
                    EditedAt = DateTime.Now.AddDays(-2)
                }
            );
            modelBuilder.Entity<LogInInfo>().HasData(
                new LogInInfo
                {
                    UserId = 1,
                    Account = "abc123",
                    Email = "abc@gmail.com",
                    Password = "12345678",
                    CreatedAt = DateTime.Now,
                    EditedAt = null
                },
                new LogInInfo
                {
                    UserId = 2,
                    Account = "def456",
                    Email = "def@gmail.com",
                    Password = "87654321",
                    CreatedAt = DateTime.Now.AddDays(-1),
                    EditedAt = null
                },
                new LogInInfo
                {
                    UserId = 3,
                    Account = "ghi789",
                    Email = "ghi@gmail.com",
                    Password = "98765432",
                    CreatedAt = DateTime.Now.AddDays(-2),
                    EditedAt = null
                }
            );

            modelBuilder.Entity<Event>().HasData(
              new Event
              {
                  Id = 1,
                  OrganizationId = 1,
                  Name = "【線上直播課】掌握網路三大流量，讓你在同行中脫穎而出",
                  StartTime = DateTime.Now.AddDays(14),
                  Type = 0,
                  LocationName = "大巨蛋",
                  LocationAddress = "台北市松山區南京東路四段2號",
                  StreamingPlatform = "http;",
                  StreamingUrl = "http;",
                  Longitude = "120.33333",
                  Latitude = "120.33333",
                  Capacity = 500,
                  ContactPerson = "",
                  ParticipantPeople = "[\r\n  {\r\n    \"ParticipantPeopleImage\": \"https://picsum.photos/200/200/?random=10\",\r\n    \"ParticipantPeopleId\": \"DDDD\"\r\n  },\r\n  {\r\n    \"ParticipantPeopleImage\": \"https://picsum.photos/200/200/?random=14\",\r\n    \"ParticipantPeopleId\": \"EEEE\"\r\n  },\r\n  {\r\n    \"ParticipantPeopleImage\": \"https://picsum.photos/200/200/?random=18\",\r\n    \"ParticipantPeopleId\": \"FFFF\"\r\n  }\r\n]\r\n",
                  EventImage = "https://picsum.photos/1300/600/?random=11",
                  Introduction = "線上活動簡介內容區",
                  Description = "線上活動描述內容區",
                  MainOrganizer = "Build School",
                  IsPrivateEvent = false,
                  IsFree = true,
                  Status = 1,
                  CreatedAt = DateTime.Now,
                  EditedAt = DateTime.Now
              },
              new Event
              {
                  Id = 2,
                  OrganizationId = 2,
                  Name = "【演唱會】五月天",
                  StartTime = DateTime.Now,
                  EndTime = DateTime.Now.AddDays(14),
                  Type = 1,
                  LocationName = "大巨蛋",
                  LocationAddress = "台北市松山區南京東路四段2號",
                  Longitude = "120.33333",
                  Latitude = "120.33333",
                  Capacity = 1000,
                  ContactPerson = "",
                  ParticipantPeople = "[\r\n  {\r\n    \"ParticipantPeopleImage\": \"https://picsum.photos/200/200/?random=10\",\r\n    \"ParticipantPeopleId\": \"DDDD\"\r\n  },\r\n  {\r\n    \"ParticipantPeopleImage\": \"https://picsum.photos/200/200/?random=14\",\r\n    \"ParticipantPeopleId\": \"EEEE\"\r\n  },\r\n  {\r\n    \"ParticipantPeopleImage\": \"https://picsum.photos/200/200/?random=18\",\r\n    \"ParticipantPeopleId\": \"FFFF\"\r\n  }\r\n]\r\n",
                  EventImage = "https://picsum.photos/1300/600/?random=15",
                  Introduction = "實體活動簡介內容區",
                  Description = "實體活動描述內容區",
                  MainOrganizer = "卡米地",
                  IsPrivateEvent = false,
                  IsFree = false,
                  Status = 1,
                  CreatedAt = DateTime.Now,
                  EditedAt = DateTime.Now
              }
           );


            modelBuilder.Entity<CategoryTag>().HasData(
                new CategoryTag
                {
                    Id = 1,
                    Name = "音樂",
                    CreatedAt = DateTime.Now,
                    EditeAt = DateTime.Now,
                },
                new CategoryTag
                {
                    Id = 2,
                    Name = "戲劇",
                    CreatedAt = DateTime.Now,
                    EditeAt = DateTime.Now,
                },
                new CategoryTag
                {
                    Id = 3,
                    Name = "展覽",
                    CreatedAt = DateTime.Now,
                    EditeAt = DateTime.Now,
                }
            );
            modelBuilder.Entity<PreferredActivityArea>().HasData(
                new PreferredActivityArea
                {
                    Id = 1,
                    UserId = 1,
                    AreaId = 1,
                },
                new PreferredActivityArea
                {
                    Id = 2,
                    UserId = 1,
                    AreaId = 2,
                },
                new PreferredActivityArea
                {
                    Id = 3,
                    UserId = 2,
                    AreaId = 3,
                },
                new PreferredActivityArea
                {
                    Id = 4,
                    UserId = 2,
                    AreaId = 4,
                }
                );
            modelBuilder.Entity<Organization>().HasData(
              new Organization
              {
                  Id = 1,
                  OwnerId = 1,
                  Name = "Build School",
                  OrganizationUrl = "HTTP",
                  Description = "組織簡介內容區",
                  ContactName = "Alice",
                  ContactMobile = "0123456789",
                  ContactTelephone = "02-2123-45678",
                  CreatedAt = DateTime.Now,
                  EditedAt = DateTime.Now
              },
              new Organization
              {
                  Id = 2,
                  OwnerId = 2,
                  Name = "卡米地",
                  OrganizationUrl = "HTTP",
                  Description = "組織簡介內容區",
                  ContactName = "Bob",
                  ContactMobile = "0123456789",
                  ContactTelephone = "02-2123-45678",
                  CreatedAt = DateTime.Now,
                  EditedAt = DateTime.Now
              },
              new Organization
              {
                  Id = 3,
                  OwnerId = 3,
                  Name = "海邊的卡夫卡",
                  OrganizationUrl = "HTTP",
                  Description = "組織簡介內容區",
                  ContactName = "Charlie",
                  ContactMobile = "0123456789",
                  ContactTelephone = "02-2123-45678",
                  CreatedAt = DateTime.Now,
                  EditedAt = DateTime.Now
              }
           );
            modelBuilder.Entity<OrganizationAndUserMapping>().HasData(
                new OrganizationAndUserMapping
                {
                    Id = 1,
                    OrganizationId = 1,
                    UserId = 1,
                },
                new OrganizationAndUserMapping
                {
                    Id = 2,
                    OrganizationId = 2,
                    UserId = 2,
                },
                new OrganizationAndUserMapping
                {
                    Id = 3,
                    OrganizationId = 3,
                    UserId = 3,
                }

           );
            modelBuilder.Entity<OrgFan>().HasData(
                 new OrgFan
                 {
                     Id = 1,
                     OrganizationId = 1,
                     UserId = 1,
                     FanTime = DateTime.Now,
                 },
                 new OrgFan
                 {
                     Id = 2,
                     OrganizationId = 2,
                     UserId = 2,
                     FanTime = DateTime.Now.AddDays(-1),
                 }
            );
            modelBuilder.Entity<EventAndTagMapping>().HasData(
                new EventAndTagMapping
                {
                    Id = 1,
                    CategoryTagId = 1,
                    EventId = 1,
                },
                new EventAndTagMapping
                {
                    Id = 2,
                    CategoryTagId = 2,
                    EventId = 2,
                }
                );

            modelBuilder.Entity<TicketType>().HasData(
             new TicketType
             {
                 Id = 1,
                 EventId = 1,
                 Name = "Free",
                 StartSaleTime = DateTime.Now,
                 EndSaleTime = DateTime.Now,
                 CapacityAmount = 300,
                 Price = 0,
                 CreatedAt = DateTime.Now,
                 EditedAt = DateTime.Now
             },
             new TicketType
             {
                 Id = 2,
                 EventId = 2,
                 Name = "搖滾票",
                 StartSaleTime = DateTime.Now,
                 EndSaleTime = DateTime.Now,
                 CapacityAmount = 50,
                 Price = 6800,
                 CreatedAt = DateTime.Now,
                 EditedAt = DateTime.Now
             },
             new TicketType
             {
                 Id = 3,
                 EventId = 2,
                 Name = "一般票",
                 StartSaleTime = DateTime.Now,
                 EndSaleTime = DateTime.Now,
                 CapacityAmount = 200,
                 Price = 2800,
                 CreatedAt = DateTime.Now,
                 EditedAt = DateTime.Now
             },
             new TicketType
             {
                 Id = 4,
                 EventId = 2,
                 Name = "站票",
                 StartSaleTime = DateTime.Now,
                 EndSaleTime = DateTime.Now,
                 CapacityAmount = 400,
                 Price = 800,
                 CreatedAt = DateTime.Now,
                 EditedAt = DateTime.Now
             }
            );
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    UserId = 1,
                    TicketId = 1,
                    SeatNumber = "3排13號",
                    PaymentType = 1,
                    Status = 1,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now.AddDays(-5),
                    ContactPerson = "{\"Name\":\"John Doe\",\"Email\":\"john.doe@example.com\",\"Phone\":\"0912345678\"}",
                    ParticipantPeople = "{\"Name\":\"Jane Smith\",\"Age\":25}",
                    IsDisplayed = true
                },
                new Order
                {
                    Id = 2,
                    UserId = 2,
                    TicketId = 2,
                    SeatNumber = "5排8號",
                    PaymentType = 0,
                    Status = 0,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now.AddDays(-10),
                    EditedAt = null,
                    ContactPerson = "{\"Name\":\"Bob Johnson\",\"Email\":\"bob.johnson@example.com\",\"Phone\":\"0987654321\"}",
                    ParticipantPeople = null,
                    IsDisplayed = false
                },
                new Order
                {
                    Id = 3,
                    UserId = 3,
                    TicketId = 3,
                    SeatNumber = "2排5號",
                    PaymentType = 1,
                    Status = 2,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now.AddDays(-15),
                    EditedAt = DateTime.Now.AddDays(-12),
                    ContactPerson = "{\"Name\":\"Emily Wilson\",\"Email\":\"emily.wilson@example.com\",\"Phone\":\"0923456789\"}",
                    ParticipantPeople = "{\"Name\":\"Michael Brown\",\"Age\":30}",
                    IsDisplayed = true
                }
               );
            modelBuilder.Entity<Ticket>().HasData(
                new Ticket
                {
                    Id = 1,
                    OrderId = 1,
                    TicketTypeId = 1,
                    SeatId = 1,
                    Number = "A123456789",
                    Status = 0,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                    EditedAt = null,
                    CheckCode = 123
                },
                new Ticket
                {
                    Id = 2,
                    OrderId = 2,
                    TicketTypeId = 2,
                    SeatId = null,
                    Number = "B987654321",
                    Status = 1,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now.AddDays(-1),
                    EditedAt = DateTime.Now,
                    CheckCode = 123
                },
                new Ticket
                {
                    Id = 3,
                    OrderId = null,
                    TicketTypeId = 3,
                    SeatId = 3,
                    Number = "C123456789",
                    Status = 0,
                    IsDeleted = true,
                    CreatedAt = DateTime.Now.AddDays(-2),
                    EditedAt = null,
                    CheckCode = 123
                },
                new Ticket
                {
                    Id = 4,
                    OrderId = 1,
                    TicketTypeId = 1,
                    SeatId = 1,
                    Number = "A123456789",
                    Status = 0,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                    EditedAt = null,
                    CheckCode = 123
                },
                new Ticket
                {
                    Id = 5,
                    OrderId = 2,
                    TicketTypeId = 2,
                    SeatId = null,
                    Number = "B987654321",
                    Status = 1,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now.AddDays(-1),
                    EditedAt = DateTime.Now,
                    CheckCode = 123
                }
            );
            modelBuilder.Entity<ArchiveOrder>().HasData(
                new ArchiveOrder
                {
                    OrderId = 1,
                    EventStartTime = DateTime.Parse("2024-03-25 19:00:00"),
                    EventName = "演唱會",
                    LocationName = "台北小巨蛋",
                    LocationAddress = "台北市松山區南京東路四段2號",
                    StreamingPlatform = null,
                    StreamingUrl = null,
                    TicketTypeName = "一般票",
                    TicketNumber = "A123456789",
                    SeatNumber = "3排13號",
                    TicketPrice = 1000,
                    PurchaseAmount = 1,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                    EditedAt = null
                },
                new ArchiveOrder
                {
                    OrderId = 2,
                    EventStartTime = DateTime.Parse("2024-04-01 14:00:00"),
                    EventName = "線上研討會",
                    LocationName = null,
                    LocationAddress = null,
                    StreamingPlatform = "Zoom",
                    StreamingUrl = "https://zoom.us/j/123456789",
                    TicketTypeName = "免費票",
                    TicketNumber = null,
                    SeatNumber = null,
                    TicketPrice = 0,
                    PurchaseAmount = 2,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now.AddDays(-1),
                    EditedAt = null
                });

            modelBuilder.Entity<PreFill>().HasData(
                new PreFill()
                {
                    Id = 1,
                    UserId = 1,
                    Name = "John Doe",
                    Mobile = "0912345678",
                    PostalCode = 106,
                    County = "Taipei",
                    District = "Daan",
                    Address = "No.1, Lane 10, Section 3, Zhongxiao E Rd",
                    CreatedAt = DateTime.Now.AddDays(-10)
                },
                new PreFill()
                {
                    Id = 2,
                    UserId = 2,
                    Name = "Jane Doe",
                    Mobile = "0912345679",
                    PostalCode = 107,
                    County = "New Taipei",
                    District = "Banqiao",
                    Address = "No.100, Guandu Rd",
                    CreatedAt = DateTime.Now.AddDays(-9)
                },
                new PreFill()
                {
                    Id = 3,
                    UserId = 3,
                    Name = "Mike Chen",
                    Mobile = "0923456789",
                    PostalCode = 108,
                    County = "Taoyuan",
                    District = "Zhongli",
                    Address = "No.20, Jhongsing Rd",
                    CreatedAt = DateTime.Now.AddDays(-8)
                });
        }
    }
}