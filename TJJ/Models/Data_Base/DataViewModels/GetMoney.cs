using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace TJJ.Data_Base.DataViewModels
{
    public class GetMoney
    {
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "مببلغ مورد نظر به ريال")]
        public double MoneyValue { get; set; }

        [Display(Name = "توضیحات اضافه")]
        [MaxLength(5000)]
        public string Comments { get; set; }
    }
}