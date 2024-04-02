using Microsoft.AspNetCore.Mvc.Rendering;
using ShowNest.Web.ViewModels.Events;
using ShowNest.Web.ViewModels.UserAccount;

namespace ShowNest.Web.ViewModels.Dashboard
{
    
    public class CreateEventViewModel
    {
       
        public List<SelectListItem> OrgName { get; set; }
        public List<SelectListItem> EventName { get; set; }
    }

}



