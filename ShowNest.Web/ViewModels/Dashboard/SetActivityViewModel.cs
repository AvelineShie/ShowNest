using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Identity.Client;
using ShowNest.Web.ViewModels.Events;
using System.ComponentModel;

namespace ShowNest.Web.ViewModels.Dashboard
{
    public class SetActivityViewModel
    {
        //照mobile RWD順序
        public string OrganizationName { get; set; }
        public string MainImage { get; set; }
        public string EventName { get; set; }
        public bool PrivacyStatus { get; set; } //隱私狀態
        public int EventType { get; set; }//活動分類
        public string WebsiteLink { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public int Attendance { get; set; } //活動人數
        public int EventStatus {  get; set; }//活動形式
        public string StreamingName { get; set; }//串流平台名稱
        public string LocationName { get; set; }//場所名稱
        public string EventAddress { get; set; } //活動地址
        public string EventIntroduction {  get; set; }//活動簡介

        public string EventDescription {  get; set; }//活動描述

    }
}
