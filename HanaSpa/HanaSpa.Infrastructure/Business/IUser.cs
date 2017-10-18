using HanaSpa.Dto;

namespace HanaSpa.Infrastructure.Business
{
    public interface IUser
    {
        bool CheckValidUser(Account account);
    }
}
