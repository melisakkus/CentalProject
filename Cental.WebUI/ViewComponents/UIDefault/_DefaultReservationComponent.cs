using Cental.BusinessLayer.Abstract;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cental.WebUI.ViewComponents.UIDefault
{
    public class _DefaultReservationComponent : ViewComponent
    {
        private readonly IBookingService _bookingService;
        private readonly IBannerService _bannerService;
        private readonly ICarService _carService;
        public _DefaultReservationComponent(IBookingService bookingService, ICarService carService, IBannerService bannerService)
        {
            _bookingService = bookingService;
            _carService = carService;
            _bannerService = bannerService;
        }

        public IViewComponentResult Invoke(Booking model)
        {
            var selectCarList = (from car in _carService.TGetAll()
                                 select new SelectListItem
                                 {
                                     Text = car.Brand.BrandName + " " + car.ModelName,
                                     Value = car.CarId.ToString(),
                                 }).ToList();
            ViewBag.CarList = selectCarList;
            return View(model ?? new Booking());
        }                       
    }
}
