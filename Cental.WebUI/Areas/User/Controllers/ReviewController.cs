using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ReviewDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cental.WebUI.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    [Area("User")]
    public class ReviewController(IReviewService _reviewService, ICarService _carService, IMapper _mapper,UserManager<AppUser> _userManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            //var user = await _userManager.FindByNameAsync(User.Identity.Name);
            //var reviews = _reviewService.TGetReviewsById(user.Id);
            var reviews = _reviewService.TGetAll();
            return View(reviews);
        }

        public IActionResult DeleteReview(int id)
        {
            _reviewService.TDelete(id);
            return RedirectToAction("Index");
        }

        private void SelectCarList()
        {
            var cars = _carService.TGetAll();
            var carList = (from car in cars
                           select new SelectListItem
                           {
                               Text = car.Brand.BrandName + " " + car.ModelName + " " + car.Year,
                               Value = car.CarId.ToString()
                           }).ToList();
            ViewBag.CarList = carList;
        }
        public IActionResult UpdateReview(int id)
        {
            SelectCarList();
            var review = _reviewService.TGetById(id);
            var dtoReview = _mapper.Map<UpdateReviewDto>(review);
            return View(dtoReview);
        }
        [HttpPost]
        public IActionResult UpdateReview(UpdateReviewDto model)
        {
            var value = _mapper.Map<Review>(model);
            _reviewService.TUpdate(value);
            return RedirectToAction("Index");
        }

        public IActionResult CreateReview()
        {
            SelectCarList();
            return View();
        }
        [HttpPost]
        public IActionResult CreateReview(CreateReviewDto model)
        {
            var review = _mapper.Map<Review>(model);
            _reviewService.TCreate(review);
            return RedirectToAction("Index");
        }
    }
}
