using IdentitySample.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;

namespace IdentitySample.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public AccountController()
        {
        }

        [Authorize]
        [HttpPost]
        public void Select_User_Daboard_Them(string id)
        {
            //System.Web.HttpCookieCollection cks = new HttpCookieCollection();

            HttpCookie ck = new HttpCookie("user_dashboard_selected_them", id);
            ck.Expires = System.DateTime.Now.AddDays(30);
            Response.Cookies.Remove(ck.Name);
            Response.Cookies.Set(ck);
            Response.Cookies[ck.Name].Value = id;
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
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
        // GET: /Account/Login
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("index", "home");
            else
            {
                ViewBag.ReturnUrl = returnUrl;
                return View();
            }
        }

        private ApplicationSignInManager _signInManager;

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set { _signInManager = value; }
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doen't count login failures towards lockout only two factor authentication
            // To enable password failures to trigger lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "کاربری با مشخصات وارد شده یافت نشد");
                    return View(model);
            }
        }

        //
        // GET: /Account/VerifyCode
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Require that the user has already logged in via username/password or external login
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            var user = await UserManager.FindByIdAsync(await SignInManager.GetVerifiedUserIdAsync());
            if (user != null)
            {
                ViewBag.Status = "For DEMO purposes the current " + provider + " code is: " + await UserManager.GenerateTwoFactorTokenAsync(user.Id, provider);
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent: model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid code.");
                    return View(model);
            }
        }

        //
        // GET: /Account/Register
        [HttpGet]
        
        [AllowAnonymous]
        public ActionResult Register()
        {
            if (User.Identity.Name !=null && User.Identity.Name !="")
            {
                return RedirectToAction("Index", "Manage");
            }
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult go_to_index_home()
        {
            return RedirectToAction("Index", "Home");
        }

        ApplicationDbContext db = new ApplicationDbContext();
        TJJ.IUsersRepository UsersRepository;
        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {

            UsersRepository = new TJJ.Services.Users_Repository(db);

            if (model.UserName == "" || model.UserName == null)
                model.UserName = model.Email;

            if (model.inviter_code == "" || model.inviter_code == null)
                model.inviter_code = "0";

            var user = new ApplicationUser { UserName = model.UserName, Email = model.Email, fname = model.fname, lname = model.lname, code_melli = model.code_melli, birthday_date = model.birthday_date, inviter_code = model.inviter_code, PhoneNumber = "", register_date_time = System.DateTime.Now };
            bool is_new_us = UsersRepository.Is_User_New(user);

            if (ModelState.IsValid && is_new_us && model.read_terms)
            {
                user.PhoneNumber = null;
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //var s_code = await UserManager.GenerateChangePhoneNumberTokenAsync(User.Identity.Name, "09222978852");

                    /////////////////
                    var code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);//جهت کد تأیید ایمیل
                    var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    await UserManager.SendEmailAsync(user.Id, "تأیید ایمیل حساب کاربری", "لطفا برای تأیید کردن ایمیل حساب کاربری خود در سایت معامله آنلاین طلا، روی لینک زیر کلیک کلید، در صورت عدم داشتن قابلیت کلیک لینک، متن لینک را کپی و در آدرس بار مرورگر خود پیست نمایید.<br><br><p>&ensp;</p>: <a href=\"" + callbackUrl + "\">" + callbackUrl + "</a><br><br>");
                    //ViewBag.Link = callbackUrl;
                    ViewBag.user_name = user.fname + " " + user.lname;
                    return View("DisplayEmail");
                }

                List<string> Errs = new List<string>();
                foreach (var item in result.Errors)
                {
                    if (item.IndexOf("Passwords must have") != -1)
                    {
                        ModelState.AddModelError("","رمزعبور باید شامل عدد، حرف بزرگ و کوچک لاتین و همینطور کاراکتر خاص باشد؛"+" مانند: "+"123456#Abcd");
                    }else
                    {
                        ModelState.AddModelError("", item);
                    }
                }
            }
            else if (!model.read_terms)
            {
                IdentityResult ires = new IdentityResult(new string[] { "شما گزینه موافقت با قوانین و مقررات را فعال نکردید." });
                AddErrors(ires);
            }
            IdentityResult rs = new IdentityResult(UsersRepository.Is_User_New(user.code_melli, user.PhoneNumber, user.Email, user.UserName));
            AddErrors(rs);

            // If we got this far, something failed, redisplay form
            UsersRepository.Disposi_db();
            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<bool> Send_Verify_Email(string userId)
        {
            try
            {
                var code = await UserManager.GenerateEmailConfirmationTokenAsync(userId);//جهت کد تأیید ایمیل
                var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = userId, code = code }, protocol: Request.Url.Scheme);
                await UserManager.SendEmailAsync(userId, "تأیید ایمیل حساب کاربری", "لطفا برای تأیید کردن ایمیل حساب کاربری خود در سایت معامله آنلاین طلا، روی لینک زیر کلیک کلید، در صورت عدم داشتن قابلیت کلیک لینک، متن لینک را کپی و در آدرس بار مرورگر خود پیست نمایید.<br><br><p>&ensp;</p>: <a href=\"" + callbackUrl + "\">" + callbackUrl + "</a><br><br>");

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
            //return RedirectToAction(ReturnActionName,ReturnController);
        }

        //
        // GET: /Account/ConfirmEmail
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            UsersRepository = new TJJ.Services.Users_Repository(db);

            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            var user = UsersRepository.Get_User_BY_ID(userId);
            UsersRepository.Disposi_db();

            return View(result.Succeeded ? "ConfirmEmail" : "Error", user);
        }

        //
        // GET: /Account/ForgotPassword
        [HttpGet]
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {

            if (ModelState.IsValid)
            {
                UsersRepository = new TJJ.Services.Users_Repository(db);
                var user = await UsersRepository.Forget_Login_Info(model.Email);
                List<string> err = new List<string>();


                if (user != null)
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    var code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                    var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);

                    if (user.Email != null && user.EmailConfirmed)
                    {
                        await UserManager.SendEmailAsync(user.Id, "بازنشانی اطلاعات ورود به سامانه TJJ", "نام کاربری شما جهت ورود به سامانه: " + user.UserName + "<br> <br> <br>" + "لطفا جهت بازنشانی رمز عبور خود در سامانه معاملات آنلاین طلا، این لینک را در مرورگر اینترنتی خود باز کنید:: <a href=\"" + callbackUrl + "\">" + callbackUrl + "</a>");
                    }
                    else
                    {
                        IdentityResult rs = new IdentityResult(new string[] { "شما ایمیل خود را تأیید نکرده اید" });
                        AddErrors(rs);
                        err.Add(rs.Errors.ToList()[0]);
                    }

                    if (user.PhoneNumber != null && user.PhoneNumberConfirmed)
                    {
                        await UserManager.SendSmsAsync(user.Id, "جهت بازیابی اطلاعات ورود به سامانه، لینک زیر را در مروگر اینترنتی باز کنید:" + "\n" + callbackUrl);
                    }
                    else
                    {
                        IdentityResult rs = new IdentityResult(new string[] { "شما شماره موبایل خود را تأیید نکرده اید" });
                        AddErrors(rs);
                        err.Add(rs.Errors.ToList()[0]);
                    }

                    ViewBag.errors = err;
                    ViewBag.user_info = new string[] { "نام کاربری: " + user.UserName, "ایمیل: " + user.Email, "شماره موبایل: " + user.PhoneNumber };

                }
                else
                {
                    IdentityResult rs_err = new IdentityResult(new string[] { "کاربری یافت نشد؛ اگر در سامانه ثبت نام نکرده اید، لطفا ثبت نام کنید در در غیر اینصورت با پشتیبانی سایت تماس حاصل فرمایید." });
                    AddErrors(rs_err);
                    return View();
                }


                //ViewBag.Link = callbackUrl;
                return View("ForgotPasswordConfirmation");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [HttpGet]
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [HttpGet]
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [HttpGet]
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/SendCode
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Generate the token and send it
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        //
        // GET: /Account/ExternalLoginCallback
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl });
                case SignInStatus.Failure:
                default:
                    // If the user does not have an account, then prompt the user to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        //[Route("Admin/Account/LogOff")]
        //[RouteArea(areaName:"",AreaPrefix ="")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login", "Account");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [HttpGet]
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
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

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}