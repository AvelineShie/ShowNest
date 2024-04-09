using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ApplicationCore.DTOs
{
    public class EventIndexDto
    {
        public string EventId { get; set; }
        public string EventName { get; set; }
        public string EventImgUrl { get; set; }
        public string CategoryName { get; set; }
        public DateTime EventTime { get; set; }
        public string EventStatus { get; set; }
        public string EventStatusCssClass { get; set; }
        public int TotalPages { get; set; }
    }
}
