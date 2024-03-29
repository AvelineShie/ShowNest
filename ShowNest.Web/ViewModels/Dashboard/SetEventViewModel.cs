using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Identity.Client;
using ShowNest.Web.ViewModels.Events;
using System.ComponentModel;

namespace ShowNest.Web.ViewModels.Dashboard
{
    public class SetEventViewModel
    {
        //照mobile RWD順序
        public string OrganizationName { get; set; } //組織名
        public string MainImageURL { get; set; } //圖片

        [Required(ErrorMessage = "請輸入活動名稱")]
        [StringLength(100)]
        public string EventName { get; set; }
        
        public bool IsPrivateEvent { get; set; } //隱私狀態
        public int EventType { get; set; }//活動分類

        [Required]
        [StringLength(16)]
        //還需要組合url
        public string WebsiteLink { get; set; } //網址

        [Required]
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        
        [Required(ErrorMessage = "請輸入主辦單位名稱")]
        public string MainOrganizer { get; set; }
        public string CoOrganizer { get; set; }

        public int Attendance { get; set; } //活動人數

        public int EventStatus {  get; set; }//活動形式
        public string StreamingName { get; set; }//串流平台名稱

        [Required(ErrorMessage = "請輸入活動場所名稱")]
        [StringLength(100)]
        public string LocationName { get; set; }//場所名稱
        [Required(ErrorMessage = "請輸入活動地址")]
        [StringLength(200)]
        public string EventAddress { get; set; } //活動地址
        
        public string EventIntroduction {  get; set; }//活動簡介
        public string EventDescription {  get; set; }//活動描述

    }
}
