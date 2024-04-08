namespace ShowNest.Web.Services.Events
{
    public class SearchEventService
    {
        private readonly DatabaseContext _databaseContext;
        public SearchEventService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public List<string> SearchEventString(string inputstring)
        {
			var results =_databaseContext.Events.Where(en=>en.Name.Contains(inputstring)).Select(n=>n.Name).ToList();
            return results;
        }
    }
}
