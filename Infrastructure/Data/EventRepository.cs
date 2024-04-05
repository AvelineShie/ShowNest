using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Infrastructure.Data
{
    internal class EventRepository : EfRepository<Organization>, IEventRepository
    {
        public EventRepository(DbContext dbContext) : base(dbContext)
        {
        }

        //取相同OwnerId下的全部組織
        public IEnumerable<Organization> GetOrgIdByOwnerId(int OwnerId)
        {
            var Organizations = DbContext.Organizations
                        .Where(e => e.OwnerId == OwnerId)
                        .ToList();
            return Organizations;
        }

        //取出所有相同OrgId的Event
        public IEnumerable<Event> GetEventIdByOrgId(int OrgId)
        {
            var events = DbContext.Events
                        .Where(e => e.OrganizationId == OrgId)
                        .ToList();

            return events;
        }

    }
}
