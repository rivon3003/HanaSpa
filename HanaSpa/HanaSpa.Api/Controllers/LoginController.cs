using HanaSpa.Dto;
using HanaSpa.Infrastructure.Business;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HanaSpa.Api.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private IUser _userBus;

        public LoginController(IUser userBus)
        {
            _userBus = userBus;
        }

        [HttpPost]
        public void Login([FromBody] Account account)
        {
            //if (_userBus.CheckValidUser(account))
            if(true)
            {
                Response.StatusCode = (int)HttpStatusCode.OK;
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.NoContent;
            }
            return;
        }
    }
}
