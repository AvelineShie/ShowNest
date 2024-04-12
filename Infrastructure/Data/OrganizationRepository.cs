using ApplicationCore.DTOs;
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

        public Organization CreateOrganization(CreateOrganizationDto request)
        {
            using (var transcation = DbContext.Database.BeginTransaction())
                try
                {

                    var organization = new Organization
                    {
                        OwnerId = request.OwnerId,
                        Name = request.Name,
                        OrganizationUrl = request.OrganizationUrl,
                        Description = request.Description,
                        Fblink = request.FBLink,
                        Igaccount = request.IGAccount,
                        Email = request.Email,
                        ImgUrl = request.ImgUrl,
                        ContactName = request.ContactName,
                        ContactMobile = request.ContactMobile,
                        ContactTelephone = request.ContactTelephone,
                        IsDeleted = false,
                        CreatedAt = request.CreatedAt,
                        EditedAt = request.EditedAt,
                    };

                    DbContext.Organizations.Add(organization);
                    DbContext.SaveChanges();

                    var orgAndUserMapping = new OrganizationAndUserMapping
                    {
                        OrganizationId = organization.Id,
                        UserId = organization.OwnerId
                    };

                    DbContext.OrganizationAndUserMappings.Add(orgAndUserMapping);
                    DbContext.SaveChanges();

                    transcation.Commit();

                    return organization;

                }
                catch (Exception ex)
                {
                    transcation.Rollback();
                    throw new Exception(ex.Message);
                }
        }
    }
}
