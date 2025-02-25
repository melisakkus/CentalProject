using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ProcessDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.UIDefault
{
    public class _DefaultProcessComponent(IProcessService _processService, IMapper _mapper) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var processes = _processService.TGetAll();
            var dtos = _mapper.Map<List<ResultProcessDto>>(processes);
            return View(dtos);
        }
    }
}
