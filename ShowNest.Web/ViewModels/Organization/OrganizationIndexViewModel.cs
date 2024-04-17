

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

public class EventDetail
{
    internal int Month;

    public int Id { get; set; }
    public string EventImage { get; set; }
    public string EventName { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    //以當天日期 去 判斷 近期舉辦活動 跟 曾經舉辦活動
    public string EventIntroduction { get; set; }
    public List<EventDetail> AllEvents { get; set; }
}
