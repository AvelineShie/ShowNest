using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Channels;


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
            modelBuilder.Entity<LogInInfo>().HasData(
                new LogInInfo
                {
                    UserId= 1,
                    Account = "abc123",
                    Email = "abc@gmail.com",
                    Password = "12345678",
                    CreatedAt = DateTime.Now,
                    EditedAt = null
                }, new LogInInfo
                {
                    UserId=2,
                    Account = "def456",
                    Email = "def@gmail.com",
                    Password = "87654321",
                    CreatedAt = DateTime.Now.AddDays(-1),
                    EditedAt = null
                }, new LogInInfo
                {
                    UserId=3,
                    Account = "ghi789",
                    Email = "ghi@gmail.com",
                    Password = "98765432",
                    CreatedAt = DateTime.Now.AddDays(-2),
                    EditedAt = null
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
            modelBuilder.Entity<SeatArea>().HasData(
                new SeatArea
                {
                    Name = "一般座位",
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                    EditedAt = null
                },
                new SeatArea
                {
                    Name = "貴賓席",
                    IsDeleted = false,
                    CreatedAt = DateTime.Now.AddDays(-1),
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
                    UserId = 1,
                    AreaId = 1,
                }, 
                new PreferredActivityArea
                {
                    UserId = 1,
                    AreaId = 2,
                }, 
                new PreferredActivityArea
                {
                    UserId = 2,
                    AreaId = 3,
                }, 
                new PreferredActivityArea
                {
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
                    OrganizationId = 1,
                    UserId = 1,
                }, 
                new OrganizationAndUserMapping
                {
                    OrganizationId = 2,
                    UserId = 2,
                }, 
                new OrganizationAndUserMapping
                {
                    OrganizationId = 3,
                    UserId = 3,
                }

           );
           modelBuilder.Entity<OrgFan>().HasData(
                new OrgFan
                {
                    OrganizationId = 1,
                    UserId = 1,
                    FanTime = DateTime.Now,
                },
                new OrgFan
                {
                    OrganizationId = 2,
                    UserId = 2,
                    FanTime = DateTime.Now.AddDays(-1),
                }
           );
            modelBuilder.Entity<EventAndTagMapping>().HasData(
                new EventAndTagMapping
                {
                    Id=1,
                    CategoryTagId = 1,
                    EventId = 1,
                },
                new EventAndTagMapping
                {
                    Id=2,
                    CategoryTagId = 2,
                    EventId = 2,
                },
                new EventAndTagMapping
                {Id = 3,
                    CategoryTagId = 3,
                    EventId = 3,
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
                },
                new Order
                {
                    Id = 4,
                    UserId = 4,
                    TicketId = 4,
                    SeatNumber = "7排20號",
                    PaymentType = 0,
                    Status = 3,
                    IsDeleted = true,
                    CreatedAt = DateTime.Now.AddDays(-20),
                    EditedAt = DateTime.Now.AddDays(-18),
                    ContactPerson = "{\"Name\":\"Sophia Davis\",\"Email\":\"sophia.davis@example.com\",\"Phone\":\"0935678901\"}",
                    ParticipantPeople = null,
                    IsDisplayed = false
                },
                new Order
                {
                    Id = 5,
                    UserId = 5,
                    TicketId = 5,
                    SeatNumber = "4排3號",
                    PaymentType = 1,
                    Status = 1,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now.AddDays(-25),
                    EditedAt = DateTime.Now.AddDays(-22),
                    ContactPerson = "{\"Name\":\"William Thompson\",\"Email\":\"william.thompson@example.com\",\"Phone\":\"0912345670\"}",
                    ParticipantPeople = "{\"Name\":\"Olivia Johnson\",\"Age\":28}",
                    IsDisplayed = true
                },
                new Order
                {
                    Id = 6,
                    UserId = 6,
                    TicketId = 6,
                    SeatNumber = "6排18號",
                    PaymentType = 0,
                    Status = 0,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now.AddDays(-30),
                    EditedAt = null,
                    ContactPerson = "{\"Name\":\"James Anderson\",\"Email\":\"james.anderson@example.com\",\"Phone\":\"0987654320\"}",
                    ParticipantPeople = null,
                    IsDisplayed = false
                },
                new Order
                {
                    Id = 7,
                    UserId = 7,
                    TicketId = 7,
                    SeatNumber = "1排9號",
                    PaymentType = 1,
                    Status = 2,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now.AddDays(-35),
                    EditedAt = DateTime.Now.AddDays(-32),
                    ContactPerson = "{\"Name\":\"Emma Thomas\",\"Email\":\"emma.thomas@example.com\",\"Phone\":\"0923456780\"}",
                    ParticipantPeople = "{\"Name\":\"Daniel Wilson\",\"Age\":35}",
                    IsDisplayed = true
                },
                new Order
                {
                    Id = 8,
                    UserId = 8,
                    TicketId = 8,
                    SeatNumber = "8排7號",
                    PaymentType = 0,
                    Status = 3,
                    IsDeleted = true,
                    CreatedAt = DateTime.Now.AddDays(-40),
                    EditedAt = DateTime.Now.AddDays(-38),
                    ContactPerson = "{\"Name\":\"Ava Jackson\",\"Email\":\"ava.jackson@example.com\",\"Phone\":\"0935678900\"}",
                    ParticipantPeople = null,
                    IsDisplayed = false
                },
                new Order
                {
                    Id = 9,
                    UserId = 9,
                    TicketId = 9,
                    SeatNumber = "5排15號",
                    PaymentType = 1,
                    Status = 1,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now.AddDays(-45),
                    EditedAt = DateTime.Now.AddDays(-42),
                    ContactPerson = "{\"Name\":\"Michael Taylor\",\"Email\":\"michael.taylor@example.com\",\"Phone\":\"0912345671\"}",
                    ParticipantPeople = "{\"Name\":\"Sophia Davis\",\"Age\":22}",
                    IsDisplayed = true
                },
                new Order
                {
                    Id = 10,
                    UserId = 10,
                    TicketId = 10,
                    SeatNumber = "3排6號",
                    PaymentType = 0,
                    Status = 0,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now.AddDays(-50),
                    EditedAt = null,
                    ContactPerson = "{\"Name\":\"Daniel Brown\",\"Email\":\"daniel.brown@example.com\",\"Phone\":\"0987654321\"}",
                    ParticipantPeople = null,
                    IsDisplayed = false
                },
                new Order
                {
                    Id = 11,
                    UserId = 11,
                    TicketId = 11,
                    SeatNumber = "7排11號",
                    PaymentType = 1,
                    Status = 2,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now.AddDays(-55),
                    EditedAt = DateTime.Now.AddDays(-52),
                    ContactPerson = "{\"Name\":\"Olivia Wilson\",\"Email\":\"olivia.wilson@example.com\",\"Phone\":\"0923456781\"}",
                    ParticipantPeople = "{\"Name\":\"William Johnson\",\"Age\":40}",
                    IsDisplayed = true
                },
                new Order
                {
                    Id = 12,
                    UserId = 12,
                    TicketId = 12,
                    SeatNumber = "4排22號",
                    PaymentType = 0,
                    Status = 3,
                    IsDeleted = true,
                    CreatedAt = DateTime.Now.AddDays(-60),
                    EditedAt = DateTime.Now.AddDays(-58),
                    ContactPerson = "{\"Name\":\"William Davis\",\"Email\":\"william.davis@example.com\",\"Phone\":\"0935678902\"}",
                    ParticipantPeople = null,
                    IsDisplayed = false
                },
                new Order
                {
                    Id = 13,
                    UserId = 13,
                    TicketId = 13,
                    SeatNumber = "6排4號",
                    PaymentType = 1,
                    Status = 1,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now.AddDays(-65),
                    EditedAt = DateTime.Now.AddDays(-62),
                    ContactPerson = "{\"Name\":\"Sophia Thompson\",\"Email\":\"sophia.thompson@example.com\",\"Phone\":\"0912345672\"}",
                    ParticipantPeople = "{\"Name\":\"James Anderson\",\"Age\":27}",
                    IsDisplayed = true
                },
                new Order
                {
                    Id = 14,
                    UserId = 14,
                    TicketId = 14,
                    SeatNumber = "2排17號",
                    PaymentType = 0,
                    Status = 0,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now.AddDays(-70),
                    EditedAt = null,
                    ContactPerson = "{\"Name\":\"James Johnson\",\"Email\":\"james.johnson@example.com\",\"Phone\":\"0987654322\"}",
                    ParticipantPeople = null,
                    IsDisplayed = false
                },
                new Order
                {
                    Id = 15,
                    UserId = 15,
                    TicketId = 15,
                    SeatNumber = "8排12號",
                    PaymentType = 1,
                    Status = 2,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now.AddDays(-75),
                    EditedAt = DateTime.Now.AddDays(-72),
                    ContactPerson = "{\"Name\":\"Emma Brown\",\"Email\":\"emma.brown@example.com\",\"Phone\":\"0923456782\"}",
                    ParticipantPeople = "{\"Name\":\"Olivia Thomas\",\"Age\":32}",
                    IsDisplayed = true
                },
                new Order
                {
                    Id = 16,
                    UserId = 16,
                    TicketId = 16,
                    SeatNumber = "5排2號",
                    PaymentType = 0,
                    Status = 3,
                    IsDeleted = true,
                    CreatedAt = DateTime.Now.AddDays(-80),
                    EditedAt = DateTime.Now.AddDays(-78),
                    ContactPerson = "{\"Name\":\"Ava Wilson\",\"Email\":\"ava.wilson@example.com\",\"Phone\":\"0935678903\"}",
                    ParticipantPeople = null,
                    IsDisplayed = false
                },
                new Order
                {
                    Id = 17,
                    UserId = 17,
                    TicketId = 17,
                    SeatNumber = "6排9號",
                    PaymentType = 1,
                    Status = 1,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now.AddDays(-85),
                    EditedAt = DateTime.Now.AddDays(-82),
                    ContactPerson = "{\"Name\":\"Michael Davis\",\"Email\":\"michael.davis@example.com\",\"Phone\":\"0912345673\"}",
                    ParticipantPeople = "{\"Name\":\"Daniel Jackson\",\"Age\":29}",
                    IsDisplayed = true
                },
                new Order
                {
                    Id = 18,
                    UserId = 18,
                    TicketId = 18,
                    SeatNumber = "3排20號",
                    PaymentType = 0,
                    Status = 0,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now.AddDays(-90),
                    EditedAt = null,
                    ContactPerson = "{\"Name\":\"Daniel Taylor\",\"Email\":\"daniel.taylor@example.com\",\"Phone\":\"0987654323\"}",
                    ParticipantPeople = null,
                    IsDisplayed = false
                },
                new Order
                {
                    Id = 19,
                    UserId = 19,
                    TicketId = 19,
                    SeatNumber = "7排3號",
                    PaymentType = 1,
                    Status = 2,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now.AddDays(-95),
                    EditedAt = DateTime.Now.AddDays(-92),
                    ContactPerson = "{\"Name\":\"Olivia Anderson\",\"Email\":\"olivia.anderson@example.com\",\"Phone\":\"0923456783\"}",
                    ParticipantPeople = "{\"Name\":\"Emma Davis\",\"Age\":36}",
                    IsDisplayed = true
                },
                new Order
                {
                    Id = 20,
                    UserId = 20,
                    TicketId = 20,
                    SeatNumber = "4排8號",
                    PaymentType = 0,
                    Status = 3,
                    IsDeleted = true,
                    CreatedAt = DateTime.Now.AddDays(-100),
                    EditedAt = DateTime.Now.AddDays(-98),
                    ContactPerson = "{\"Name\":\"William Thomas\",\"Email\":\"william.thomas@example.com\",\"Phone\":\"0935678904\"}",
                    ParticipantPeople = null,
                    IsDisplayed = false
                }
            );
            modelBuilder.Entity<Ticket>().HasData(
                new Ticket
                {
                    OrderId = 1,
                    TicketTypeId = 1,
                    SeatId = 1,
                    Number = "A123456789",
                    Status = 0,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                    EditedAt = null
                },
                new Ticket
                {
                    OrderId = 2,
                    TicketTypeId = 2,
                    SeatId = null,
                    Number = "B987654321",
                    Status = 1,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now.AddDays(-1),
                    EditedAt = DateTime.Now
                },
                new Ticket
                {
                    OrderId = null,
                    TicketTypeId = 3,
                    SeatId = 3,
                    Number = "C123456789",
                    Status = 0,
                    IsDeleted = true,
                    CreatedAt = DateTime.Now.AddDays(-2),
                    EditedAt = null
                },
                new Ticket
                {
                    OrderId = 1,
                    TicketTypeId = 1,
                    SeatId = 1,
                    Number = "A123456789",
                    Status = 0,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                    EditedAt = null
                },
                new Ticket
               {
                   OrderId = 2,
                   TicketTypeId = 2,
                   SeatId = null,
                   Number = "B987654321",
                   Status = 1,
                   IsDeleted = false,
                   CreatedAt = DateTime.Now.AddDays(-1),
                   EditedAt = DateTime.Now
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
            modelBuilder.Entity<SeatArea>().HasData(
               new SeatArea()
               {
                   Id = 6,
                   Name = "F區",
                   CreatedAt = DateTime.Now.AddDays(-15),
                   EditedAt = null,
                   IsDeleted = false
               },
              new SeatArea()
              {
                  Id = 7,
                  Name = "G區",
                  CreatedAt = DateTime.Now.AddDays(-14),
                  EditedAt = null,
                  IsDeleted = false
              },
                new SeatArea()
                {
                    Id = 8,
                    Name = "H區",
                    CreatedAt = DateTime.Now.AddDays(-13),
                    EditedAt = null,
                    IsDeleted = false
                },
               new SeatArea()
               {
                   Id = 9,
                   Name = "I區",
                   CreatedAt = DateTime.Now.AddDays(-12),
                   EditedAt = null,
                   IsDeleted = false
               },
               new SeatArea()
               {
                   Id = 10,
                   Name = "J區",
                   CreatedAt = DateTime.Now.AddDays(-11),
                   EditedAt = null,
                   IsDeleted = false
               }, new SeatArea()
               {
                   Id = 11,
                   Name = "K區",
                   CreatedAt = DateTime.Now.AddDays(-10),
                   EditedAt = null,
                   IsDeleted = false
               },
                new SeatArea()
                {
                    Id = 12,
                    Name = "L區",
                    CreatedAt = DateTime.Now.AddDays(-9),
                    EditedAt = null,
                    IsDeleted = false
                },
                new SeatArea()
                {
                    Id = 13,
                    Name = "M區",
                    CreatedAt = DateTime.Now.AddDays(-8),
                    EditedAt = null,
                    IsDeleted = false
                },
                new SeatArea()
                {
                    Id = 14,
                    Name = "N區",
                    CreatedAt = DateTime.Now.AddDays(-7),
                    EditedAt = null,
                    IsDeleted = false
                },
                new SeatArea()
                {
                    Id = 15,
                    Name = "O區",
                    CreatedAt = DateTime.Now.AddDays(-6),
                    EditedAt = null,
                    IsDeleted = false
                },
                new SeatArea()
                {
                    Id = 16,
                    Name = "P區",
                    CreatedAt = DateTime.Now.AddDays(-5),
                    EditedAt = null,
                    IsDeleted = false
                });
            modelBuilder.Entity<PreFill>().HasData(
                new PreFill()
                {
                    Id = 11,
                    UserId = 11,
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
                    Id = 12,
                    UserId = 12,
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
                    Id = 13,
                    UserId = 13,
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