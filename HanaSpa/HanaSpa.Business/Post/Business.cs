using System;
using System.Collections.Generic;
using System.Text;
using HanaSpa.Infrastructure.Business;
using RivonHouse.Infrastructure.Repository;
using HanaSpa.Data.Entities;

namespace HanaSpa.Business.Post
{
    public class Business : IPost
    {
        #region Contructor and Properties

        private readonly IUnitOfWorkFactory<IUnitOfWork> _uowFac;

        public Business(IUnitOfWorkFactory<IUnitOfWork> uowFac)
        {
            _uowFac = uowFac;
        }

        #endregion Contructor and Properties

        public List<Dto.Post> GetAll()
        {
            var result = new List<Dto.Post>
            {
                new Dto.Post { Id = 1 },
                new Dto.Post { Id = 2 },
                new Dto.Post { Id = 3 }
            };
            return result;
        }

        public void Create()
        {
            using (var uow = _uowFac.Create())
            {
                uow.Repository<Service>().Insert(new Service());
                uow.Save();
            }
        }
    }
}
