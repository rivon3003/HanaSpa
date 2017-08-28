using System;
using System.Collections.Generic;
using System.Text;

namespace HanaSpa.Infrastructure.Business
{
    public interface IService
    {
        List<Dto.Service> Get();
    }
}
