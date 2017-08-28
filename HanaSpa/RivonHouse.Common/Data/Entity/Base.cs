using System;
using System.Collections.Generic;
using System.Text;

namespace RivonHouse.Common.Data.Entity
{
    public class Base
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
    }
}
