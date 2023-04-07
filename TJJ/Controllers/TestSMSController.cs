using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.Mvc;
using IdentitySample.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace TJJ.Controllers
{
    [Authorize(Roles = "KeyMaster")]

    // GET: TestSMS
    public class TestSMSController : Controller
    {

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



        // GET: /TestSMS/?txt=پیامک تستی&to=09222978852&s=پیامک تست
        public async Task<ActionResult> Index(string txt, string TO, string s = "Tjj Email Test")
        {
            

            IdentitySample.Models.SmsService ss = new IdentitySample.Models.SmsService();
            //es.SendAsync();
            Microsoft.AspNet.Identity.IdentityMessage im = new Microsoft.AspNet.Identity.IdentityMessage();
            im.Body = txt;
            im.Destination = TO;
            //im.Destination = "kordestani_sina@yahoo.com";
            im.Subject = s;

            ViewBag.to = TO;
            ViewBag.s = s;
            ViewBag.txt = txt;

            await ss.SendAsync(im);
            return View();
        }


        public async Task<ActionResult> verify(string u, bool send)
        {
            //http://localhost:2128/TestSMS/verify?u=snk70&send=true

            //var code = await UserManager.GenerateChangePhoneNumberTokenAsync(User.Identity.GetUserId(), phoneNumber);
            //ViewBag.Status = "For DEMO purposes only, the current code is " + code;
            ApplicationDbContext db = new ApplicationDbContext();
            string User_mobile = db.Users.Single(p => p.UserName == u).PhoneNumber;
            db.Dispose();

            var code = await UserManager.GenerateChangePhoneNumberTokenAsync(u, User_mobile);
            var message = new IdentityMessage
            {
                Destination = User_mobile,
                Body = "کد امنیتی شما عبارت است از: " + code
            };

            ViewBag.to = User_mobile;
            ViewBag.txt = message.Body;

            if (send == true)
                await UserManager.SmsService.SendAsync(message);


            return View();

        }

    }
}