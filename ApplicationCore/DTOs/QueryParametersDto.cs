namespace ShowNest.ApplicationCore.DTOs
{
	public class QueryParametersDto
	{
		public int Id { get; set; } // 可null

		public string inputstring { get; set; }

		public int MaxPrice { get; set; } = 0; // 預設值為0

		public int MinPrice { get; set; } = 0; // 預設值為0

		public DateTime? StartTime { get; set; } // 預設值為 DateTime.MinValue

		public DateTime? EndTime { get; set; } // 預設值為 DateTime.MaxValue

		public int CategoryTag { get; set; } = 0; // 預設值為0

        public int page { get; set; }

        public int cardsPerPage { get; set; }
    }
}
