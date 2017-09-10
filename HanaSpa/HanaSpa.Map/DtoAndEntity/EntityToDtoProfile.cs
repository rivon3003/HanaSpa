using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using hsEntity = HanaSpa.Data.Entities;

namespace HanaSpa.Map.DtoAndEntity
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<hsEntity.Post, Dto.Post>();
            CreateMap<hsEntity.Service, Dto.Service>();
        }
    }
}
