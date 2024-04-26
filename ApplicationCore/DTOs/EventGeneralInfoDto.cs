using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DTOs
{
    public class EventGeneralInfoDto
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string EventStartTime { get; set; }
        public string EventEndTime { get; set; }
        public string Organizer {  get; set; }
        public string CoOrganizer { get; set; }
        public int Capacity { get; set; }
        public string EventType { get; set; }
        public string EventBrief { get; set; }
        public string EventDescription { get; set; }
        public string EventImg {  get; set; }
        public string IsPrivate { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string EventLocationName { get; set; }
        public string EventLocationAddress { get; set;}
    }
}
