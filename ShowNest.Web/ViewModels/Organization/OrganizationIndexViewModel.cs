namespace ShowNest.Web.ViewModels.Organization
{
    public class OrganizationIndexViewModel
    {
        //public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationImage { get; set; }
        public string OrganizationDescription { get; set; }
        public string OrganizationWeb { get; set; }
        public string OrganizationFBLink { get; set; }
        public string OrganizationEmail { get; set; }

        public List<EventDetail> CurrentEvents { get; set; }
    }
    public class EventDetail
    {
        public string MainImage { get; set; }
        public string EventName { get; set; }
        public string EventPageWeb { get; set; }
        public DateTime EventTime { get; set; }
        //以活動狀態 去 判斷 近期舉辦活動 跟 曾經舉辦活動
        public string EventBrief { get; set; }
    }
}
