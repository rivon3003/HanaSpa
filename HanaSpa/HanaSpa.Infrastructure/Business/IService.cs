using System.Collections.Generic;

namespace HanaSpa.Infrastructure.Business
{
    public interface IService
    {
        IEnumerable<Dto.Service> GetAll();
        void Create(Dto.Service post);
    }
}
