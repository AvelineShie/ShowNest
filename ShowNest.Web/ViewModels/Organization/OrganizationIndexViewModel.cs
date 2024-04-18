

namespace ShowNest.Web.ViewModels.Organization;

public class OrganizationIndexViewModel
{
    public int OrganizationId { get; set; }
    public string OrganizationName { get; set; }
    public string OrganizationImgUrl { get; set; }
    public string OrganizationDescription { get; set; }
    public string OrganizationWeb { get; set; }
    public string OrganizationFBLink { get; set; }
    public string OrganizationEmail { get; set; }

    public List<EventDetail> GroupedCurrentEvents { get; set; }
    public List<EventDetail> GroupedPastEvents { get; set; }
    

}
//public class GroupedEventsByMonthViewModel
//{
//    public int Year { get; set; }
//    public int Month { get; set; }
//    public List<EventDetail> Events { get; set; }

//}

public class EventDetail
{
    public int Year { get; set; }
    public int Month { get; set; }
    public int Id { get; set; }
    public string EventImage { get; set; }
    public string EventName { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public string EventIntroduction { get; set; }
   

}
