using Infrastructure.Data;
using ShowNest.Web.Services.Organizations;
using ShowNest.Web.ViewModels.Organization;
using static ShowNest.Web.ViewModels.Organization.OrganizationIndexViewModel;

namespace ShowNest.Web.Services.Organization
{
    public class OrganizationIndexService
    {
        private readonly DatabaseContext _databaseContext;

        public OrganizationIndexService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public OrganizationIndexViewModel GetOrganizationDetails(int organizationId)
        {
            var organization = _databaseContext.Organizations
                        .Include(o => o.Events).AsNoTracking()
                        .FirstOrDefault(o => o.Id == organizationId);

            if (organization == null)
            {
                return null;
            }
            var currentDate = DateTime.Now;



            // 從符合organizationId的活動事件中 取得所有現正進行中的活動事件
            var currentEvents = organization.Events
                .Where(e => e.EndTime >= currentDate)
                .OrderBy(e => e.StartTime)
                .ToList();
            //string json = JsonConvert.SerializeObject(currentEvents, Formatting.Indented);
            //Console.WriteLine(json);


            var groupedPastEvents = organization.Events
                    .Where(e => e.EndTime < currentDate)
                    .OrderBy(e => e.StartTime)
                    .GroupBy(e => e.StartTime.Year)
                    .Select(group => group.Select(e => new EventDetail
                    {
                        Year = e.StartTime.Year,
                        Month = e.StartTime.Month,
                        Id = e.Id,
                        EventName = e.Name,
                        StartTime = e.StartTime,
                    }))
                    .ToList();



            var result = new OrganizationIndexViewModel
            {
                OrganizationId = organization.Id,
                OrganizationName = organization.Name,
                OrganizationImgUrl = organization.ImgUrl,
                OrganizationDescription = organization.Description,
                OrganizationWeb = organization.OrganizationUrl,
                OrganizationFBLink = organization.Fblink,
                OrganizationEmail = organization.Email,
                GroupedCurrentEvents = currentEvents
                .Select(e => new EventDetail
                {
                    Id = e.Id,
                    EventImage = e.EventImage,
                    EventName = e.Name,
                    StartTime = e.StartTime,
                    EventIntroduction = e.Introduction,
                })
                .ToList(),
                GroupedPastEvents = groupedPastEvents.SelectMany(x => x).ToList(),
            };
            return result;
       
        }
    }
}
