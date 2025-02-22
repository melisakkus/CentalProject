using Cental.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.UILayout
{
    public class _LayoutFooterComponent(IGeneralInfoService _generalInfoService) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var value = _generalInfoService.TGetAll().TakeLast(1).FirstOrDefault();
            return View(value);
        }
    }
}
