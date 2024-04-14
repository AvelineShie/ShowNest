using ShowNest.Web.Models.Attributes;
using System;
using System.Collections.Generic;

namespace ShowNest.Web.ViewModels.UserAccount

{
    public class UserAccountViewModel
    {
        public UserAccountViewModel()
        {
            // 初始化SelectedAreas為一個空列表
            SelectedAreas = new List<int>();
        }

        public int Id { get; set; }
        [AccountRegex]
        public string Account { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public DateTime Birthday { get; set; }
        public int? Gender { get; set; } // 使用Nullable<int>來表示可以為null的欄位
        public string PersonalURL { get; set; }
        public string PersonalProfile { get; set; }
        public bool EdmSubscription { get; set; }
        public string Image { get; set; }
        public DateTime? LastLogInAt { get; set; } // 使用Nullable<DateTime>來表示可以為null的欄位
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? EditedAt { get; set; } // 使用Nullable<DateTime>來表示可以為null的欄位

        public List<int> SelectedAreas { get; set; }
    }
    public enum Gender
    {
        男 = 0,
        女 = 1,
        Other = 2
    };

    public enum ActivityRegion
    {
        Region1 = 0,
        Region2 = 1,
        Region3 = 2
    }
    public class ThirdPartyLink
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public string Scope { get; set; }
        public string Redirect_uri_encode { get; set; }
        public string State { get; set; }
    }
    public class PreferredActivityAreas
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AreaId { get; set; }
    }
    public class Area
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
