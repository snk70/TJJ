using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TJJ.Areas.DataViewModel
{
    public class ManageSellsViewModel
    {
        [Key]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "شناسه درخواست")]
        public int req_id { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "شناسه کاربر")]
        public string Id { get; set; }

        [Display(Name = "نام کاربر")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "وضعیت درخواست")]
        //0 => Requested  , 1 => Confirmed ,  => -1 Rejected
        public short req_status { get; set; }

        //[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        //[Display(Name = "میزان طلا")]
        //public float sell_gold_value { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "مبلغ درخواستی به ریال")]
        public double req_money_value { get; set; }


        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "زمان ارسال")]
        public DateTime sell_date_time { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "کد رهگیری")]
        [MaxLength(50)]
        public string sell_tracking_code { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "شماره حساب مقصد")]
        [MaxLength(65)]
        public string sell_dest_account_number { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "شماره کارت مقصد")]
        [MaxLength(65)]
        public string sell_dest_card_number { get; set; }

        [Display(Name = "توضیحات اضافه")]
        [MaxLength(3000)]
        public string sell_user_comment { get; set; }


        [Display(Name = "شماره شبا حساب مقصد")]
        public string dest_Account_Number { get; set; }
        [Display(Name = "شماره کارت مقصد")]
        public string dest_Card_Number { get; set; }
        [Display(Name = "تأیید اطلاعات بانکی")]
        //0 => Requested  , 1 => Confirmed ,  => -1 Rejected
        public bool confirm_Account_Bank { get; set; }
    }
}