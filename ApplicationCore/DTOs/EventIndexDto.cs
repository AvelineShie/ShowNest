using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DTOs
{
    public class EventIndexDto
    {
            public string EventId { get; set; }
            public string EventName { get; set; }
            public string EventImgUrl { get; set; }
            public string CategoryName { get; set; }
            public DateTime EventTime { get; set; }
    }
}
