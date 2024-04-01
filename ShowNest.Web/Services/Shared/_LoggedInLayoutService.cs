using ApplicationCore.Entities;
using ShowNest.Web.ViewModels.Shared;
using System.Security.Claims;

namespace ShowNest.Web.Services.Shared
{
    public class _LoggedInLayoutService
    {
        private readonly DatabaseContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public _LoggedInLayoutService(DatabaseContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public HeaderNavInfoViewModel GetHeaderViewInfo()
        {
            
            var userIdFromClaim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var info = _context.Users
                .Include(u => u.OrganizationAndUserMappings)
                .ThenInclude(ou => ou.Organization)
                .FirstOrDefault(x => x.Id == int.Parse(userIdFromClaim));

            var result = new HeaderNavInfoViewModel();

            result.UserName = info.Nickname;
            result.UserOrg = new List<UserOrgInfo>();
            foreach(var org in info.Organizations)
            {
                var orgToAdd = new UserOrgInfo
                {
                    UserOrgName = org.Name,
                    UserOrgUrl = $"{org.Name}URL"
                };
                result.UserOrg.Add(orgToAdd);
            }
            result.UserImgUrl = "https://picsum.photos/300/200/?random=10";

            return result;
        }
    }
}

