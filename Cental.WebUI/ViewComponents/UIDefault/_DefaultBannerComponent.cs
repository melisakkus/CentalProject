using Cental.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.UIDefault
{
    public class _DefaultBannerComponent : ViewComponent
    {
        private readonly IBannerService _bannerService;
        public _DefaultBannerComponent(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }

        public IViewComponentResult Invoke()
        {
            var banners = _bannerService.TGetAll();
            return View(banners);
        }
    }
}
