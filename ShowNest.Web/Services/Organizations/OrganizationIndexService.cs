using Infrastructure.Data;
using ShowNest.Web.Services.Organizations;
using ShowNest.Web.ViewModels.Organization;

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
                                .Include(o => o.Events)
                                .FirstOrDefault(o => o.Id == organizationId);

            if (organization == null)
            {
                return null;
            }
            var currentDate = DateTime.Now.Date;

            // 先將事件按照開始時間排序
            var sortedEvents = organization.Events.OrderBy(e => e.StartTime);

            // 將事件按照開始時間的月份分組
            var groupedEvents = sortedEvents
                .GroupBy(e => e.StartTime.Month)
                .Select(g => new { Month = g.Key, Events = g.ToList() })
                .ToList();

            var currentEvents = groupedEvents.FirstOrDefault(g => g.Month == currentDate.Month)?.Events
                .Select(e => new EventDetail
                {
                    Id = e.Id,
                    EventImage = e.EventImage,
                    EventName = e.Name,
                    StartTime = e.StartTime,
                    EventIntroduction = e.Introduction,
                }).ToList();

            // 將過去的事件按照月份分類
            var pastEventsGroupedByMonth = groupedEvents
                .Where(g => g.Month < currentDate.Month)
                .Select(g => new {
                    g.Month,
                    Events = g.Events.Select(e => new EventDetail
                    {
                Id = e.Id,
                EventImage = e.EventImage,
                EventName = e.Name,
                StartTime = e.StartTime,
                EventIntroduction = e.Introduction,
            }).ToList()
        })
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
                CurrentEvents = currentEvents,
                GroupedPastEvents = pastEventsGroupedByMonth.Select(g => new EventDetail
                {
                    Month = g.Month
                   
                }).ToList()
            };

            return result;
        }

    }
}
