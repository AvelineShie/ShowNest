using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ShowNest.Web.WebAPI
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CreateAndUpdateOrganizationController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IOrganizationRepository _organizationRepository;
        public CreateAndUpdateOrganizationController(IHttpContextAccessor httpContextAccessor, IOrganizationRepository organizationRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _organizationRepository = organizationRepository;
        }

        [HttpPost]
        public IActionResult CreateAndUpdateOrganization([FromBody] CreateOrganizationDto request)
        {
            try
            {
                // 新增組織的情況
                int organizationResultId;
                if (request.OrgId == 0)
                {
                    var userIdFromClaim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                    request.OwnerId = int.Parse(userIdFromClaim.Value);
                    request.CreatedAt = DateTime.Now;
                    organizationResultId = _organizationRepository.CreateOrganization(request);
                }
                // 修改組織的情況
                else
                {
                    organizationResultId = _organizationRepository.UpdateOrganization(request);
                }
                var successResult = OperationResultHelper.ReturnSuccessData(organizationResultId);
                return Ok(successResult);
            }
            catch (Exception ex)
            {
                var errorResult = OperationResultHelper.ReturnErrorMsg(ex.Message);
                return BadRequest(errorResult);
            }
        }

        [Route("{orgid}")]
        public IActionResult EditOrganizationDataFilling(string orgid)
        {
            try
            {
                var organizationResult = _organizationRepository.EditOrganizationDataFilling(int.Parse(orgid));
                var successResult = OperationResultHelper.ReturnSuccessData(organizationResult);
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
