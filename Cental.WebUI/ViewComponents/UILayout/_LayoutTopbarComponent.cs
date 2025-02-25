using Cental.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.UILayout
{
    public class _LayoutTopbarComponent(IGeneralInfoService _generalInfoService) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var infos = _generalInfoService.TGetAll().TakeLast(1).FirstOrDefault();
            return View(infos);
        }
    }
}
