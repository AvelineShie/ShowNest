using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ShowNest.Web.ViewModels.Events
{
    public class QueryParameters
    {
        public int Id { get; set; }//可null

        public string Name { get; set; }

        public int MaxPrice { get; set; }

        public int MinPrice { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int CategoryTag { get; set;}

    }
}
