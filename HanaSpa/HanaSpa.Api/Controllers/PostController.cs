using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IBusiness = HanaSpa.Infrastructure.Business;

namespace HanaSpa.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Post")]
    public class PostController : Controller
    {
        private readonly IBusiness.IPost _postBusiness;
        [HttpGet]
        public IEnumerable<Dto.Post> Get()
        {
            return _postBusiness.GetAll();
        }
    }
}