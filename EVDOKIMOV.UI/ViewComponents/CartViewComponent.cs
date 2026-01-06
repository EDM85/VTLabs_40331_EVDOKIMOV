using Microsoft.AspNetCore.Mvc;

namespace EVDOKIMOV.UI.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {  
            return View();
        }
    }
}
