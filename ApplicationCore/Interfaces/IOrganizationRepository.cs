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
        int CreateOrganization(CreateOrganizationDto request);
        int UpdateOrganization(CreateOrganizationDto request);
        CreateOrganizationDto EditOrganizationDataFilling(int orgid);
    }
}
