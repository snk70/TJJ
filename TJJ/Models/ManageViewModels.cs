using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdentitySample.Models
{
    public class IndexViewModel
    {

        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        [Display(Name = "شماره موبایل")]
        public string PhoneNumber { get; set; }
        [Display(Name = "ورود دومرحله ای")]
        public bool TwoFactor { get; set; }
        [Display(Name = "بخاطر سپردن این مرورگر")]
        public bool BrowserRemembered { get; set; }
    }

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "طول {0} باید حداقل {2} کاراکتر باشد.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "رمزعبور جدید")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تکرار رمزعبور جدید")]
        [StringLength(100, ErrorMessage = "طول {0} باید حداقل {2} کاراکتر باشد.", MinimumLength = 6)]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "رمزعبور فعلی")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "طول {0} باید حداقل {2} کاراکتر باشد.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "رمزعبور جدید")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تکرار رمز عبور جدید")]
        [Compare("NewPassword", ErrorMessage = "رمزعبور جدید و تکرار آن یکسان نیستند.")]
        public string ConfirmPassword { get; set; }
    }


    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "شماره موبایل")]
        public string Number { get; set; }
    }

    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "کد")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "شماره موبایل")]
        public string PhoneNumber { get; set; }
    }

    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }

}