using Cental.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.User.ViewComponents
{
    public class _UserLoginLayoutTopbarComponent(IGeneralInfoService _generalInfoService) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var infos = _generalInfoService.TGetAll().TakeLast(1).FirstOrDefault();
            return View(infos);
        }
    }
}
