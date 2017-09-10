using System.Collections.Generic;

using hsDto = HanaSpa.Dto;

namespace HanaSpa.Infrastructure.Business
{
    public interface IPost
    {
        IEnumerable<hsDto.Post> GetAll();
        void Create(hsDto.Post post);
    }
}
