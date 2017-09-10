using System.Collections.Generic;
using HanaSpa.Infrastructure.Business;
using Microsoft.AspNetCore.Mvc;

namespace HanaSpa.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Post")]
    public class PostController : Controller
    {
        private readonly IPost _postBus;

        public PostController(IPost postBus)
        {
            _postBus = postBus;
        }

        [HttpGet]
        public IEnumerable<Dto.Post> Get()
        {
            return _postBus.GetAll();
        }

        [HttpPost]
        public void Post(Dto.Post post)
        {
            _postBus.Create(post);
        }
    }
}