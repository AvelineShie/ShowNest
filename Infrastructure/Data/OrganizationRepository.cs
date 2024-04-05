using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class OrganizationRepository : EfRepository<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(DatabaseContext context) : base(context)
        {
        }

        public Organization GetOrgById(int orgId)
        {
            var organization = DbContext.Organizations
                .FirstOrDefault(o => o.Id == orgId);

            return organization;
        }

        public IEnumerable<Event> GetOrgEventsByOrgId(int orgId)
        {
            var events = DbContext.Events
                .Include(e => e.Organization)
                .Where(e => e.OrganizationId == orgId);

            return events;
        }
    }
}
