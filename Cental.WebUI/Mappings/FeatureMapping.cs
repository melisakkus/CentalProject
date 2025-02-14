using AutoMapper;
using Cental.DtoLayer.FeatureDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mappings
{
    public class FeatureMapping : Profile
    {
        public FeatureMapping() 
        {
            CreateMap<Feature, CreateFeatureDtos>().ReverseMap();
            CreateMap<Feature, ResultFeatureDtos>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDtos>().ReverseMap();
        }
    }
}
