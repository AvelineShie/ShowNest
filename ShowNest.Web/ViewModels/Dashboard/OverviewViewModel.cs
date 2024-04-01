﻿namespace ShowNest.Web.ViewModels.Dashboard
{
    public class OverviewViewModel
    {
        public int OrgId { get; set; }
        public string OrgName { get; set; }
        public string OrgWebUrl { get; set; }
        public string OrgDescription { get; set; }
        public string OrgFbUrl { get; set; }
        public string OrgIgUrl { get; set; }
        public string OrgEmail { get; set; }
        public string OrgContactName { get; set; }
        public string OrgContactCellphone { get; set; }
        public string OrgContactTelepohone { get; set; }
        public List<EventsForOverview> OrgEvents { get; set; }

    }

    public class EventsForOverview
    {
        public int OrgEventId { get; set; }
        public string OrgEventName { get; set; }
        public DateTime OrgEventStartTime { get; set; }
        public string OrgEventStatus { get; set; }
        public bool isOnGoing { get; set; }
    }
}
