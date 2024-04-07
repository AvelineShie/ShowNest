namespace ShowNest.Web.ViewModels.EventsApiDtos;

public class GetOrganizationResponse
{
    public List<Organization> Organizations { get; set; }
}

public class Organization
{
    public int Id { get; set; }
    public string Name { get; set; }
}