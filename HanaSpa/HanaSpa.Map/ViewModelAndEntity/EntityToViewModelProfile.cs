using AutoMapper;
using hsEntity = HanaSpa.Data.Entities;

namespace HanaSpa.Map.ViewModelAndEntity
{
    public class EntityToViewModelProfile : Profile
    {
        public EntityToViewModelProfile()
        {
            CreateMap<hsEntity.Service, Dto.Service>();
        }
    }
}
