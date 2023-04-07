using IdentitySample.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IdentitySample.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        IdentitySample.Models.ApplicationDbContext db;
        TJJ.IUsersRepository UsersRepository;

        public ManageController()
        {
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit_User_Info(IdentitySample.Models.EditUserInfoViewModel UserViewModel)
        {
            UserViewModel.dest_Account_Number = UserViewModel.DestAccountNumber_1 + UserViewModel.DestAccountNumber_2 + UserViewModel.DestAccountNumber_3 + UserViewModel.DestAccountNumber_4 + UserViewModel.DestAccountNumber_5 + UserViewModel.DestAccountNumber_6 + UserViewModel.DestAccountNumber_7;
            UserViewModel.dest_Card_Number = UserViewModel.DestCardNumber_1 + UserViewModel.DestCardNumber_2 + UserViewModel.DestCardNumber_3 + UserViewModel.DestCardNumber_4;

            if (ModelState.IsValid && UserViewModel.dest_Account_Number.Length == 24 && UserViewModel.dest_Card_Number.Length == 16)
            {
                db = new ApplicationDbContext();
                string UserID = TJJ.GetUserInfo.GetLogedInUserInfo(User.Identity.Name, db).Id;
                UsersRepository = new TJJ.Services.Users_Repository(db);
                var NowInfo = UsersRepository.Get_User_BY_ID(UserID);

                #region Edit NowInfo Values
                if (NowInfo.code_melli != UserViewModel.code_melli && UsersRepository.Is_User_New(UserViewModel.code_melli, "", "", "").Length > 0)
                {
                    IdentityResult rs = new IdentityResult(new string[] { "این کد ملی توسط شخص دیگری ثبت شده" });
                    AddErrors(rs);
                }
                else if (NowInfo.Email != UserViewModel.Email && UsersRepository.Is_User_New("", "", UserViewModel.Email, "").Length > 0)
                {
                    IdentityResult rs = new IdentityResult(new string[] { "این ایمل توسط شخص دیگری ثبت شده" });
                    AddErrors(rs);
                }
                else
                {
                    //NowInfo.UserName = UserViewModel.UserName;


                    if (NowInfo.Email != UserViewModel.Email)
                    {
                        //کاربر قصد تغییر ایمیل را دارد
                        if (NowInfo.UserName == NowInfo.Email)
                        {
                            NowInfo.UserName = UserViewModel.Email;

                            AuthenticationManager.SignOut();
                            //return RedirectToAction("Login", "Account");
                        }
                        NowInfo.Email = UserViewModel.Email;
                        NowInfo.EmailConfirmed = false;
                    }



                    //تغییر اطلاعات حساب بانکی
                    if (NowInfo.dest_Account_Number != UserViewModel.dest_Account_Number || NowInfo.dest_Card_Number != UserViewModel.dest_Card_Number || NowInfo.fname !=UserViewModel.fname || NowInfo.lname !=UserViewModel.lname)
                    {
                        NowInfo.dest_Card_Number = UserViewModel.dest_Card_Number;
                        NowInfo.dest_Account_Number = UserViewModel.dest_Account_Number;
                        NowInfo.confirm_Account_Bank = false;
                    }
                    #endregion


                    NowInfo.fname = UserViewModel.fname;
                    NowInfo.lname = UserViewModel.lname;
                    NowInfo.code_melli = UserViewModel.code_melli;
                    NowInfo.birthday_date = UserViewModel.birthday_date;

                    db.SaveChanges();
                    UsersRepository.Disposi_db();
                    return RedirectToAction("Index");
                }
            }

            if (UserViewModel.dest_Account_Number.Length != 24)
            {
                ModelState.AddModelError("", "شماره شبا را به شکل صحیح وارد نمایید");
            }

            if (UserViewModel.dest_Card_Number.Length != 16)
            {
                ModelState.AddModelError("", "شماره کارت را به شکل صحیح وارد نمایید");
            }

            return View(UserViewModel);
        }


        [HttpGet]
        public ActionResult Edit_User_Info()
        {
            db = new ApplicationDbContext();
            var UserInfo = TJJ.GetUserInfo.GetLogedInUserInfo(User.Identity.Name, db);
            db.Dispose();

            IdentitySample.Models.EditUserInfoViewModel RegViewModel = new EditUserInfoViewModel()
            {
                birthday_date = UserInfo.birthday_date,
                code_melli = UserInfo.code_melli,
                fname = UserInfo.fname,
                lname = UserInfo.lname,
                Email = UserInfo.Email,
                //dest_Account_Number = UserInfo.dest_Account_Number,
                dest_Card_Number = UserInfo.dest_Card_Number
            };

            if (UserInfo.dest_Account_Number != null)
            {
                if (UserInfo.dest_Account_Number.Length == 24)
                {
                    RegViewModel.DestAccountNumber_1 = UserInfo.dest_Account_Number.Substring(0, 2);
                    RegViewModel.DestAccountNumber_2 = UserInfo.dest_Account_Number.Substring(2, 4);
                    RegViewModel.DestAccountNumber_3 = UserInfo.dest_Account_Number.Substring(6, 4);
                    RegViewModel.DestAccountNumber_4 = UserInfo.dest_Account_Number.Substring(10, 4);
                    RegViewModel.DestAccountNumber_5 = UserInfo.dest_Account_Number.Substring(14, 4);
                    RegViewModel.DestAccountNumber_6 = UserInfo.dest_Account_Number.Substring(18, 4);
                    RegViewModel.DestAccountNumber_7 = UserInfo.dest_Account_Number.Substring(22, 2);
                }
            }

            if (UserInfo.dest_Card_Number != null)
            {
                if (UserInfo.dest_Card_Number.Length == 16)
                {
                    RegViewModel.DestCardNumber_1 = UserInfo.dest_Card_Number.Substring(0, 4);
                    RegViewModel.DestCardNumber_2 = UserInfo.dest_Card_Number.Substring(4, 4);
                    RegViewModel.DestCardNumber_3 = UserInfo.dest_Card_Number.Substring(8, 4);
                    RegViewModel.DestCardNumber_4 = UserInfo.dest_Card_Number.Substring(12, 4);
                }
            }


            return View(RegViewModel);
        }


        public ActionResult SendMail(string id)
        {

            if (id != null && id != "")
            {
                db = new ApplicationDbContext();
                var UserInfo = db.Users.SingleOrDefault(p => p.Id == id);
                db.SaveChanges();
                db.Dispose();

                //return RedirectToAction("Send_Verify_Email", "Account",new { userId=UserInfo.Id, ReturnActionName="Index", ReturnController="ManageUsers" });


                const string keep_link_text = "&%!@=+&%%$#";
                string domain_address = Request.Url.AbsoluteUri.Replace("://", keep_link_text).Replace(Request.Url.PathAndQuery, "").Replace(keep_link_text, "://");

                post_get_information.MyWebRequest wm1 = new post_get_information.MyWebRequest(domain_address + "/Account/Send_Verify_Email/", "POST", "userId=" + UserInfo.Id);
                wm1.GetResponse();
            }


            return RedirectToAction("Index");
        }


        public ManageController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //
        // GET: /Account/Index
        [HttpGet]
        public async Task<ActionResult> Index(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "رمزعبور شما تغییر پیدا کرد."
                : message == ManageMessageId.SetPasswordSuccess ? "رمزعبور تنظیم شد."
                : message == ManageMessageId.SetTwoFactorSuccess ? "ورود دومرحله ای تنظیم شد"
                : message == ManageMessageId.Error ? "خطای ناشناخته رخ داد."
                : message == ManageMessageId.AddPhoneSuccess ? "شماره تلفن شما اضافه شد."
                : message == ManageMessageId.RemovePhoneSuccess ? "شماره تلفن حذف شد."
                : "";

            var userId = User.Identity.GetUserId();
            var model = new IndexViewModel
            {
                HasPassword = HasPassword(),
                PhoneNumber = await UserManager.GetPhoneNumberAsync(userId),
                TwoFactor = await UserManager.GetTwoFactorEnabledAsync(userId),
                Logins = await UserManager.GetLoginsAsync(userId),
                BrowserRemembered = await AuthenticationManager.TwoFactorBrowserRememberedAsync(userId)
            };
            return View(model);
        }

        //
        // GET: /Account/RemoveLogin
        [HttpGet]
        public ActionResult RemoveLogin()
        {
            var linkedAccounts = UserManager.GetLogins(User.Identity.GetUserId());
            ViewBag.ShowRemoveButton = HasPassword() || linkedAccounts.Count > 1;
            return View(linkedAccounts);
        }

        //
        // POST: /Manage/RemoveLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemoveLogin(string loginProvider, string providerKey)
        {
            ManageMessageId? message;
            var userId = User.Identity.GetUserId();
            var result = await UserManager.RemoveLoginAsync(userId, new UserLoginInfo(loginProvider, providerKey));
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(userId);
                if (user != null)
                {
                    await SignInAsync(user, isPersistent: false);
                }
                message = ManageMessageId.RemoveLoginSuccess;
            }
            else
            {
                message = ManageMessageId.Error;
            }
            return RedirectToAction("ManageLogins", new { Message = message });
        }

        //
        // GET: /Account/AddPhoneNumber
        [HttpGet]
        public ActionResult AddPhoneNumber()
        {
            return View();
        }

        //
        // POST: /Account/AddPhoneNumber
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddPhoneNumber(AddPhoneNumberViewModel model)
        {

            if (model.Number.Substring(0, 2) == "09")
            {
                model.Number = "+989" + model.Number.Substring(2, model.Number.Length - 2);
            }

            db = new ApplicationDbContext();
            if (!ModelState.IsValid || db.Users.Where(p => p.PhoneNumber.ToString() == model.Number).Count() > 0)
            {
                if (db.Users.Where(p => p.PhoneNumber.ToString() == model.Number).Count() > 0)
                    ModelState.AddModelError("", "شماره تلفن وارد شده تکراری می باشد");

                return View(model);
            }
            // Generate the token and send it

            var code = await UserManager.GenerateChangePhoneNumberTokenAsync(User.Identity.GetUserId(), model.Number);
            if (UserManager.SmsService != null)
            {
                var message = new IdentityMessage
                {
                    Destination = model.Number,
                    Body = "کد امنیتی جهت تأیید در سامانه معاملات آنلاین طلا:" + "\n" + code
                };
                await UserManager.SmsService.SendAsync(message);
            }
            return RedirectToAction("VerifyPhoneNumber", new { PhoneNumber = model.Number });
        }

        //
        // POST: /Manage/RememberBrowser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RememberBrowser()
        {
            var rememberBrowserIdentity = AuthenticationManager.CreateTwoFactorRememberBrowserIdentity(User.Identity.GetUserId());
            AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = true }, rememberBrowserIdentity);
            return RedirectToAction("Index", "Manage");
        }

        //
        // POST: /Manage/ForgetBrowser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ForgetBrowser()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);
            return RedirectToAction("Index", "Manage");
        }

        //
        // POST: /Manage/EnableTFA
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EnableTFA()
        {
            var userId = User.Identity.GetUserId();
            await UserManager.SetTwoFactorEnabledAsync(userId, true);
            var user = await UserManager.FindByIdAsync(userId);
            if (user != null)
            {
                await SignInAsync(user, isPersistent: false);
            }
            return RedirectToAction("Index", "Manage");
        }

        //
        // POST: /Manage/DisableTFA
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DisableTFA()
        {
            var userId = User.Identity.GetUserId();
            await UserManager.SetTwoFactorEnabledAsync(userId, false);
            var user = await UserManager.FindByIdAsync(userId);
            if (user != null)
            {
                await SignInAsync(user, isPersistent: false);
            }
            return RedirectToAction("Index", "Manage");
        }

        //
        // GET: /Account/VerifyPhoneNumber
        [HttpGet]
        public async Task<ActionResult> VerifyPhoneNumber(string phoneNumber)
        {
            // This code allows you exercise the flow without actually sending codes
            // For production use please register a SMS provider in IdentityConfig and generate a code here.
            var code = await UserManager.GenerateChangePhoneNumberTokenAsync(User.Identity.GetUserId(), phoneNumber);
            ViewBag.Status = "For DEMO purposes only, the current code is " + code;
            return phoneNumber == null ? View("Error") : View(new VerifyPhoneNumberViewModel { PhoneNumber = phoneNumber });
        }

        //
        // POST: /Account/VerifyPhoneNumber
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyPhoneNumber(VerifyPhoneNumberViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var userId = User.Identity.GetUserId();
            var result = await UserManager.ChangePhoneNumberAsync(userId, model.PhoneNumber, model.Code);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(userId);
                if (user != null)
                {
                    await SignInAsync(user, isPersistent: false);
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.AddPhoneSuccess });
            }
            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "کد وارد شده صحیح نمی باشد");
            return View(model);
        }

        //
        // GET: /Account/RemovePhoneNumber
        [HttpGet]
        public async Task<ActionResult> RemovePhoneNumber()
        {
            var userId = User.Identity.GetUserId();
            var result = await UserManager.SetPhoneNumberAsync(userId, null);
            if (!result.Succeeded)
            {
                return RedirectToAction("Index", new { Message = ManageMessageId.Error });
            }
            var user = await UserManager.FindByIdAsync(userId);
            if (user != null)
            {
                await SignInAsync(user, isPersistent: false);
            }
            return RedirectToAction("Index", new { Message = ManageMessageId.RemovePhoneSuccess });
        }

        //
        // GET: /Manage/ChangePassword
        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Account/Manage
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var userId = User.Identity.GetUserId();
            var result = await UserManager.ChangePasswordAsync(userId, model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(userId);
                if (user != null)
                {
                    await SignInAsync(user, isPersistent: false);
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            }
            AddErrors(result);
            return View(model);
        }

        //
        // GET: /Manage/SetPassword
        [HttpGet]
        public ActionResult SetPassword()
        {
            return View();
        }

        //
        // POST: /Manage/SetPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SetPassword(SetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                var result = await UserManager.AddPasswordAsync(userId, model.NewPassword);
                if (result.Succeeded)
                {
                    var user = await UserManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        await SignInAsync(user, isPersistent: false);
                    }
                    return RedirectToAction("Index", new { Message = ManageMessageId.SetPasswordSuccess });
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/Manage
        public async Task<ActionResult> ManageLogins(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
                : message == ManageMessageId.Error ? "An error has occurred."
                : "";
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            if (user == null)
            {
                return View("Error");
            }
            var userLogins = await UserManager.GetLoginsAsync(userId);
            var otherLogins = AuthenticationManager.GetExternalAuthenticationTypes().Where(auth => userLogins.All(ul => auth.AuthenticationType != ul.LoginProvider)).ToList();
            ViewBag.ShowRemoveButton = user.PasswordHash != null || userLogins.Count > 1;
            return View(new ManageLoginsViewModel
            {
                CurrentLogins = userLogins,
                OtherLogins = otherLogins
            });
        }

        //
        // POST: /Manage/LinkLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LinkLogin(string provider)
        {
            // Request a redirect to the external login provider to link a login for the current user
            return new AccountController.ChallengeResult(provider, Url.Action("LinkLoginCallback", "Manage"), User.Identity.GetUserId());
        }

        //
        // GET: /Manage/LinkLoginCallback
        public async Task<ActionResult> LinkLoginCallback()
        {
            var userId = User.Identity.GetUserId();
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync(XsrfKey, userId);
            if (loginInfo == null)
            {
                return RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
            }
            var result = await UserManager.AddLoginAsync(userId, loginInfo.Login);
            return result.Succeeded ? RedirectToAction("ManageLogins") : RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie, DefaultAuthenticationTypes.TwoFactorCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = isPersistent }, await user.GenerateUserIdentityAsync(UserManager));
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

        private bool HasPhoneNumber()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PhoneNumber != null;
            }
            return false;
        }

        public enum ManageMessageId
        {
            AddPhoneSuccess,
            ChangePasswordSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            RemovePhoneSuccess,
            Error
        }

        #endregion
    }
}