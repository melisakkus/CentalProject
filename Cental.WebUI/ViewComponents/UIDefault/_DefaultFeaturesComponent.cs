using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.FeatureDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.UIDefault
{
    public class _DefaultFeaturesComponent(IFeatureService _featureService,IMapper _mapper) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var featuresFirst2 = _featureService.TGetAll().TakeLast(2);
            ViewBag.featuresFirst2 = _mapper.Map<List<ResultFeatureDtos>>(featuresFirst2);

            var featuresLast2 = _featureService.TGetAll().Take(2);
            ViewBag.featuresLast2 = _mapper.Map<List<ResultFeatureDtos>>(featuresLast2);
            return View();
        }
    }
}
