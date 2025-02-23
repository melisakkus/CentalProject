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

            ViewBag.TotalMessageCount = _dashboardService.TGetMessageCount();
            ViewBag.TotalBookingCount = _dashboardService.TGetBookingCount();
            ViewBag.MessageList = _dashboardService.TGetMessages();
            ViewBag.BookingList = _dashboardService.TGetBookings();
            ViewBag.TestimonialList = _dashboardService.TGetTestimonials();

            ViewBag.ApprovedBookingCount = _dashboardService.TApprovedBookingCount();
            ViewBag.WaitingBookingCount = _dashboardService.TWaitingBookingCount();
            ViewBag.DeclineBookingCount = _dashboardService.TDeclineBookingCount();

            //ViewBag.LastAddedCars = _dashboardService.TGetLastAddesCars();

            return View();
        }

    }

}
