using RivonHouse.Common.Data.Entity;

namespace HanaSpa.Data.Entities
{
    public class User : Base
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
