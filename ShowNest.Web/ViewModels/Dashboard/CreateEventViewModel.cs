using static ShowNest.Web.ViewModels.Dashboard.OrgNameList;

namespace ShowNest.Web.ViewModels.Dashboard
{

    public class CreateEventViewModel
    {
        public List<OrgNameList> Organizations { get; set; } 
        public List<CategoryTagsViewModel> EventCategoryTags { get; set; }
        public List<EventNameList> Events { get; set; }
    }

    public class OrgNameList
    {
        public int OrgId { get; set; }
        public string OrgName { get; set; }

        public class EventNameList
        {
            public int EventId { get; set; }
            public string EventName { get; set; }
        }

    }



}



