
namespace ShowNest.Web.ViewModels.Events
{
    public class EventPageViewModel
    {
        //public int EventId { get; set; } //整個Event的ID
        public string MainImage { get; set; }
        public string EventName { get; set; }
        public DateTime EventTime { get; set; }
        public string EventLocationName { get; set; }
        public string EventDescription { get; set; } // 與 CKEditor 綁定的屬性
        public string EventLocationAddress { get; set; } // 活動地址
        public string EventRegistered { get; set; } // 參與人數
        public string EventCapacity { get; set; } // 活動人數
        public string OrganizationName { get; set; }

        public List<EventTicket> AllTickets { get; set; }
        public List<ParticipantPeople> AllParticipantPeoples { get; set; }
        public List<CategoryTagsViewModel> EventCategoryTags { get; set; }
    }

    public class EventTicket
    {
        public string TicketTypeName { get; set; }
        public decimal TicketPrice { get; set; }

        public DateTime TicketSalseBegin { get; set; }
        public DateTime TicketSalseEnd { get; set; }
    }
    public class ParticipantPeople
    {
        public string ParticipantPeopleImage { get; set; }
        public string ParticipantPeopleId { get; set; }

    }
}