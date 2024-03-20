using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;


namespace Infrastructure.Data
{
    public partial class DatabaseContext : DbContext
    {
        static void FakeDataFilling(ModelBuilder modelBuilder)
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


            modelBuilder.Entity<Event>().HasData(
              new Event
              {
                  Id = 1,
                  OrganizationId = 1,
                  Name = "【線上直播課】掌握網路三大流量，讓你在同行中脫穎而出",
                  StartTime = DateTime.Now.AddDays(14),
                  Type = 0,
                  StreamingPlatform = "http;",
                  StreamingUrl = "http;",
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
                  LocationAddress = "",
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
                    Id= 1,
                    Name= "音樂",
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



        }
    }
}