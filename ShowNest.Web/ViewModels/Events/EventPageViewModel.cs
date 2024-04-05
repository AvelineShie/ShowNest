
namespace ShowNest.Web.ViewModels.Events
{
    public class EventPageViewModel
    {
        public int EventId { get; set; } //整個Event的ID
        public string MainImage { get; set; }
        public string EventName { get; set; }
        public DateTime EventTime { get; set; }
        public string EventLocationName { get; set; }
        public string EventDescription { get; set; } // 與 CKEditor 綁定的屬性

        public string EventLocationAddress { get; set; } // 活動地址
        public string Longitude {  get; set; }//經度<地圖>
        public string Latitude { get; set; }//緯度<地圖>

        public int EventRegistered { get; set; } // 參與人數，從Ticket table 
        public int EventCapacity { get; set; } // 活動人數
        public string OrganizationName { get; set; }
        public int OrganizationId { get; set; }

        public List<EventTicketType> EventTicketTypes { get; set; }
        public List<ParticipantPeople> AllParticipantPeoples { get; set; }//抓UserID、Image
        public List<CategoryTags> EventCategoryTags { get; set; }
    }

    public class EventTicketType
    {
        
        public string TicketTypeName { get; set; }
        public decimal TicketPrice { get; set; }

        public DateTime TicketSalseBegin { get; set; }
        public DateTime TicketSalseEnd { get; set; }
    }
    public class ParticipantPeople
    {
        public string UserImage { get; set; }
        public string UserNickname { get; set; }
       

    }
    public class CategoryTags
    {
        public string Name { get; set; }
    }
}