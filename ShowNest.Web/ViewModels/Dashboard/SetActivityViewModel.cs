using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Identity.Client;
using ShowNest.Web.ViewModels.Events;
using System.ComponentModel;

namespace ShowNest.Web.ViewModels.Dashboard
{
    public class SetActivityViewModel
    {
        public EventDetailViewModel EventId { get; set; }
        public EventDetailViewModel MainImage { get; set; }
        public EventDetailViewModel EventName { get; set;}
        public bool PrivacyStatus { get; set; }
        public string EventHttp {  get; set; }
        public EventDetailViewModel StartTime { get; set; }
        public DateTime EndTime { get; set; }
        
        public EventDetailViewModel EventAttendance { get; set; } //活動人數

        public int LocationId { get; set; }//場所id
        public string LocationName { get; set; }//場所名稱
        public EventDetailViewModel EventAddress { get; set; } //活動地址
        public string EventIntroduction {  get; set; }//活動簡介

        public string EventDescription {  get; set; }//活動描述

    }
}
