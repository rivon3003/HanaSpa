using HanaSpa.Dto;
using HanaSpa.Infrastructure.Business;

namespace HanaSpa.Business
{
    public class User : IUser
    {
        public bool CheckValidUser(Account account)
        {
            if (account.Email == "than")
            {
                return true;
            }
            return false;
        }
    }
}
