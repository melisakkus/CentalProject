using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.UIDefault
{
    public class _DefaultTestimonialComponent(ITestimonialService _testimonialService, IMapper _mapper) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var testimonials = _testimonialService.TGetAll();
            var dtos = _mapper.Map<List<ResultTestimonialDto>>(testimonials);
            return View(dtos);
        }
    }
}
