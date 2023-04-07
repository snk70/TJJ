using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TJJ.Data_Base.DataViewModels
{
    public class SellRequestViewModel
    {
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "میزان طلای مورد درخواست برای فروش")]
        public double sell_gold_value { get; set; }
    }
}