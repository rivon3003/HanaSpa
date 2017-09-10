using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace HanaSpa.ViewModel
{
    public class Service
    {
        public Dto.Service service { get; set; }
        public IFormFile serviceImage { get; set; }
    }
}
