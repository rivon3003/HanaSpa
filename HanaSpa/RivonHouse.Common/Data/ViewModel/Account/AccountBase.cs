using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RivonHouse.Common.Data.ViewModel.Account
{
    public class AccountBase: DataObjBase
    {
        [Required(AllowEmptyStrings = false)]
        [RegularExpression(@"^[0-9]{4}$")]
        [Display(Name = "Account Number")]
        [DisplayFormat(DataFormatString = "{0:#### #### #### ####}")]
        public string AccountNumber { get; set; }
        public string RowVersion { get; set; }
    }
}
