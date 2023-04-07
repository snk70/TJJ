using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TJJ.DataViewModels.RequestMoney
{
    public class User_Set
    {
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "میزان شارژ طلا برای فروش")]
        public int sell_gold_value { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "شماره حساب، شبا و یا کارت مقصد")]
        [MaxLength(65)]
        public string sell_dest_account_number { get; set; }

        [Display(Name = "توضیحات اضافه درخواست")]
        [MaxLength(3000)]
        public string sell_user_comment { get; set; }
    }

    public class User_Get_View
    {
        [Key]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "شناسه درخواست")]
        public int req_id { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "وضعیت درخواست")]
        //0 => Requested  , 1 => Confirmed ,  => -1 Rejected
        public string req_status { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "میزان طلای فروخته شده")]
        public int sell_gold_value { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "مبلغ درخواستی به ریال")]
        public int req_money_value { get; set; }


        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "تاریخ ثبت درخواست")]
        public DateTime sell_date_time { get; set; }

        [Display(Name = "کد رهگیری")]
        [MaxLength(50)]
        public string sell_tracking_code { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "شماره حساب مقصد")]
        [MaxLength(65)]
        public string sell_dest_account_number { get; set; }

        [Display(Name = "تصویر واریز")]
        [MaxLength(300)]
        public string sell_img { get; set; }


        [Display(Name = "توضیحات اضافه کاربر سرمایه گذار")]
        [MaxLength(3000)]
        public string sell_user_comment { get; set; }

        [Display(Name = "توضیحات اضافه پس از واریز")]
        [MaxLength(3000)]
        public string sell_admin_comment { get; set; }

    }

}