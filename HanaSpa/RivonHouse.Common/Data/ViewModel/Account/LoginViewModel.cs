using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RivonHouse.Common.Data.ViewModel.Account
{
    public class LoginViewModel : AccountWithPassword
    {
        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
