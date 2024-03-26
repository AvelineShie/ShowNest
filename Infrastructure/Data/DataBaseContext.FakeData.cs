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
                   Id = 64,
                   SeatAreaId = 2,
                   Number = "1排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 65,
                   SeatAreaId = 2,
                   Number = "1排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 66,
                   SeatAreaId = 2,
                   Number = "1排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 67,
                   SeatAreaId = 2,
                   Number = "1排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 68,
                   SeatAreaId = 2,
                   Number = "1排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 69,
                   SeatAreaId = 2,
                   Number = "1排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 70,
                   SeatAreaId = 2,
                   Number = "1排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 71,
                   SeatAreaId = 2,
                   Number = "1排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 72,
                   SeatAreaId = 2,
                   Number = "1排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 73,
                   SeatAreaId = 2,
                   Number = "1排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 74,
                   SeatAreaId = 2,
                   Number = "1排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 75,
                   SeatAreaId = 2,
                   Number = "1排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 76,
                   SeatAreaId = 2,
                   Number = "1排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 77,
                   SeatAreaId = 2,
                   Number = "1排15號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 78,
                   SeatAreaId = 2,
                   Number = "1排16號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 79,
                   SeatAreaId = 2,
                   Number = "1排17號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 80,
                   SeatAreaId = 2,
                   Number = "2排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 81,
                   SeatAreaId = 2,
                   Number = "2排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 82,
                   SeatAreaId = 2,
                   Number = "2排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 83,
                   SeatAreaId = 2,
                   Number = "2排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 84,
                   SeatAreaId = 2,
                   Number = "2排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 85,
                   SeatAreaId = 2,
                   Number = "2排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 86,
                   SeatAreaId = 2,
                   Number = "2排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 87,
                   SeatAreaId = 2,
                   Number = "2排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 88,
                   SeatAreaId = 2,
                   Number = "2排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 89,
                   SeatAreaId = 2,
                   Number = "2排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 90,
                   SeatAreaId = 2,
                   Number = "2排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 91,
                   SeatAreaId = 2,
                   Number = "2排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 92,
                   SeatAreaId = 2,
                   Number = "2排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 93,
                   SeatAreaId = 2,
                   Number = "2排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 94,
                   SeatAreaId = 2,
                   Number = "2排15號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 95,
                   SeatAreaId = 2,
                   Number = "2排16號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 96,
                   SeatAreaId = 2,
                   Number = "2排17號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 97,
                   SeatAreaId = 2,
                   Number = "3排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 98,
                   SeatAreaId = 2,
                   Number = "3排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 99,
                   SeatAreaId = 2,
                   Number = "3排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 100,
                   SeatAreaId = 2,
                   Number = "3排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 101,
                   SeatAreaId = 2,
                   Number = "3排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 102,
                   SeatAreaId = 2,
                   Number = "3排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 103,
                   SeatAreaId = 2,
                   Number = "3排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 104,
                   SeatAreaId = 2,
                   Number = "3排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 105,
                   SeatAreaId = 2,
                   Number = "3排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 106,
                   SeatAreaId = 2,
                   Number = "3排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 107,
                   SeatAreaId = 2,
                   Number = "3排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 108,
                   SeatAreaId = 2,
                   Number = "3排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 109,
                   SeatAreaId = 2,
                   Number = "3排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 110,
                   SeatAreaId = 2,
                   Number = "3排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 111,
                   SeatAreaId = 2,
                   Number = "3排16號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 112,
                   SeatAreaId = 2,
                   Number = "3排17號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 113,
                   SeatAreaId = 2,
                   Number = "4排1號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 114,
                   SeatAreaId = 2,
                   Number = "4排2號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 115,
                   SeatAreaId = 2,
                   Number = "4排3號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 116,
                   SeatAreaId = 2,
                   Number = "4排4號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 117,
                   SeatAreaId = 2,
                   Number = "4排5號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 118,
                   SeatAreaId = 2,
                   Number = "4排6號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 119,
                   SeatAreaId = 2,
                   Number = "4排7號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 120,
                   SeatAreaId = 2,
                   Number = "4排8號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 121,
                   SeatAreaId = 2,
                   Number = "4排9號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 122,
                   SeatAreaId = 2,
                   Number = "4排10號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 123,
                   SeatAreaId = 2,
                   Number = "4排11號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 124,
                   SeatAreaId = 2,
                   Number = "4排12號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 125,
                   SeatAreaId = 2,
                   Number = "4排13號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 126,
                   SeatAreaId = 3,
                   Number = "1排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 127,
                   SeatAreaId = 3,
                   Number = "1排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 128,
                   SeatAreaId = 3,
                   Number = "1排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 129,
                   SeatAreaId = 3,
                   Number = "1排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 130,
                   SeatAreaId = 3,
                   Number = "1排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 131,
                   SeatAreaId = 3,
                   Number = "1排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 132,
                   SeatAreaId = 3,
                   Number = "1排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 133,
                   SeatAreaId = 3,
                   Number = "1排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 134,
                   SeatAreaId = 3,
                   Number = "1排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 135,
                   SeatAreaId = 3,
                   Number = "1排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 136,
                   SeatAreaId = 3,
                   Number = "1排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 137,
                   SeatAreaId = 3,
                   Number = "1排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 138,
                   SeatAreaId = 3,
                   Number = "1排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 139,
                   SeatAreaId = 3,
                   Number = "1排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 140,
                   SeatAreaId = 3,
                   Number = "1排15號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 141,
                   SeatAreaId = 3,
                   Number = "1排16號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 142,
                   SeatAreaId = 3,
                   Number = "1排17號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 143,
                   SeatAreaId = 3,
                   Number = "2排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 144,
                   SeatAreaId = 3,
                   Number = "2排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 145,
                   SeatAreaId = 3,
                   Number = "2排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 146,
                   SeatAreaId = 3,
                   Number = "2排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 147,
                   SeatAreaId = 3,
                   Number = "2排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 148,
                   SeatAreaId = 3,
                   Number = "2排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 149,
                   SeatAreaId = 3,
                   Number = "2排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 150,
                   SeatAreaId = 3,
                   Number = "2排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 151,
                   SeatAreaId = 3,
                   Number = "2排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 152,
                   SeatAreaId = 3,
                   Number = "2排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 153,
                   SeatAreaId = 3,
                   Number = "2排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 154,
                   SeatAreaId = 3,
                   Number = "2排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 155,
                   SeatAreaId = 3,
                   Number = "2排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 156,
                   SeatAreaId = 3,
                   Number = "2排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 157,
                   SeatAreaId = 3,
                   Number = "2排15號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 158,
                   SeatAreaId = 3,
                   Number = "2排16號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 159,
                   SeatAreaId = 3,
                   Number = "2排17號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 160,
                   SeatAreaId = 3,
                   Number = "3排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 161,
                   SeatAreaId = 3,
                   Number = "3排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 162,
                   SeatAreaId = 3,
                   Number = "3排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 163,
                   SeatAreaId = 3,
                   Number = "3排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 164,
                   SeatAreaId = 3,
                   Number = "3排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 165,
                   SeatAreaId = 3,
                   Number = "3排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 166,
                   SeatAreaId = 3,
                   Number = "3排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 167,
                   SeatAreaId = 3,
                   Number = "3排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 168,
                   SeatAreaId = 3,
                   Number = "3排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 169,
                   SeatAreaId = 3,
                   Number = "3排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 170,
                   SeatAreaId = 3,
                   Number = "3排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 171,
                   SeatAreaId = 3,
                   Number = "3排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 172,
                   SeatAreaId = 3,
                   Number = "3排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 173,
                   SeatAreaId = 3,
                   Number = "3排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 174,
                   SeatAreaId = 3,
                   Number = "3排16號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 175,
                   SeatAreaId = 3,
                   Number = "3排17號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 176,
                   SeatAreaId = 3,
                   Number = "4排1號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 177,
                   SeatAreaId = 3,
                   Number = "4排2號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 178,
                   SeatAreaId = 3,
                   Number = "4排3號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 179,
                   SeatAreaId = 3,
                   Number = "4排4號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 180,
                   SeatAreaId = 3,
                   Number = "4排5號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 181,
                   SeatAreaId = 3,
                   Number = "4排6號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 182,
                   SeatAreaId = 3,
                   Number = "4排7號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 183,
                   SeatAreaId = 3,
                   Number = "4排8號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 184,
                   SeatAreaId = 3,
                   Number = "4排9號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 185,
                   SeatAreaId = 3,
                   Number = "4排10號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 186,
                   SeatAreaId = 3,
                   Number = "4排11號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 187,
                   SeatAreaId = 3,
                   Number = "4排12號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 188,
                   SeatAreaId = 3,
                   Number = "4排13號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 189,
                   SeatAreaId = 4,
                   Number = "1排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 190,
                   SeatAreaId = 4,
                   Number = "1排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 191,
                   SeatAreaId = 4,
                   Number = "1排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 192,
                   SeatAreaId = 4,
                   Number = "1排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 193,
                   SeatAreaId = 4,
                   Number = "1排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 194,
                   SeatAreaId = 4,
                   Number = "1排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 195,
                   SeatAreaId = 4,
                   Number = "1排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 196,
                   SeatAreaId = 4,
                   Number = "1排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 197,
                   SeatAreaId = 4,
                   Number = "1排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 198,
                   SeatAreaId = 4,
                   Number = "1排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 199,
                   SeatAreaId = 4,
                   Number = "1排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 200,
                   SeatAreaId = 4,
                   Number = "1排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 201,
                   SeatAreaId = 4,
                   Number = "1排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 202,
                   SeatAreaId = 4,
                   Number = "1排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 203,
                   SeatAreaId = 4,
                   Number = "1排15號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 204,
                   SeatAreaId = 4,
                   Number = "1排16號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 205,
                   SeatAreaId = 4,
                   Number = "1排17號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 206,
                   SeatAreaId = 4,
                   Number = "2排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 207,
                   SeatAreaId = 4,
                   Number = "2排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 208,
                   SeatAreaId = 4,
                   Number = "2排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 209,
                   SeatAreaId = 4,
                   Number = "2排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 210,
                   SeatAreaId = 4,
                   Number = "2排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 211,
                   SeatAreaId = 4,
                   Number = "2排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 212,
                   SeatAreaId = 4,
                   Number = "2排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 213,
                   SeatAreaId = 4,
                   Number = "2排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 214,
                   SeatAreaId = 4,
                   Number = "2排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 215,
                   SeatAreaId = 4,
                   Number = "2排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 216,
                   SeatAreaId = 4,
                   Number = "2排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 217,
                   SeatAreaId = 4,
                   Number = "2排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 218,
                   SeatAreaId = 4,
                   Number = "2排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 219,
                   SeatAreaId = 4,
                   Number = "2排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 220,
                   SeatAreaId = 4,
                   Number = "2排15號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 221,
                   SeatAreaId = 4,
                   Number = "2排16號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 222,
                   SeatAreaId = 4,
                   Number = "2排17號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 223,
                   SeatAreaId = 4,
                   Number = "3排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 224,
                   SeatAreaId = 4,
                   Number = "3排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 225,
                   SeatAreaId = 4,
                   Number = "3排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 226,
                   SeatAreaId = 4,
                   Number = "3排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 227,
                   SeatAreaId = 4,
                   Number = "3排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 228,
                   SeatAreaId = 4,
                   Number = "3排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 229,
                   SeatAreaId = 4,
                   Number = "3排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 230,
                   SeatAreaId = 4,
                   Number = "3排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 231,
                   SeatAreaId = 4,
                   Number = "3排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 232,
                   SeatAreaId = 4,
                   Number = "3排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 233,
                   SeatAreaId = 4,
                   Number = "3排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
                new Seat
                {
                    Id = 234,
                    SeatAreaId = 4,
                    Number = "3排12號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 235,
                    SeatAreaId = 4,
                    Number = "3排13號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 236,
                    SeatAreaId = 4,
                    Number = "3排14號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 237,
                    SeatAreaId = 4,
                    Number = "3排16號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 238,
                    SeatAreaId = 4,
                    Number = "3排17號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 239,
                    SeatAreaId = 4,
                    Number = "4排1號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 240,
                    SeatAreaId = 4,
                    Number = "4排2號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 241,
                    SeatAreaId = 4,
                    Number = "4排3號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 242,
                    SeatAreaId = 4,
                    Number = "4排4號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 243,
                    SeatAreaId = 4,
                    Number = "4排5號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 244,
                    SeatAreaId = 4,
                    Number = "4排6號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 245,
                    SeatAreaId = 4,
                    Number = "4排7號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 248,
                    SeatAreaId = 4,
                    Number = "4排10號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 249,
                    SeatAreaId = 4,
                    Number = "4排11號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 250,
                    SeatAreaId = 4,
                    Number = "4排12號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 251,
                    SeatAreaId = 4,
                    Number = "4排13號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 246,
                    SeatAreaId = 5,
                    Number = "1排1號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 247,
                    SeatAreaId = 5,
                    Number = "1排2號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 252,
                    SeatAreaId = 5,
                    Number = "1排7號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
               new Seat
               {
                   Id = 253,
                   SeatAreaId = 5,
                   Number = "1排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
                new Seat
                {
                    Id = 254,
                    SeatAreaId = 5,
                    Number = "1排9號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 255,
                    SeatAreaId = 5,
                    Number = "1排10號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 256,
                    SeatAreaId = 5,
                    Number = "1排11號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 257,
                    SeatAreaId = 5,
                    Number = "1排12號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 258,
                    SeatAreaId = 5,
                    Number = "1排13號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 259,
                    SeatAreaId = 5,
                    Number = "1排14號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 260,
                    SeatAreaId = 5,
                    Number = "1排15號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 261,
                    SeatAreaId = 5,
                    Number = "1排16號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 262,
                    SeatAreaId = 5,
                    Number = "1排17號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 263,
                    SeatAreaId = 5,
                    Number = "2排1號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 264,
                    SeatAreaId = 5,
                    Number = "2排2號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 265,
                    SeatAreaId = 5,
                    Number = "2排3號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 266,
                    SeatAreaId = 5,
                    Number = "2排4號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 267,
                    SeatAreaId = 5,
                    Number = "2排5號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
              new Seat
              {
                  Id = 268,
                  SeatAreaId = 5,
                  Number = "2排6號",
                  Status = 1,
                  CreatedAt = DateTime.Now,
                  EditedAt = DateTime.Now,
                  IsDeleted = false
              },
                new Seat
                {
                    Id = 269,
                    SeatAreaId = 5,
                    Number = "2排7號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 270,
                    SeatAreaId = 5,
                    Number = "2排8號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 271,
                    SeatAreaId = 5,
                    Number = "2排9號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 272,
                    SeatAreaId = 5,
                    Number = "2排10號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 273,
                    SeatAreaId = 5,
                    Number = "2排11號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 274,
                    SeatAreaId = 5,
                    Number = "2排12號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 275,
                    SeatAreaId = 5,
                    Number = "2排13號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 276,
                    SeatAreaId = 5,
                    Number = "2排14號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 277,
                    SeatAreaId = 5,
                    Number = "2排15號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 278,
                    SeatAreaId = 5,
                    Number = "2排16號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 279,
                    SeatAreaId = 5,
                    Number = "2排17號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 280,
                    SeatAreaId = 5,
                    Number = "3排1號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 281,
                    SeatAreaId = 5,
                    Number = "3排2號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 282,
                    SeatAreaId = 5,
                    Number = "3排3號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 283,
                    SeatAreaId = 5,
                    Number = "3排4號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 284,
                    SeatAreaId = 5,
                    Number = "3排5號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 285,
                    SeatAreaId = 5,
                    Number = "3排6號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 286,
                    SeatAreaId = 5,
                    Number = "3排7號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 287,
                    SeatAreaId = 5,
                    Number = "3排8號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 288,
                    SeatAreaId = 5,
                    Number = "3排9號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
               new Seat
               {
                   Id = 289,
                   SeatAreaId = 5,
                   Number = "3排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
                new Seat
                {
                    Id = 290,
                    SeatAreaId = 5,
                    Number = "3排11號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 291,
                    SeatAreaId = 5,
                    Number = "3排12號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 292,
                    SeatAreaId = 5,
                    Number = "3排13號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 293,
                    SeatAreaId = 5,
                    Number = "3排14號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 294,
                    SeatAreaId = 5,
                    Number = "3排16號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 295,
                    SeatAreaId = 5,
                    Number = "3排17號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 296,
                    SeatAreaId = 5,
                    Number = "4排1號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 297,
                    SeatAreaId = 5,
                    Number = "4排2號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 298,
                    SeatAreaId = 5,
                    Number = "4排3號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 299,
                    SeatAreaId = 5,
                    Number = "4排4號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 300,
                    SeatAreaId = 5,
                    Number = "4排5號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 301,
                    SeatAreaId = 5,
                    Number = "4排6號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 302,
                    SeatAreaId = 5,
                    Number = "4排7號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 303,
                    SeatAreaId = 5,
                    Number = "4排8號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 304,
                    SeatAreaId = 5,
                    Number = "4排9號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 305,
                    SeatAreaId = 5,
                    Number = "4排10號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 306,
                    SeatAreaId = 5,
                    Number = "4排11號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 307,
                    SeatAreaId = 5,
                    Number = "4排12號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 308,
                    SeatAreaId = 5,
                    Number = "4排13號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 309,
                    SeatAreaId = 5,
                    Number = "4排15號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 310,
                    SeatAreaId = 5,
                    Number = "4排16號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 311,
                    SeatAreaId = 5,
                    Number = "4排17號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 312,
                    SeatAreaId = 5,
                    Number = "5排1號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 313,
                    SeatAreaId = 5,
                    Number = "5排2號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 314,
                    SeatAreaId = 5,
                    Number = "5排3號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 315,
                    SeatAreaId = 5,
                    Number = "5排4號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 316,
                    SeatAreaId = 5,
                    Number = "5排5號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 317,
                    SeatAreaId = 5,
                    Number = "5排6號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 318,
                    SeatAreaId = 5,
                    Number = "5排7號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 319,
                    SeatAreaId = 5,
                    Number = "5排8號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
               new Seat
               {
                   Id = 320,
                   SeatAreaId = 6,
                   Number = "4排5號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
                new Seat
                {
                    Id = 321,
                    SeatAreaId = 6,
                    Number = "4排6號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 322,
                    SeatAreaId = 6,
                    Number = "4排7號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 323,
                    SeatAreaId = 6,
                    Number = "4排8號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 324,
                    SeatAreaId = 6,
                    Number = "4排9號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 325,
                    SeatAreaId = 6,
                    Number = "4排10號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 326,
                    SeatAreaId = 6,
                    Number = "4排11號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 327,
                    SeatAreaId = 6,
                    Number = "4排12號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 328,
                    SeatAreaId = 6,
                    Number = "4排13號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 329,
                    SeatAreaId = 6,
                    Number = "4排14號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
              new Seat
              {
                  Id = 330,
                  SeatAreaId = 7,
                  Number = "2排2號",
                  Status = 1,
                  CreatedAt = DateTime.Now,
                  EditedAt = DateTime.Now,
                  IsDeleted = false
              },
                new Seat
                {
                    Id = 331,
                    SeatAreaId = 7,
                    Number = "2排3號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 332,
                    SeatAreaId = 7,
                    Number = "2排4號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 333,
                    SeatAreaId = 7,
                    Number = "2排5號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 334,
                    SeatAreaId = 7,
                    Number = "2排6號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 335,
                    SeatAreaId = 7,
                    Number = "2排7號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 336,
                    SeatAreaId = 7,
                    Number = "2排8號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 337,
                    SeatAreaId = 7,
                    Number = "2排9號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 338,
                    SeatAreaId = 7,
                    Number = "2排10號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 339,
                    SeatAreaId = 7,
                    Number = "2排11號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
               new Seat
               {
                   Id = 340,
                   SeatAreaId = 7,
                   Number = "4排10號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
                new Seat
                {
                    Id = 341,
                    SeatAreaId = 7,
                    Number = "4排11號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 342,
                    SeatAreaId = 7,
                    Number = "4排12號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 343,
                    SeatAreaId = 7,
                    Number = "4排13號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 344,
                    SeatAreaId = 7,
                    Number = "4排14號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 345,
                    SeatAreaId = 7,
                    Number = "4排15號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 346,
                    SeatAreaId = 7,
                    Number = "4排16號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 347,
                    SeatAreaId = 7,
                    Number = "4排17號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
               new Seat
               {
                   Id = 348,
                   SeatAreaId = 8,
                   Number = "4排5號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
                new Seat
                {
                    Id = 349,
                    SeatAreaId = 8,
                    Number = "4排6號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 350,
                    SeatAreaId = 8,
                    Number = "4排7號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 351,
                    SeatAreaId = 8,
                    Number = "4排8號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 352,
                    SeatAreaId = 8,
                    Number = "4排9號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 353,
                    SeatAreaId = 8,
                    Number = "4排10號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 354,
                    SeatAreaId = 8,
                    Number = "4排11號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 355,
                    SeatAreaId = 8,
                    Number = "4排12號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
              new Seat
              {
                  Id = 356,
                  SeatAreaId = 9,
                  Number = "3排18號",
                  Status = 0,
                  CreatedAt = DateTime.Now,
                  EditedAt = DateTime.Now,
                  IsDeleted = false
              },
                new Seat
                {
                    Id = 357,
                    SeatAreaId = 9,
                    Number = "3排19號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 358,
                    SeatAreaId = 9,
                    Number = "3排20號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 359,
                    SeatAreaId = 9,
                    Number = "3排21號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 360,
                    SeatAreaId = 9,
                    Number = "3排22號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 361,
                    SeatAreaId = 9,
                    Number = "3排23號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 362,
                    SeatAreaId = 9,
                    Number = "3排24號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 363,
                    SeatAreaId = 9,
                    Number = "3排25號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
               new Seat
               {
                   Id = 364,
                   SeatAreaId = 10,
                   Number = "3排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
                new Seat
                {
                    Id = 365,
                    SeatAreaId = 10,
                    Number = "3排13號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 366,
                    SeatAreaId = 10,
                    Number = "3排14號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 367,
                    SeatAreaId = 10,
                    Number = "3排15號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 368,
                    SeatAreaId = 10,
                    Number = "3排16號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 369,
                    SeatAreaId = 10,
                    Number = "3排17號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 370,
                    SeatAreaId = 10,
                    Number = "3排18號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 371,
                    SeatAreaId = 10,
                    Number = "3排19號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 372,
                    SeatAreaId = 10,
                    Number = "3排20號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 373,
                    SeatAreaId = 10,
                    Number = "3排21號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
               new Seat
               {
                   Id = 374,
                   SeatAreaId = 11,
                   Number = "3排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
                new Seat
                {
                    Id = 375,
                    SeatAreaId = 11,
                    Number = "3排7號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 376,
                    SeatAreaId = 11,
                    Number = "3排8號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 377,
                    SeatAreaId = 11,
                    Number = "3排9號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 378,
                    SeatAreaId = 11,
                    Number = "3排10號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 379,
                    SeatAreaId = 11,
                    Number = "3排11號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 380,
                    SeatAreaId = 11,
                    Number = "3排12號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 381,
                    SeatAreaId = 11,
                    Number = "3排13號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 382,
                    SeatAreaId = 11,
                    Number = "3排14號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 383,
                    SeatAreaId = 11,
                    Number = "3排15號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
               new Seat
               {
                   Id = 384,
                   SeatAreaId = 12,
                   Number = "4排10號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
                new Seat
                {
                    Id = 385,
                    SeatAreaId = 12,
                    Number = "4排11號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 386,
                    SeatAreaId = 12,
                    Number = "4排12號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 387,
                    SeatAreaId = 12,
                    Number = "4排13號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 388,
                    SeatAreaId = 12,
                    Number = "4排14號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 389,
                    SeatAreaId = 12,
                    Number = "4排15號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 390,
                    SeatAreaId = 12,
                    Number = "4排16號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 391,
                    SeatAreaId = 12,
                    Number = "4排17號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 392,
                    SeatAreaId = 12,
                    Number = "5排1號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 393,
                    SeatAreaId = 12,
                    Number = "5排2號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 394,
                    SeatAreaId = 12,
                    Number = "5排3號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 395,
                    SeatAreaId = 12,
                    Number = "5排4號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 396,
                    SeatAreaId = 12,
                    Number = "5排5號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 397,
                    SeatAreaId = 12,
                    Number = "5排6號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 398,
                    SeatAreaId = 12,
                    Number = "5排7號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 399,
                    SeatAreaId = 12,
                    Number = "5排8號",
                    Status = 0,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
              new Seat
              {
                  Id = 400,
                  SeatAreaId = 12,
                  Number = "4排10號",
                  Status = 0,
                  CreatedAt = DateTime.Now,
                  EditedAt = DateTime.Now,
                  IsDeleted = false
              },
                 new Seat
                 {
                     Id = 401,
                     SeatAreaId = 12,
                     Number = "4排11號",
                     Status = 0,
                     CreatedAt = DateTime.Now,
                     EditedAt = DateTime.Now,
                     IsDeleted = false
                 },
                 new Seat
                 {
                     Id = 402,
                     SeatAreaId = 12,
                     Number = "4排12號",
                     Status = 0,
                     CreatedAt = DateTime.Now,
                     EditedAt = DateTime.Now,
                     IsDeleted = false
                 },
                 new Seat
                 {
                     Id = 403,
                     SeatAreaId = 12,
                     Number = "4排13號",
                     Status = 0,
                     CreatedAt = DateTime.Now,
                     EditedAt = DateTime.Now,
                     IsDeleted = false
                 },
                 new Seat
                 {
                     Id = 404,
                     SeatAreaId = 13,
                     Number = "1排1號",
                     Status = 1,
                     CreatedAt = DateTime.Now,
                     EditedAt = DateTime.Now,
                     IsDeleted = false
                 },
                 new Seat
                 {
                     Id = 405,
                     SeatAreaId = 13,
                     Number = "1排2號",
                     Status = 1,
                     CreatedAt = DateTime.Now,
                     EditedAt = DateTime.Now,
                     IsDeleted = false
                 },
                 new Seat
                 {
                     Id = 406,
                     SeatAreaId = 13,
                     Number = "1排3號",
                     Status = 1,
                     CreatedAt = DateTime.Now,
                     EditedAt = DateTime.Now,
                     IsDeleted = false
                 },
                 new Seat
                 {
                     Id = 407,
                     SeatAreaId = 13,
                     Number = "1排4號",
                     Status = 1,
                     CreatedAt = DateTime.Now,
                     EditedAt = DateTime.Now,
                     IsDeleted = false
                 },
                 new Seat
                 {
                     Id = 408,
                     SeatAreaId = 13,
                     Number = "1排5號",
                     Status = 1,
                     CreatedAt = DateTime.Now,
                     EditedAt = DateTime.Now,
                     IsDeleted = false
                 },
                 new Seat
                 {
                     Id = 409,
                     SeatAreaId = 13,
                     Number = "1排6號",
                     Status = 1,
                     CreatedAt = DateTime.Now,
                     EditedAt = DateTime.Now,
                     IsDeleted = false
                 },
                 new Seat
                 {
                     Id = 410,
                     SeatAreaId = 13,
                     Number = "1排7號",
                     Status = 1,
                     CreatedAt = DateTime.Now,
                     EditedAt = DateTime.Now,
                     IsDeleted = false
                 },
                 new Seat
                 {
                     Id = 411,
                     SeatAreaId = 13,
                     Number = "1排8號",
                     Status = 1,
                     CreatedAt = DateTime.Now,
                     EditedAt = DateTime.Now,
                     IsDeleted = false
                 },
              new Seat
              {
                  Id = 412,
                  SeatAreaId = 13,
                  Number = "1排9號",
                  Status = 1,
                  CreatedAt = DateTime.Now,
                  EditedAt = DateTime.Now,
                  IsDeleted = false
              },
                new Seat
                {
                    Id = 413,
                    SeatAreaId = 13,
                    Number = "1排10號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                }, new Seat
                {
                    Id = 414,
                    SeatAreaId = 13,
                    Number = "1排11號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 415,
                    SeatAreaId = 13,
                    Number = "1排12號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
              new Seat
              {
                  Id = 416,
                  SeatAreaId = 13,
                  Number = "1排13號",
                  Status = 1,
                  CreatedAt = DateTime.Now,
                  EditedAt = DateTime.Now,
                  IsDeleted = false
              },
                new Seat
                {
                    Id = 417,
                    SeatAreaId = 13,
                    Number = "1排14號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                }, new Seat
                {
                    Id = 418,
                    SeatAreaId = 13,
                    Number = "1排15號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 419,
                    SeatAreaId = 13,
                    Number = "1排16號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                }, new Seat
                {
                    Id = 420,
                    SeatAreaId = 13,
                    Number = "1排17號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 421,
                    SeatAreaId = 13,
                    Number = "2排1號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
                new Seat
                {
                    Id = 422,
                    SeatAreaId = 13,
                    Number = "2排2號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
              new Seat
              {
                  Id = 423,
                  SeatAreaId = 13,
                  Number = "2排3號",
                  Status = 1,
                  CreatedAt = DateTime.Now,
                  EditedAt = DateTime.Now,
                  IsDeleted = false
              },
                new Seat
                {
                    Id = 424,
                    SeatAreaId = 13,
                    Number = "2排4號",
                    Status = 1,
                    CreatedAt = DateTime.Now,
                    EditedAt = DateTime.Now,
                    IsDeleted = false
                },
               new Seat
               {
                   Id = 425,
                   SeatAreaId = 13,
                   Number = "2排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 426,
                   SeatAreaId = 13,
                   Number = "2排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 427,
                   SeatAreaId = 13,
                   Number = "2排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 428,
                   SeatAreaId = 13,
                   Number = "2排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 429,
                   SeatAreaId = 13,
                   Number = "2排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 430,
                   SeatAreaId = 13,
                   Number = "2排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 431,
                   SeatAreaId = 13,
                   Number = "2排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 432,
                   SeatAreaId = 13,
                   Number = "2排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 433,
                   SeatAreaId = 13,
                   Number = "2排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 434,
                   SeatAreaId = 13,
                   Number = "2排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 435,
                   SeatAreaId = 13,
                   Number = "2排15號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 436,
                   SeatAreaId = 13,
                   Number = "2排16號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 437,
                   SeatAreaId = 13,
                   Number = "2排17號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 438,
                   SeatAreaId = 13,
                   Number = "3排1號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 439,
                   SeatAreaId = 13,
                   Number = "3排2號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 440,
                   SeatAreaId = 13,
                   Number = "3排3號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 441,
                   SeatAreaId = 13,
                   Number = "3排4號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 442,
                   SeatAreaId = 13,
                   Number = "3排5號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 443,
                   SeatAreaId = 13,
                   Number = "3排6號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 444,
                   SeatAreaId = 13,
                   Number = "3排7號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 445,
                   SeatAreaId = 13,
                   Number = "3排8號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 446,
                   SeatAreaId = 13,
                   Number = "3排9號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 447,
                   SeatAreaId = 13,
                   Number = "3排10號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 448,
                   SeatAreaId = 13,
                   Number = "3排11號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 449,
                   SeatAreaId = 13,
                   Number = "3排12號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 450,
                   SeatAreaId = 13,
                   Number = "3排13號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 451,
                   SeatAreaId = 13,
                   Number = "3排14號",
                   Status = 1,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 452,
                   SeatAreaId = 13,
                   Number = "3排16號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 453,
                   SeatAreaId = 13,
                   Number = "3排17號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 454,
                   SeatAreaId = 13,
                   Number = "4排1號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 455,
                   SeatAreaId = 13,
                   Number = "4排2號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 456,
                   SeatAreaId = 13,
                   Number = "4排3號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 457,
                   SeatAreaId = 13,
                   Number = "4排4號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 458,
                   SeatAreaId = 13,
                   Number = "4排5號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 459,
                   SeatAreaId = 13,
                   Number = "4排6號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 460,
                   SeatAreaId = 13,
                   Number = "4排7號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 461,
                   SeatAreaId = 13,
                   Number = "4排8號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 462,
                   SeatAreaId = 13,
                   Number = "4排9號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 463,
                   SeatAreaId = 13,
                   Number = "4排10號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 464,
                   SeatAreaId = 13,
                   Number = "4排11號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 465,
                   SeatAreaId = 13,
                   Number = "4排12號",
                   Status = 0,
                   CreatedAt = DateTime.Now,
                   EditedAt = DateTime.Now,
                   IsDeleted = false
               },
               new Seat
               {
                   Id = 466,
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
                   Id = 2,
                   Name = "2A區",
                   CreatedAt = DateTime.Now.AddDays(-15),
                   EditedAt = null,
                   IsDeleted = false
               },
                new SeatArea()
                {
                    Id = 3,
                    Name = "2A區",
                    CreatedAt = DateTime.Now.AddDays(-15),
                    EditedAt = null,
                    IsDeleted = false
                },
             new SeatArea()
             {
                 Id = 4,
                 Name = "2B區",
                 CreatedAt = DateTime.Now.AddDays(-14),
                 EditedAt = null,
                 IsDeleted = false
             },
               new SeatArea()
               {
                   Id = 5,
                   Name = "2C區",
                   CreatedAt = DateTime.Now.AddDays(-13),
                   EditedAt = null,
                   IsDeleted = false
               },
              new SeatArea()
              {
                  Id = 6,
                  Name = "2D區",
                  CreatedAt = DateTime.Now.AddDays(-12),
                  EditedAt = null,
                  IsDeleted = false
              },
              new SeatArea()
              {
                  Id = 7,
                  Name = "2E區",
                  CreatedAt = DateTime.Now.AddDays(-11),
                  EditedAt = null,
                  IsDeleted = false
              }, new SeatArea()
              {
                  Id = 8,
                  Name = "2F區",
                  CreatedAt = DateTime.Now.AddDays(-10),
                  EditedAt = null,
                  IsDeleted = false
              },
               new SeatArea()
               {
                   Id = 9,
                   Name = "2G區",
                   CreatedAt = DateTime.Now.AddDays(-9),
                   EditedAt = null,
                   IsDeleted = false
               },
               new SeatArea()
               {
                   Id = 10,
                   Name = "3A區",
                   CreatedAt = DateTime.Now.AddDays(-8),
                   EditedAt = null,
                   IsDeleted = false
               },
               new SeatArea()
               {
                   Id = 11,
                   Name = "3B區",
                   CreatedAt = DateTime.Now.AddDays(-7),
                   EditedAt = null,
                   IsDeleted = false
               },
               new SeatArea()
               {
                   Id = 12,
                   Name = "3C區",
                   CreatedAt = DateTime.Now.AddDays(-6),
                   EditedAt = null,
                   IsDeleted = false
               },
               new SeatArea()
               {
                   Id = 13,
                   Name = "3D區",
                   CreatedAt = DateTime.Now.AddDays(-5),
                   EditedAt = null,
                   IsDeleted = false
               },
                new SeatArea()
                {
                    Id = 14,
                    Name = "3E區",
                    CreatedAt = DateTime.Now.AddDays(-5),
                    EditedAt = null,
                    IsDeleted = false
                },
                 new SeatArea()
                 {
                     Id = 15,
                     Name = "3F區",
                     CreatedAt = DateTime.Now.AddDays(-7),
                     EditedAt = null,
                     IsDeleted = false
                 },
                  new SeatArea()
                  {
                      Id = 16,
                      Name = "3G區",
                      CreatedAt = DateTime.Now.AddDays(-8),
                      EditedAt = null,
                      IsDeleted = false
                  }
               );
            modelBuilder.Entity<User>().HasData(
          modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                Nickname = "Alice",
                Mobile = "0912345678",
                Birthday = new DateTime(1995, 1, 1),
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
            })
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