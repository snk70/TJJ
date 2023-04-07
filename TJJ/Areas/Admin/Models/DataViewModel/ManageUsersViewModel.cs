using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TJJ.Areas.Admin.DataViewModel
{
    public class ManageUsersViewModel
    {
        [Display(Name = "شناسه")]
        public string ID { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "نام")]
        [MaxLength(20, ErrorMessage = "مقدار {0} از حد مجاز بیشتر است")]
        public string fname { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "فامیلی")]
        [MaxLength(40, ErrorMessage = "مقدار {0} از حد مجاز بیشتر است")]
        public string lname { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "کد ملی")]
        [MaxLength(15, ErrorMessage = "مقدار {0} از حد مجاز بیشتر است")]
        public string code_melli { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "تاریخ تولد")]
        [MaxLength(10, ErrorMessage = "مقدار {0} از حد مجاز بیشتر است")]
        public string birthday_date { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "نوع")]
        //0 => Customer  , 1 => Seller ,  => 2 Seller and Customer
        public short user_type { get; set; }

        //[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "Inviter")]
        [MaxLength(100, ErrorMessage = "حداکثر طول {0}، 100 کاراکتر میباشد.")]
        public string inviter_code { get; set; }


        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "موبایل")]
        [MaxLength(15, ErrorMessage = "حداکثر طول {0}، 15 رقم میباشد.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "وضعیت تأیید شماره موبایل ثبت شده")]
        public bool PhoneConfirmed { get; set; }


        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [EmailAddress]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Display(Name = "وضعیت تأیید آدرس ایمیل ثبت شده")]
        public bool EmailConfirmed { get; set; }

        [Display(Name = "نام کاربری)")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "طول {0} باید حداقل {2} کاراکتر باشد.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "رمزعبور")]
        public string Password { get; set; }

        [Required(ErrorMessage = "لطفا {0} را تأیید کنید")]
        [Display(Name = "شارژ طلا")]
        public double gold_charge { get; set; }

        [Required(ErrorMessage = "لطفا {0} را تأیید کنید")]
        [Display(Name = "شارژ ريالی")]
        public double rial_charge { get; set; }

        [Display(Name = "زمان ثبت نام")]
        public DateTime RegisterDateTime { get; set; }



        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "شماره شبا")]
        public string dest_Account_Number { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "شماره کارت")]
        public string dest_Card_Number { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "وضعیت تأیید حساب بانکی")]
        public bool confirm_Account_Bank { get; set; }
    }
}