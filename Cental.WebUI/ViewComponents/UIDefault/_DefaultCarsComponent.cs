using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.CarDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.UIDefault
{
    public class _DefaultCarsComponent(ICarService _carService, IMapper _mapper) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var cars = _carService.TGetAll().TakeLast(6);
            var dtos = _mapper.Map<List<ResultCarDto>>(cars);
            return View(dtos);
        }
    }
}
