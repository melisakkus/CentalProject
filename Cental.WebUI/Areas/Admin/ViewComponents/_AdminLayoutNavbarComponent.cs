using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Admin.ViewComponents
{
    public class _AdminLayoutNavbarComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
