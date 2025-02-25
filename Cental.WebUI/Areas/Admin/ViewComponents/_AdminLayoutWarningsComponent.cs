using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Admin.ViewComponents
{
    public class _AdminLayoutWarningsComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
