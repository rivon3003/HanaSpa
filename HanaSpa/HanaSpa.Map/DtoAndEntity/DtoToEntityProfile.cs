using System;
using System.Collections.Generic;
using System.Text;
using hsEntity = HanaSpa.Data.Entities;
using AutoMapper;

namespace HanaSpa.Map.DtoAndEntity
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            CreateMap<Dto.Post, hsEntity.Post>();
            CreateMap<Dto.Service, hsEntity.Service>();
        }
    }
}