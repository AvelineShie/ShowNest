using Microsoft.AspNetCore.Mvc;
using ShowNest.Web.Services.Events;
using ShowNest.Web.Services.Organization;

namespace ShowNest.Web.Controllers
{
    public class OrganizationsController : Controller
    {
        private readonly OrganizationService _organizationService;

        public OrganizationsController(OrganizationService organizationService)
        {
            _organizationService = organizationService;
        }
        public IActionResult Index(int organizationId)
        {
            var groupedEvents = _organizationService.GetGroupedEvents();

            
            

            return View();
        }
        public IActionResult ContactOrganization()
        {
            return View();
        }
        public IActionResult CreateOrganization()
        {
            return View();
        }

    }
}
