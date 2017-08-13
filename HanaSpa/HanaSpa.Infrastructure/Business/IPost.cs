using System;
using System.Collections.Generic;
using System.Text;

namespace HanaSpa.Infrastructure.Business
{
    public interface IPost
    {
        List<Dto.Post> GetAll();
    }
}
