namespace ShowNest.Web.Services.Events;

public class EventsApiService
{
    private readonly DatabaseContext _context;

    public EventsApiService(DatabaseContext context)
    {
        _context = context;
    }

    public List<ApplicationCore.Entities.Organization> GetOrganizationsById(int userId)
    {
        var organizations = _context.Organizations
            .Where(x => x.OwnerId == userId)
            .AsNoTracking()
            .ToList();
        return organizations;
    }
}