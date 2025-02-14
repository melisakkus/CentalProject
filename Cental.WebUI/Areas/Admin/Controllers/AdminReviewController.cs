using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ReviewDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class AdminReviewController(IReviewService _reviewService, IMapper _mapper) : Controller
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

        public IActionResult UpdateReview(int id)
        {
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
