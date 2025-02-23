using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.MessageDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [AllowAnonymous]
    public class ContactController(IGeneralInfoService _generalInfoService,IMessageService _messageService, IMapper _mapper) : Controller
    {
        public IActionResult Index()
        {
            var values = _generalInfoService.TGetAll().TakeLast(1).FirstOrDefault();
            return View(values);
        }

        [HttpPost]
        public IActionResult SendMessage(CreateMessageDto model)
        {
            var message = _mapper.Map<Message>(model);
            _messageService.TCreate(message);
            return RedirectToAction("Index");
        }
    }
}
