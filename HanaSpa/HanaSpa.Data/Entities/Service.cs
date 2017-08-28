using System;
using System.Collections.Generic;
using System.Text;
using RivonHouse.Common.Data.Entity;

namespace HanaSpa.Data.Entities
{
    public class Service : Base
    {
        public byte[] Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
