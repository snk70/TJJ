using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TJJ.Models
{
    public class tbl_User_Notifications
    {
        [Display(Name = "شناسه پیام")]
        [Key]
        public int ticket_id { get; set; }

        [Display(Name = "شناسه کاربر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Id { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "تاریخ ارسال پیام")]
        [Column(TypeName = "datetime2")]
        public DateTime not_creation_date_time { get; set; }


        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "موضوع پیام")]
        [MaxLength(130)]
        public string not_subject { get; set; }


        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "توضیحات کوتاه پیام")]
        [MaxLength(700)]
        public string not_comment { get; set; }


        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "متن پیام")]
        [MaxLength(5000)]
        public string not_text { get; set; }


        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "وضعیت خوانده شدن درخواست")]
        //0 =>Unread, 1 =>Read
        public bool read_user_not { get; set; }

        public virtual ApplicationUser tbl_Users { get; set; }

        public tbl_User_Notifications()
        {

        }
    }
}