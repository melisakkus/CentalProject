using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ServiceDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.UIDefault
{
    public class _DefaultServicesComponent(IServiceService _serviceService, IMapper _mapper) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var services = _serviceService.TGetAll();
            var servicesDtos = _mapper.Map<List<ResultServiceDto>>(services);
            return View(servicesDtos);
        }
    }
}
