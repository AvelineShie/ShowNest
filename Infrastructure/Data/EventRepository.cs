using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Infrastructure.Data
{
    public class EventRepository : EfRepository<Organization>, IEventRepository
    {

        public EventRepository(DatabaseContext context) : base(context)
        {
        }

        //取相同OwnerId下的全部組織
        public IEnumerable<Organization> GetOrgsByOwnerId(int OwnerId)
        {
            var Organizations = DbContext.Organizations
                        .Where(e => e.OwnerId == OwnerId)
                        .AsNoTracking()
                        .ToList();
            return Organizations;
        }

        //取出所有相同OrgId的Event
        public IEnumerable<Event> GetEventsByOrgId(int OrgId)
        {
            var events = DbContext.Events
                        .Where(e => e.OrganizationId == OrgId)
                        .AsQueryable()
                        .ToList();

            return events;
        }

    }
}
