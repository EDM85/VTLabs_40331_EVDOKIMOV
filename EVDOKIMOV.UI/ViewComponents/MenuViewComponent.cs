using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EVDOKIMOV.UI.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewData["controller"] = Request.RouteValues["controller"]
                ?.ToString()
                ?.ToLower()
                ?? string.Empty;

            ViewData["area"] = Request.RouteValues["area"]
                ?.ToString()
                ?.ToLower()
                ?? string.Empty;

            return View();
        }   
    }
}
