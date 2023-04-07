using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TJJ.Data_Base.DataViewModels
{
    public class DepositIncreaseRial
    {
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "میزان شارژ ریالی")]
        public int charge_rial_value { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "کد رهگیری")]
        [MaxLength(50)]
        public string deposit_tracking_code { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "شماره حساب مقصد")]
        [MaxLength(65)]
        public string deposit_dest_account_number { get; set; }

        [Display(Name = "توضیحات اضافه(اختیاری)")]
        [MaxLength(3000)]
        public string deposit_comment { get; set; }
    }
}