using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using RivonHouse.Common.Data.Dto;
using System.Web;

namespace HanaSpa.Dto
{
    public class Service : Base
    {
        public byte[]  Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
