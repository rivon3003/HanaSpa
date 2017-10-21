using AutoMapper;
using HanaSpa.Dto;
using HanaSpa.Infrastructure.Business;
using RivonHouse.Infrastructure.Repository;
using System.Linq;
using Entity = HanaSpa.Data.Entities;

namespace HanaSpa.Business
{
    public class User : IUser
    {
        #region Contructor and Properties

        private readonly IUnitOfWorkFactory<IUnitOfWork> _uowFac;
        private readonly IMapper _mapper;

        public User(IUnitOfWorkFactory<IUnitOfWork> uowFac, IMapper mapper)
        {
            _uowFac = uowFac;
            _mapper = mapper;
        }

        #endregion Contructor and Properties

        public bool CheckValidUser(Account account)
        {
            using (var uow = _uowFac.Create())
            {
                if (uow.Repository<Entity.User>()
                    .Get()
                    .Any(u => 
                    u.Email == account.Email
                    && u.Password == account.Password))
                {
                    return true;
                }
                return false;
            }
        }
    }
}
