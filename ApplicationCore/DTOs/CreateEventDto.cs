using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DTOs
{   
    //最終四頁傳出的物件需要什麼?
    internal class CreateEventDto
    {
        //CreateEvent
        public int OwnerId { get; set; }
        public int OrgId { get; set; }
        public string OrgName { get; set; }
        public int EventId { get; set; }
        public string EventName { get; set; }

        //SetEvent
        public string WebsiteLink { get; set; } 
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string MainOrganizer { get; set; }
        public string CoOrganizer { get; set; }
        public int Attendance { get; set; } //活動人數
        public int EventStatus { get; set; }
        public string StreamingName { get; set; }
        public string LocationName { get; set; }
        public string EventAddress { get; set; } 
        public string EventIntroduction { get; set; }
        public string EventDescription { get; set; }
        public string EventImage { get; set; } 
        public bool IsPrivateEvent { get; set; }

        //SetTicket
        public int TicketTypeId { get; set; }
        public string TicketName { get; set; }
        public string TicketType { get; set; }
        public DateTime StartSaleTime {  get; set; }
        public DateTime EndSaleTime { get; set;}
        public int Prince {  get; set; }
        public int Amount {  get; set; }

        //SetTable
        //表單不用進資料庫


    }
}
