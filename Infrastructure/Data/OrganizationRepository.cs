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

        public int CreateOrganization(CreateOrganizationDto request)
        {
            using (var transcation = DbContext.Database.BeginTransaction())
                try
                {
                    var organization = new Organization
                    {
                        OwnerId = request.OwnerId,
                        Name = request.Name,
                        OrganizationUrl = request.OrganizationUrl,
                        OuterUrl = request.OuterUrl,
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

                    return organization.Id;

                }
                catch (Exception ex)
                {
                    transcation.Rollback();
                    throw new Exception(ex.Message);
                }
        }

        public int UpdateOrganization(CreateOrganizationDto request)
        {
            using (var transcation = DbContext.Database.BeginTransaction())
                try
                {
                    var targetOrganization = DbContext.Organizations
                        .FirstOrDefault(o => o.Id == request.OrgId);

                    // 更新ownerId會有PK、FK配對的錯誤，先註解掉
                    // targetOrganization.OwnerId = request.OwnerId;
                    targetOrganization.Name = request.Name;
                    targetOrganization.OrganizationUrl = request.OrganizationUrl;
                    targetOrganization.OuterUrl = request.OuterUrl;
                    targetOrganization.Description = request.Description;
                    targetOrganization.Fblink = request.FBLink;
                    targetOrganization.Igaccount = request.IGAccount;
                    targetOrganization.Email = request.Email;
                    targetOrganization.ImgUrl = request.ImgUrl;
                    targetOrganization.ContactName = request.ContactName;
                    targetOrganization.ContactMobile = request.ContactMobile;
                    targetOrganization.ContactTelephone = request.ContactTelephone;
                    targetOrganization.EditedAt = DateTime.Now;

                    DbContext.SaveChanges();
                    transcation.Commit();

                    return targetOrganization.Id;
                }
                catch (Exception ex)
                {
                    transcation.Rollback();
                    throw new Exception(ex.Message);
                }
        }

        public CreateOrganizationDto EditOrganizationDataFilling(int orgid)
        {
            var organization = GetById(orgid);
            var result = new CreateOrganizationDto
            {
                OrgId = organization.Id,
                OwnerId = organization.OwnerId,
                Name = organization.Name,
                OrganizationUrl = organization.OrganizationUrl,
                OuterUrl = organization.OuterUrl,
                Description = organization.Description,
                FBLink = organization.Fblink,
                IGAccount = organization.Igaccount,
                Email = organization.Email,
                ImgUrl = organization.ImgUrl,
                ContactName = organization.ContactName,
                ContactMobile = organization.ContactMobile,
                ContactTelephone = organization.ContactTelephone,
            };

            return result;
        }
    }
}
