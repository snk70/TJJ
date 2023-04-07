using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TJJ.Areas.Admin.DataViewModel
{
    public class ManageTicketsViewModel
    {
        [Display(Name = "شناسه درخواست")]
        [Key]
        public int ticket_id { get; set; }


        [Display(Name = "شناسه کاربر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Id { get; set; }

        [Display(Name = "نام کاربر")]
        public string FullName { get; set; }


        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "شناسه درخواست این پاسخ")]
        //ticket_answer_id=-1 => Means Ticket is new
        public int ticket_answer_id { get; set; }


        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "تاریخ ارسال درخواست")]
        public DateTime ticket_date_time { get; set; }


        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "موضوع درخواست")]
        [MaxLength(130)]
        public string ticket_subject { get; set; }


        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "متن درخواست")]
        [MaxLength(5000)]
        public string ticket_desc { get; set; }


        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "وضعیت خوانده شدن درخواست")]
        public bool read_ticket { get; set; }
    }
}