using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.BookingDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cental.WebUI.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    [Area("User")]
    public class BookingController(UserManager<AppUser> _userManager,IBookingService _bookingService, ICarService _carService, IMapper _mapper) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name); 
            var bookings = _bookingService.TUsersBookings(user.Id);
            var bookingDtos = _mapper.Map<List<ResultBookingDto>>(bookings);
            return View(bookingDtos);
        }

        private List<SelectListItem> GetCarSelectedList()
        {
            var selectedCarList = (from car in _carService.TGetAll()
                                   select new SelectListItem
                                   {
                                       Text = car.Year + " " + car.ModelName + " " + car.Brand.BrandName,
                                       Value = car.CarId.ToString()
                                   }).ToList();
            return selectedCarList;
        }
        public async Task<IActionResult> CreateRezervationAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.user = user.Id;
            ViewBag.SelectedCarList = GetCarSelectedList();
            return View();
        }
        [HttpPost]
        public IActionResult CreateRezervation(CreateBookingDto model)
        {
            var booking = _mapper.Map<Booking>(model);
            booking.Status = "Beklemede";
            booking.IsApproved = null;
            _bookingService.TCreate(booking);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateRezervationAsync(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.user = user.Id;
            var booking = _bookingService.TGetById(id);
            if (booking.IsApproved == true)
            {
                booking.Status = "Onaylandı";
            }
            else if (booking.IsApproved == false)
            {
                booking.Status = "Reddedildi";
            }
            else
            {
                booking.Status = "Beklemede";
            }
            var bookingDto = _mapper.Map<UpdateBookingDto>(booking);
            ViewBag.SelectedCarList = GetCarSelectedList();
            return View(bookingDto);
        }
        [HttpPost]
        public IActionResult UpdateRezervation(UpdateBookingDto model)
        {
            var booking = _mapper.Map<Booking>(model);
            _bookingService.TUpdate(booking);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteRezervation(int id)
        {
            _bookingService.TDelete(id);
            return RedirectToAction("Index");
        }
    }
}
