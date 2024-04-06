﻿using Microsoft.AspNetCore.Mvc.Rendering;
using ShowNest.Web.ViewModels.Events;
using ShowNest.Web.ViewModels.UserAccount;

namespace ShowNest.Web.ViewModels.Dashboard
{
    
    public class CreateEventViewModel
    {
        public List<OrgNameList> OrgNames { get; set; } //Owner's OrgId
        
    }

    public class OrgNameList
    {
        public int OrgId {get; set;}
        public string OrgName { get; set; }
        //public List<EventNameList> EventNames { get; set; } //Each Event in Each Org 
    }

    public class EventNameList
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
    }
}



