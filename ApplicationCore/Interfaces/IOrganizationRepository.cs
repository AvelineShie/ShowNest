using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IOrganizationRepository : IRepository<Organization>
    {
        Organization GetOrgById(int orgId);
        IEnumerable<Event> GetOrgEventsByOrgId(int orgId);
        Organization CreateOrganization(CreateOrganizationDto request);
    }
}
