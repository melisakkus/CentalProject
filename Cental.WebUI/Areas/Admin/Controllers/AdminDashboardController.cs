using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class AdminDashboardController(IDashboardService _dashboardService) : Controller
    {

        public IActionResult Index()
        {
            ViewBag.BrandCount = _dashboardService.TGetBrandCount();

            ViewBag.TotalUserCount = _dashboardService.TTotalUserCount();
            ViewBag.TotalCarCount = _dashboardService.TTotalCarCount();
            ViewBag.TotalReviewCount = _dashboardService.TGetReviewCount();

            ViewBag.TestimonialCount = _dashboardService.TGetTestimonialCount();
            
            var value = _dashboardService.TGetTestimonialAvarage();
            ViewBag.TestimonialAvarage = Math.Round(value, 2);

            //ViewBag.LastAddedCars = _dashboardService.TGetLastAddesCars();

            return View();
        }

    }

}
