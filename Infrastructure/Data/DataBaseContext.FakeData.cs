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
        }
    }
}