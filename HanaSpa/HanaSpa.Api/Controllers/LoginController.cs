using HanaSpa.Dto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HanaSpa.Api.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        [HttpPost]
        [EnableCors("AllowSpecificOrigin")]
        public void Login([FromBody] Account account)
        {
            if(account.Email == "than")
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
