using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IdentitySample.Models;
using TJJ.Areas.Admin.DataViewModel;
using System.Threading.Tasks;

namespace TJJ.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ManageUsersController : Controller
    {
        private ApplicationDbContext db;

        [Route("Admin/Account/LogOff")]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {

            const string keep_link_text = "&%!@=+&%%$#";
            string domain_address = Request.Url.AbsoluteUri.Replace("://", keep_link_text).Replace(Request.Url.PathAndQuery, "").Replace(keep_link_text, "://");

            //return RedirectToAction("Index", "Admin/ManageUsers");
            RemotePostData.RemotePost rmt = new RemotePostData.RemotePost(domain_address + "/Account/LogOff");
            rmt.Add("__RequestVerificationToken", Request.Form["__RequestVerificationToken"].ToString());
            rmt.Post();
            return RedirectToAction("LogOff", "Account");
        }


        // GET: Admin/ManageUsers
        public ActionResult Index()
        {
            db = new ApplicationDbContext();
            var AllUsers = db.Users.ToList();

            List<ManageUsersViewModel> AllUsersViewModel = new List<ManageUsersViewModel>();
            foreach (var item in AllUsers)
            {
                ManageUsersViewModel UserViewModel = new ManageUsersViewModel()
                {
                    birthday_date = item.birthday_date,
                    code_melli = item.code_melli,
                    Email = item.Email,
                    EmailConfirmed = item.EmailConfirmed,
                    fname = item.fname,
                    gold_charge = item.gold_charge,
                    rial_charge=item.rial_charge,
                    ID = item.Id,
                    inviter_code = item.inviter_code,
                    lname = item.lname,
                    Password = item.PasswordHash,
                    PhoneConfirmed = item.PhoneNumberConfirmed,
                    PhoneNumber = item.PhoneNumber,
                    RegisterDateTime = item.register_date_time,
                    UserName = item.UserName,
                    user_type = item.user_type,
                    confirm_Account_Bank=item.confirm_Account_Bank,
                    dest_Account_Number=item.dest_Account_Number,
                    dest_Card_Number=item.dest_Card_Number
                };
                AllUsersViewModel.Add(UserViewModel);
            }
            db.Dispose();

            return View(AllUsersViewModel);
        }

        // GET: Admin/ManageUsers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            db = new ApplicationDbContext();
            var item = db.Users.SingleOrDefault(p => p.Id == id);

            ManageUsersViewModel UserViewModel = new ManageUsersViewModel()
            {
                birthday_date = item.birthday_date,
                code_melli = item.code_melli,
                Email = item.Email,
                EmailConfirmed = item.EmailConfirmed,
                fname = item.fname,
                gold_charge = item.gold_charge,
                ID = item.Id,
                inviter_code = item.inviter_code,
                lname = item.lname,
                Password = item.PasswordHash,
                PhoneConfirmed = item.PhoneNumberConfirmed,
                PhoneNumber = item.PhoneNumber,
                RegisterDateTime = item.register_date_time,
                UserName = item.UserName,
                user_type = item.user_type,
                confirm_Account_Bank=item.confirm_Account_Bank,
                dest_Account_Number=item.dest_Account_Number,
                dest_Card_Number=item.dest_Card_Number
            };
            db.Dispose();
            return PartialView(UserViewModel);
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
                if (wm1.GetResponse().ToLower() == "true")
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }


            return RedirectToAction("Index");
        }


        //Password Reset to: User@1234
        public ActionResult ResetPassword(string id)
        {
            if (id != null && id != "")
            {
                db = new ApplicationDbContext();
                db.Users.SingleOrDefault(p => p.Id == id).PasswordHash = @"ABVcTqyiJY2Zh3ScY+xbGHB+tGQqMoNvGSIdHYQesDgu7f2ws5rv0lz/a3uZ/QtTlg==";
                db.SaveChanges();
                db.Dispose();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Confirm_Email(string id)
        {
            if (id != null && id != "")
            {
                db = new ApplicationDbContext();
                db.Users.SingleOrDefault(p => p.Id == id).EmailConfirmed = true;
                db.SaveChanges();
                db.Dispose();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Deny_Email(string id)
        {
            if (id != null && id != "")
            {
                db = new ApplicationDbContext();
                db.Users.SingleOrDefault(p => p.Id == id).EmailConfirmed = false;
                db.SaveChanges();
                db.Dispose();
            }
            return RedirectToAction("Index");
        }


        public ActionResult Confirm_Phone(string id)
        {
            if (id != null && id != "")
            {
                db = new ApplicationDbContext();
                db.Users.SingleOrDefault(p => p.Id == id).PhoneNumberConfirmed = true; ;
                db.SaveChanges();
                db.Dispose();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Deny_Phone(string id)
        {
            if (id != null && id != "")
            {
                db = new ApplicationDbContext();
                db.Users.SingleOrDefault(p => p.Id == id).PhoneNumberConfirmed = false;
                db.SaveChanges();
                db.Dispose();
            }
            return RedirectToAction("Index");
        }


        public ActionResult pass_bank(string id)
        {
            if (id != null && id != "")
            {
                db = new ApplicationDbContext();
                db.Users.SingleOrDefault(p => p.Id == id).confirm_Account_Bank = true;
                db.SaveChanges();
                db.Dispose();
            }
            return RedirectToAction("Index");
        }

        public ActionResult reject_bank(string id)
        {
            if (id != null && id != "")
            {
                db = new ApplicationDbContext();
                db.Users.SingleOrDefault(p => p.Id == id).confirm_Account_Bank = false;
                db.SaveChanges();
                db.Dispose();
            }
            return RedirectToAction("Index");
        }

    }
}
