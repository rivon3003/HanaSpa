using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using HanaSpa.Infrastructure.Business;
using RivonHouse.Infrastructure.Repository;
using hsDto = HanaSpa.Dto;
using hsEntity = HanaSpa.Data.Entities;

namespace HanaSpa.Business
{
    public class Post : IPost
    {
        #region Contructor and Properties

        private readonly IUnitOfWorkFactory<IUnitOfWork> _uowFac;
        private readonly IMapper _mapper;

        public Post(IUnitOfWorkFactory<IUnitOfWork> uowFac, IMapper mapper)
        {
            _uowFac = uowFac;
            _mapper = mapper;
        }

        #endregion Contructor and Properties

        public IEnumerable<hsDto.Post> GetAll()
        {
            using (var uow = _uowFac.Create())
            {
                var data = uow.Repository<hsEntity.Post>().Get().ToList();
                return _mapper.Map<List<hsEntity.Post>, List<hsDto.Post>>(data);
            }
        }

        public void Create(hsDto.Post post)
        {
            using (var uow = _uowFac.Create())
            {
                var data = _mapper.Map<hsEntity.Post>(post);
                uow.Repository<hsEntity.Post>().Insert(data);
                uow.Save();
            }
        }
    }
}
