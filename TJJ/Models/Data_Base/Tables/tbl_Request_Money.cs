using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using IdentitySample.Models;

namespace TJJ.Models
{
    public class tbl_Request_Money
    {
        [Key]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "شناسه فروش")]
        public int req_id { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "شناسه کاربر")]
        public string Id { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "وضعیت درخواست")]
        //0 => Requested  , 1 => Confirmed ,  => -1 Rejected
        public short req_status { get; set; }

        //[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "میزان طلای فروخته شده")]
        public float sell_gold_value { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "مبلغ درخواستی به ریال")]
        public double req_money_value { get; set; }


        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "تاریخ درخواست")]
        public DateTime sell_date_time { get; set; }

        //[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "کد رهگیری")]
        [MaxLength(50)]
        public string sell_tracking_code { get; set; }

        //[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        //[Display(Name = "شماره حساب مقصد")]
        //[MaxLength(65)]
        //public string sell_dest_account_number { get; set; }

        [Display(Name = "تصویر واریز")]
        [MaxLength(300)]
        public string sell_img { get; set; }


        [Display(Name = "توضیحات اضافه")]
        [MaxLength(3000)]
        public string sell_user_comment { get; set; }

        [Display(Name = "توضیحات اضافه")]
        [MaxLength(3000)]
        public string sell_admin_comment { get; set; }

        public virtual ApplicationUser tbl_Users { get; set; }

        public tbl_Request_Money()
        {

        }

    }
}