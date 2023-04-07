using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IdentitySample.Models;


namespace TJJ.Models
{
    public class tbl_Deposits
    {
        [Key]
        [Display(Name = "شناسه واریز")]
        public int deposit_id { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "شناسه کاربر")]
        public string Id { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "وضعیت درخواست شارژ حساب")]
        //0 => Requested  , 1 => Confirmed ,  => -1 Rejected
        public short deposit_status { get; set; }

        //[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        //[Display(Name = "میزان شارژ طلای درخواستی")]
        //public int charge_gold_value { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "مبلغ واریز به ریال")]
        public double deposit_money_value { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "تاریخ واریز")]
        [Column(TypeName = "datetime2")]
        public DateTime deposit_date_time { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "کد رهگیری")]
        [MaxLength(50)]
        public string deposit_tracking_code { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "شماره حساب مقصد")]
        [MaxLength(65)]
        public string deposit_dest_account_number { get; set; }

        [Display(Name = "تصویر واریز")]
        [MaxLength(300)]
        public string deposit_img { get; set; }


        [Display(Name = "توضیحات اضافه")]
        [MaxLength(3000)]
        public string deposit_comment { get; set; }
        public virtual ApplicationUser tbl_Users { get; set; }

        public tbl_Deposits()
        {

        }
    }
}
