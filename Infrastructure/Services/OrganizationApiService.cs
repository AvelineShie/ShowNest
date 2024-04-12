using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class OrganizationApiService
    {
        private readonly DatabaseContext _databaseContext;
        private readonly OrganizationRepository _organizationRepository;
        public OrganizationApiService(DatabaseContext databaseContext, OrganizationRepository organizationRepository)
        {
            _databaseContext = databaseContext;
            _organizationRepository = organizationRepository;
        }

        public Organization CreateOrganization(CreateOrganizationDto request)
        {
            using (var transcation = _databaseContext.Database.BeginTransaction())
                try
                {

                    var organization = new Organization()
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

                    _databaseContext.Organizations.Add(organization);
                    _databaseContext.SaveChanges();
                    transcation.Commit();

                    return organization;

                }catch (Exception ex)
                {
                    transcation.Rollback();
                    throw new Exception(ex.Message);
                }
        }
    }
}
