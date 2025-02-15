using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.FeatureDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminFeatureController(IFeatureService _featureService, IMapper _mapper) : Controller
    {
        public IActionResult Index()
        {
            var features = _featureService.TGetAll();
            var values = _mapper.Map<List<ResultFeatureDtos>>(features);
            return View(values);
        }

        public IActionResult DeleteFeature(int id)
        {
            _featureService.TDelete(id);
            return RedirectToAction("Index");
        }

        public IActionResult CreateFeature()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDtos model)
        {
            var feature = _mapper.Map<Feature>(model);
            _featureService.TCreate(feature);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateFeature(int id)
        {
            var feature = _featureService.TGetById(id);
            var dtoFeature = _mapper.Map<UpdateFeatureDtos>(feature);
            return View(dtoFeature);
        }
        [HttpPost]
        public IActionResult UpdateFeature(UpdateFeatureDtos model)
        {
            var feature = _mapper.Map<Feature>(model);
            _featureService.TUpdate(feature);
            return RedirectToAction("Index");
        }
    }
}
