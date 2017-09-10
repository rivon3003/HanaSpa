using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using HanaSpa.Infrastructure.Business;
using RivonHouse.Infrastructure.Repository;
using HsEntity = HanaSpa.Data.Entities;

namespace HanaSpa.Business
{
    public class Service : IService
    {
        #region Contructor and Properties

        private readonly IUnitOfWorkFactory<IUnitOfWork> _uowFac;
        private readonly IMapper _mapper;

        public Service(IUnitOfWorkFactory<IUnitOfWork> uowFac, IMapper mapper)
        {
            _uowFac = uowFac;
            _mapper = mapper;
        }

        #endregion Contructor and Properties

        public IEnumerable<Dto.Service> GetAll()
        {
            using (var uow = _uowFac.Create())
            {
                var data = uow.Repository<HsEntity.Service>().Get().ToList();
                return _mapper.Map<List<HsEntity.Service>, List<Dto.Service>>(data);
            }
        }

        public void Create(Dto.Service entity)
        {
            using (var uow = _uowFac.Create())
            {
                var data = _mapper.Map<Dto.Service, HsEntity.Service>(entity);
                uow.Repository<HsEntity.Service>().Insert(data);
                uow.Save();
            }
        }
    }
}
