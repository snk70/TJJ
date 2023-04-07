using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TJJ.Data_Base.DataViewModels
{
    public class InsertBuyGoldChargeViewModel
    {
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "میزان شارژ ریالی جهت تبدیل به شارژ طلای خام")]
        public double charge_rial_value { get; set; }

        //[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        //[Display(Name = "میزان شارژ طلای درخواستی(گرم طلا)")]
        //public int charge_gold_value { get; set; }

        //[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        //[Display(Name = "کد رهگیری")]
        //[MaxLength(50)]
        //public string deposit_tracking_code { get; set; }

        //[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        //[Display(Name = "شماره حساب مقصد")]
        //[MaxLength(65)]
        //public string deposit_dest_account_number { get; set; }

        //[Display(Name = "توضیحات اضافه(اختیاری)")]
        //[MaxLength(3000)]
        //public string deposit_comment { get; set; }
    }
}