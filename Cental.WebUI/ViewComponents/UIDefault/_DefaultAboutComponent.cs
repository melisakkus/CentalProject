using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.AboutDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.UIDefault
{
    public class _DefaultAboutComponent(IAboutService _aboutService, IMapper _mapper) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var values = _aboutService.TGetAll();
            var dtos = _mapper.Map<List<UIResultListAboutDto>>(values);
            return View(dtos);
        }
    }
}
