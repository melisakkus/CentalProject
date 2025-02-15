using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.AboutDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminAboutController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IImageService _imageService;
        public AdminAboutController(IAboutService aboutService,IImageService imageService)
        {
            _aboutService = aboutService;
            _imageService = imageService;
        }

        public IActionResult Index()
        {
            var values = _aboutService.TGetAll();

            var result = values.Select(about => new ResultAboutDto
            {
                AboutId = about.AboutId,
                Vision = about.Vision,
                Mision = about.Mision
            }).ToList();

            return View(result);
        }

        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto model)
        {
            if(model.ImageFile1 != null)
            {
                var imageUrl = await _imageService.SaveImageAsync(model.ImageFile1);
                model.ImageUrl1 = imageUrl;
            }
            if (model.ImageFile2 != null)
            {
                var imageUrl1 = await _imageService.SaveImageAsync(model.ImageFile2);
                model.ImageUrl2 = imageUrl1;
            }
            if (model.ProfilePictureFile != null)
            {
                var profileUrl = await _imageService.SaveImageAsync(model.ProfilePictureFile);
                model.ProfilePicture = profileUrl;
            }

            _aboutService.TCreate(new About
            {//manuel olarak object to object mapping yapılır.              
                Description1 = model.Description1,
                Description2 = model.Description2,
                ImageUrl1 = model.ImageUrl1,
                ImageUrl2 = model.ImageUrl2,
                Item1 = model.Item1,
                Item2 = model.Item2,
                Item3 = model.Item3,
                Item4 = model.Item4,
                JobTitle = model.JobTitle,
                Mision = model.Mision,
                NameSurname = model.NameSurname,
                ProfilePicture = model.ProfilePicture,
                StartYear = model.StartYear,
                Vision = model.Vision
            });
            return RedirectToAction("Index");
        }

        public IActionResult DeleteAbout(int id)
        {
            _aboutService.TDelete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {
            var model = _aboutService.TGetById(id);
            var about = new UpdateAboutDto
            {
                AboutId = model.AboutId,
                Description1 = model.Description1,
                Description2 = model.Description2,
                ImageUrl1 = model.ImageUrl1,
                ImageUrl2 = model.ImageUrl2,
                Item1 = model.Item1,
                Item2 = model.Item2,
                Item3 = model.Item3,
                Item4 = model.Item4,
                JobTitle = model.JobTitle,
                Mision = model.Mision,
                NameSurname = model.NameSurname,
                ProfilePicture = model.ProfilePicture,
                StartYear = model.StartYear,
                Vision = model.Vision
            };
            return View(about);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto model)
        {
            if (model.ImageFile1 != null)
            {
                var imageUrl = await _imageService.SaveImageAsync(model.ImageFile1);
                model.ImageUrl1 = imageUrl;
            }
            if (model.ImageFile2 != null)
            {
                var imageUrl2 = await _imageService.SaveImageAsync(model.ImageFile2);
                model.ImageUrl2 = imageUrl2;
            }
            if (model.ProfilePictureFile != null)
            {
                var profileUrl = await _imageService.SaveImageAsync(model.ProfilePictureFile);
                model.ProfilePicture = profileUrl;
            }
            var about = new About
            {
                AboutId = model.AboutId,
                Description1 = model.Description1,
                Description2 = model.Description2,
                ImageUrl1 = model.ImageUrl1,
                ImageUrl2 = model.ImageUrl2,
                Item1 = model.Item1,
                Item2 = model.Item2,
                Item3 = model.Item3,
                Item4 = model.Item4,
                JobTitle = model.JobTitle,
                Mision = model.Mision,
                NameSurname = model.NameSurname,
                ProfilePicture = model.ProfilePicture,
                StartYear = model.StartYear,
                Vision = model.Vision
            };
            _aboutService.TUpdate(about);
            return RedirectToAction("Index");
        }
    }
}