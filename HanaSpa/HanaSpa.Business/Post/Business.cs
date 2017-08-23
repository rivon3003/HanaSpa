using System;
using System.Collections.Generic;
using System.Text;
using HanaSpa.Infrastructure.Business;

namespace HanaSpa.Business.Post
{
    public class Business : IPost
    {
        public List<Dto.Post> GetAll()
        {
            var result = new List<Dto.Post>
            {
                new Dto.Post { Id = 1 },
                new Dto.Post { Id = 2 },
                new Dto.Post { Id = 3 }
            };
            return result;
        }

        public void Save()
        {
            
        }
    }
}
