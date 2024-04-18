using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShowNest.Web.WebAPI
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EditOrganizationController : ControllerBase
    {
        private readonly IOrganizationRepository _organizationRepository;

        public EditOrganizationController(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
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
