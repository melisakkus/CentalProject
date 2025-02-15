using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.BusinessLayer.Concrete;
using Cental.DtoLayer.ServiceDtos;
using Cental.DtoLayer.TestimonialDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminTestimonialController(ITestimonialService _testimonialService, IMapper _mapper,IImageService _imageService) : Controller
    {

        public IActionResult Index()
        {
            var values = _testimonialService.TGetAll();
            var model = _mapper.Map<List<ResultTestimonialDto>>(values);
            return View(model);
        }

        public IActionResult DeleteTestimonial(int id)
        {
            _testimonialService.TDelete(id);
            return RedirectToAction("Index");
        }

        public IActionResult CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto model)
        {
            var testimonial = _mapper.Map<Testimonial>(model);
            if (model.ImageFile != null)
            {
                var imageUrl = await _imageService.SaveImageAsync(model.ImageFile);
                testimonial.ImageUrl = imageUrl;
            }
            _testimonialService.TCreate(testimonial);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateTestimonial(int id)
        {
            var values = _testimonialService.TGetById(id);
            var testimonial = _mapper.Map<UpdateTestimonialDto>(values);
            return View(testimonial);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto model)
        {
            var values = _mapper.Map<Testimonial>(model);
            if(model.ImageFile != null)
            {
                var imageUrl = await _imageService.SaveImageAsync(model.ImageFile);
                values.ImageUrl = imageUrl;
            }
            _testimonialService.TUpdate(values);
            return RedirectToAction("Index");
        }
    }
}
