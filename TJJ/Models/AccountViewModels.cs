using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdentitySample.Models
{
    public class ExternalLoginConfirmationViewModel
    {

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "کد")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "این مرورگر را بخاطر بسپار")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "نام کاربری")]
        //[EmailAddress]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        [Display(Name = "مرا بخاطر بسپار")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "نام")]
        [MaxLength(20, ErrorMessage = "مقدار {0} از حد مجاز بیشتر است")]
        public string fname { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "نام خانوادگی")]
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
        [Display(Name = "نوع کاربر")]
        //0 => Customer  , 1 => Seller ,  => 2 Seller and Customer
        public short user_type { get; set; }

        //[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "شناسه دعوت کننده(اختیاری)")]
        [MaxLength(100, ErrorMessage = "حداکثر طول {0}، 100 کاراکتر میباشد.")]
        public string inviter_code { get; set; }


        //[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "شماره موبایل")]
        [MaxLength(15, ErrorMessage = "حداکثر طول {0}، 15 رقم میباشد.")]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [EmailAddress]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        //[Display(Name = "شماره شبا")]
        //public string dest_Account_Number { get; set; }

        //[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        //[Display(Name = "شماره کارت")]
        //public string dest_Card_Number { get; set; }

        //[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        //[Display(Name = "وضعیت تأیید اطلاعات حساب")]
        //public bool confirm_Account_Bank { get; set; }

        [Display(Name = "نام کاربری(اختیاری)")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "طول {0} باید حداقل {2} کاراکتر باشد.", MinimumLength = 6)]
        [DataType(DataType.Password,ErrorMessage ="رمزعبور باید شامل حداقل یک رقم، حرف بزرگ و حرف کوچک لاتین و کاراکتر خاص باشد.")]
        [Display(Name = "رمزعبور")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تکرار کلمه عبور")]
        [Compare("Password", ErrorMessage = "رمزعبور واد شده با تکرار آن مطابقت ندارد.")]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "لطفا {0} را تأیید کنید")]
        [Display(Name = "قوانین و مقررات را مطالعه کرده و با آن موافقم")]
        public bool read_terms { get; set; }

        //[Required(ErrorMessage = "لطفا {0} را تأیید کنید")]
        //[Display(Name = "شارژ حساب کاربری")]
        //public int gold_charge { get; set; }
    }

    public class EditUserInfoViewModel
    {
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "نام")]
        [MaxLength(20, ErrorMessage = "مقدار {0} از حد مجاز بیشتر است")]
        public string fname { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "نام خانوادگی")]
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
        [EmailAddress]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }


        #region شبا
        [Display(Name = "شماره شبا")]
        public string dest_Account_Number { get; set; }


        [MaxLength(2)]
        public string DestAccountNumber_1 { get; set; }

        [MaxLength(4)]
        public string DestAccountNumber_2 { get; set; }

        [MaxLength(4)]
        public string DestAccountNumber_3 { get; set; }

        [MaxLength(4)]
        public string DestAccountNumber_4 { get; set; }

        [MaxLength(4)]
        public string DestAccountNumber_5 { get; set; }

        [MaxLength(4)]
        public string DestAccountNumber_6 { get; set; }

        [MaxLength(2)]
        public string DestAccountNumber_7 { get; set; }
        #endregion


        #region شماره کارت

        [Display(Name = "شماره کارت")]
        public string dest_Card_Number { get; set; }


        [Display(Name = "4")]
        public string DestCardNumber_1 { get; set; }

        [Display(Name = "4")]
        public string DestCardNumber_2 { get; set; }

        [Display(Name = "4")]
        public string DestCardNumber_3 { get; set; }

        [Display(Name = "4")]
        public string DestCardNumber_4 { get; set; }

        #endregion
    }


    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "طول {0} باید حداقل {2} کاراکتر باشد.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "رمزعبور")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تکرار رمزعبور")]
        [StringLength(100, ErrorMessage = "طول {0} باید حداقل {2} کاراکتر باشد.", MinimumLength = 6)]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "ایمیل، نام کاربری و یا کلمه عبور")]
        public string Email { get; set; }
    }
}