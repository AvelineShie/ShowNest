//using ApplicationCore.Entities;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Infrastructure.Data
//{
//    public partial class DatabaseContext
//    {
//        private void FakeDataInjection(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<User>().HasData(
//                new User
//                {
//                    Id = 1,
//                    Birthday = new DateTime(1985, 4, 12), // Example of a generated date
//                    Nickname = "JohnDoe123",
//                    Mobile = "0912345678",
//                    Gender = 1, // 0 for female, 1 for male (adjust as needed)
//                    PersonalUrl = "https://example.com/johndoe",
//                    PersonalProfile = "Hello, I'm John Doe! I'm a software developer who enjoys building cool things.",
//                    EdmSubscription = true,
//                    Image = "https://example.com/profilepics/johndoe.jpg",
//                    LastLogInAt = new DateTime(2024, 3, 15, 14, 15, 0), // Example of a generated recent login time
//                    Status = 1, // Set to 1 for verified email
//                    CreatedAt = new DateTime(2024, 2, 25), // Example of a generated creation date
//                    EditedAt = new DateTime(2024, 2, 25) // Example of a generated creation date

//                }
//            );
//        }
//    }
//}
