using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RivonHouse.Common.Data.ViewModel.Account
{
    public class AccountWithPassword : AccountBase
    {
        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [RegularExpression(@"^[^\s\,]+$")]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
