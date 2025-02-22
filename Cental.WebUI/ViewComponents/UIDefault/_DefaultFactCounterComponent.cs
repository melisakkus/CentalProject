using Cental.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.UIDefault
{
    public class _DefaultFactCounterComponent(IFactCounterService _factCounterService) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.GetUserCount = _factCounterService.TGetUserCount();
            ViewBag.GetCarCount = _factCounterService.TGetCarCount();
            ViewBag.GetReviewCount = _factCounterService.TGetReviewCount();
            ViewBag.GetBookingCount = _factCounterService.TGetBookingCount();
            return View();
        }
    }
}
