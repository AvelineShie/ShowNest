namespace ShowNest.Web.ViewModels.General
{
    public class EventCardViewModel
    {
        public string EventId { get; set; }
        public string EventName { get; set; }
        public string EventImgUrl { get; set; }
        public string CategoryName { get; set; }
        public DateTime EventTime { get; set; }
        public string EventStatus { get; set; }
        public string EventStatusCssClass { get; set; }
    }
}
