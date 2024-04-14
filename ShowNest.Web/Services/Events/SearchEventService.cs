namespace ShowNest.Web.Services.Events
{
	// public class SearchEventService
	// {
	//     private readonly DatabaseContext _databaseContext;
	//     public SearchEventService(DatabaseContext databaseContext)
	//     {
	//         _databaseContext = databaseContext;
	//     }
	//     public List<string> SearchEventString(string inputstring)
	//     {
	//var results =_databaseContext.Events.Where(en=>en.Name.Contains(inputstring)).Select(n=>n.Name).ToList();
	//         return results;
	//     }
	// }
	public class SearchEventService
	{
		private readonly DatabaseContext _databaseContext;
		public SearchEventService(DatabaseContext databaseContext)
		{
			_databaseContext = databaseContext;
		}

		public List<string> SearchEventString(string inputstring, decimal minPrice, decimal maxPrice, DateTime startTime, DateTime? endTime)
    {
        var query = _databaseContext.Events
            .Include(o => o.Organization)
            .Include(ea => ea.EventAndTagMappings)
                .ThenInclude(ct => ct.CategoryTag)
            .Include(t => t.TicketTypes)
                .ThenInclude(t => t.Tickets)
                .ThenInclude(o => o.Order)
                .ThenInclude(u => u.User)
            .AsNoTracking();
        
        if (!string.IsNullOrEmpty(inputstring))
        {
            query = query.Where(en => en.Name.Contains(inputstring));
        }

			// Price range filters
		else if (minPrice == 0) // 免費
			{
				query = query.Where(e => e.TicketTypes.Any(t => t.Price == 0));
			}
			else if (maxPrice < 1000)
			{
				query = query.Where(e => e.TicketTypes.Any(t => t.Price > minPrice && t.Price < maxPrice));
			}
			else if (maxPrice < 2000)
			{
				query = query.Where(e => e.TicketTypes.Any(t => t.Price > minPrice && t.Price < maxPrice));
			}
			else if (maxPrice < 3000)
			{
				query = query.Where(e => e.TicketTypes.Any(t => t.Price > minPrice && t.Price < maxPrice));
			}
			else if (minPrice > 3000)
			{
				query = query.Where(e => e.TicketTypes.Any(t => t.Price > minPrice));
			}

			// Time range filters
			else if (endTime.HasValue)
		{
			if (startTime == DateTime.Today && endTime.Value == DateTime.Today)
			{
				query = query.Where(e => e.StartTime.Date == DateTime.Today && e.EndTime.HasValue && e.EndTime.Value.Date == DateTime.Today);
			}
			else if (startTime == DateTime.Today && endTime.Value <= DateTime.Today.AddDays(7))
			{
				query = query.Where(e => e.StartTime.Date == DateTime.Today && e.EndTime.HasValue && e.EndTime.Value.Date <= DateTime.Today.AddDays(7));
			}
			else if (startTime == DateTime.Today && endTime.Value <= DateTime.Today.AddMonths(1))
			{
				query = query.Where(e => e.StartTime.Date == DateTime.Today && e.EndTime.HasValue && e.EndTime.Value.Date <= DateTime.Today.AddMonths(1));
			}
			else if (startTime == DateTime.Today && endTime.Value <= DateTime.Today.AddMonths(2))
			{
				query = query.Where(e => e.StartTime.Date == DateTime.Today && e.EndTime.HasValue && e.EndTime.Value.Date <= DateTime.Today.AddMonths(2));
			}
		}
		else 
		{
			// Handle case when endTime is null (no end time specified)
			// Do nothing or apply a different logic based on your requirements
		}

			var results = query.Select(n => n.Id.ToString()).ToList();
			return results;
    
		}
	}

}
