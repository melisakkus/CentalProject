using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ReviewDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminReviewController(IReviewService _reviewService, ICarService _carService, IMapper _mapper) : Controller
    {
        public IActionResult Index()
        {
            var reviews = _reviewService.TGetAll();
            var dtoReviews = _mapper.Map<List<ResultReviewDto>>(reviews);
            return View(dtoReviews);
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
