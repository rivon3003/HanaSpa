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
    [Route("api/Service")]
    public class ServiceController : Controller
    {
        private IService _service;

        public ServiceController(IService service)
        {
            _service = service;
        }

        public IEnumerable<Dto.Service> Get()
        {
            return _service.Get();
        }
    }
}