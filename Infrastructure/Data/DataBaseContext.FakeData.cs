using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public partial class DatabaseContext : DbContext
    {
        void FakeDataFilling(ModelBuilder modelBuilder)
        {
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
                }
            );





        }
    }
}