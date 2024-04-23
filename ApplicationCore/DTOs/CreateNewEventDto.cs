using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DTOs
{
    public class CreateNewEventDto
    {
        public string EventName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string MainCompany { get; set; }
        public string AssistCompany { get; set; }
        public int Amount { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Intro { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public string Privacy { get; set; }
        public List<string> CategoryNames { get; set; }
    }
}

