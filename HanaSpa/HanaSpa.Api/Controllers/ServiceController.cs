using HanaSpa.Infrastructure.Business;
using Microsoft.AspNetCore.Mvc;
using RivonHouse.Common.Data.Result;
using System.Collections.Generic;

namespace HanaSpa.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ServiceController : Controller
    {
        private IService _serviceBus;

        public ServiceController(IService serviceBus)
        {
            _serviceBus = serviceBus;
        }

        [HttpGet]
        public IEnumerable<Dto.Service> Get()
        {
            return _serviceBus.GetAll();
        }

        [HttpPost]
        public Save Create([FromBody] Dto.Service service)
        {
            _serviceBus.Create(service);
            return new Save();
        }
    }
}