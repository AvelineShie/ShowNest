using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DTOs
{   
    //最終傳至DB的物件需要什麼?
    public class CreateEventDto
    {
        //CreateEvent
        //public int OwnerId { get; set; }
        public int OrgId { get; set; }
        public string OrgName { get; set; }
        public int EventId { get; set; }
        public string EventName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string MainOrganizer { get; set; }
        public string CoOrganizer { get; set; }
        public int Attendance { get; set; }
        public byte EventStatus { get; set; }

        public string StreamingName { get; set; }
        public string StreamingUrl { get; set; }
        public string LocationName { get; set; }
        public string EventAddress { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }

        public string EventIntroduction { get; set; }
        public string EventDescription { get; set; }
        public string EventImage { get; set; }
        public bool IsPrivateEvent { get; set; }
        public List<string> CategoryNames { get; set; }
        public int CategoryId { get; set; }

        //public string ContactPerson { get; set; }
        //public string ParticipantPeople { get; set; }
        //public bool IsFree {  get; set; }  


        //public int Sort {  get; set; }
        //public bool? IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? EditedAt { get; set; }

        //SetTicket
        //票可能會有好幾張不同的資料
        public List<TicketDetailViewModel> TicketDetail { get; set; }
        public class TicketDetailViewModel
        {
            public int TicketTypeId { get; set; }
            public int EventId { get; set; }
            public string TicketName { get; set; }//票種名稱
            //public string TicketType { get; set; }
            public DateTime StartSaleTime { get; set; }
            public DateTime EndSaleTime { get; set; }
            public int Price { get; set; }
            public int? Amount { get; set; } //數量
            public DateTime CreatedAt { get; set; }
            public DateTime? EditedAt { get; set; }

        }

        //public List<TicketSeatArea> TicketSeatAreas { get; set; }
        //public class TicketSeatArea
        //{
        //    //票區
        //    public int SeatAreaId { get; set; }
        //}

    }

    
}
