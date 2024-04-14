using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ShowNest.Web.ViewModels.Events
{
	public class QueryParametersViewModel
	{
		public int Id { get; set; } // 可null

		public string inputstring { get; set; }

		public int MaxPrice { get; set; } = 0; // 預設值為0

		public int MinPrice { get; set; } = 0; // 預設值為0

		public DateTime StartTime { get; set; } = DateTime.MinValue; // 預設值為 DateTime.MinValue

		public DateTime EndTime { get; set; } = DateTime.MaxValue; // 預設值為 DateTime.MaxValue

		public int CategoryTag { get; set; } = 0; // 預設值為0
	}
}
