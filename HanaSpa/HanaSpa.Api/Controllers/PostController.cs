using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HanaSpa.Infrastructure.Business;

namespace HanaSpa.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Post")]
    public class PostController : Controller
    {
        private readonly IPost _postBusiness;

        public PostController(IPost postBusiness)
        {
            _postBusiness = postBusiness;
        }

        [HttpGet]
        public IEnumerable<Dto.Post> Get()
        {
            return _postBusiness.GetAll();
        }

        [HttpPost]
        public void Post()
        {
            _postBusiness.Create();
        }
    }
}