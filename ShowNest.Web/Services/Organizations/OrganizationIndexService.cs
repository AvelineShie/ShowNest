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

            //// 從符合organizationId的活動事件中 取得結束的活動事件
            //var pastEvents = organization.Events
            //    .Where(e => e.EndTime < currentDate)
            //    .OrderBy(e => e.StartTime)
            //    .GroupBy(e => e.StartTime.Month)
            //    .ToList();

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



            //// 將已經結束的事件按照開始時間的月份分組
            //var pastGroupedEvents = pastEvents
            //.GroupBy(e => new { e.StartTime.Year, e.StartTime.Month })
            //.Select(g => new { Year = g.Key.Year, Month = g.Key.Month, Events = g.ToList() })
            //.ToList();

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
