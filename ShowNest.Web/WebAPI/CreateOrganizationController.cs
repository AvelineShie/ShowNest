using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ShowNest.Web.WebAPI
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CreateOrganizationController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IOrganizationRepository _organizationRepository;
        public CreateOrganizationController(IHttpContextAccessor httpContextAccessor, IOrganizationRepository organizationRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _organizationRepository = organizationRepository;
        }

        [HttpPost]
        public IActionResult CreateOrganization([FromBody] CreateOrganizationDto request)
        {
            var userIdFromClaim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            request.OwnerId = int.Parse(userIdFromClaim.Value);
            request.CreatedAt = DateTime.Now;
            try
            {
                var organizationResult = _organizationRepository.CreateOrganization(request);
                var successResult = OperationResultHelper.ReturnSuccessData(organizationResult.Id);
                return Ok(successResult);
            }
            catch (Exception ex)
            {
                var errorResult = OperationResultHelper.ReturnErrorMsg(ex.Message);
                return BadRequest(errorResult);
            }
        }
    }
}
