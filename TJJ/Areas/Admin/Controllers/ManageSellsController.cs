using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IdentitySample.Models;
using TJJ.Areas.DataViewModel;

namespace TJJ.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ManageSellsController : Controller
    {
        private ApplicationDbContext db;


        // GET: Admin/ManageSells
        public ActionResult Index()
        {

            db = new ApplicationDbContext();
            var AllSells = db.Requests_tbl.ToList();

            List<ManageSellsViewModel> AllSellsViewModel = new List<ManageSellsViewModel>();

            foreach (var item in AllSells)
            {
                ManageSellsViewModel SellsManageViewModel = new ManageSellsViewModel()
                {
                    FullName = item.tbl_Users.fname + " " + item.tbl_Users.lname,
                    Id = item.Id,
                    req_id = item.req_id,
                    req_money_value = item.req_money_value,
                    req_status = item.req_status,
                    sell_date_time = item.sell_date_time,
                    sell_dest_account_number = item.tbl_Users.dest_Account_Number,
                    sell_dest_card_number = item.tbl_Users.dest_Card_Number,
                    //sell_gold_value = item.sell_gold_value,
                    sell_tracking_code = item.sell_tracking_code,
                    sell_user_comment = item.sell_user_comment,
                    confirm_Account_Bank=item.tbl_Users.confirm_Account_Bank
                };
                AllSellsViewModel.Add(SellsManageViewModel);
            }
            db.Dispose();
            return View(AllSellsViewModel);
        }

        // GET: Admin/ManageSells/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            db = new ApplicationDbContext();
            var item = db.Requests_tbl.SingleOrDefault(p => p.req_id == id.Value);

            ManageSellsViewModel SellViewModel = new ManageSellsViewModel()
            {
                FullName = item.tbl_Users.fname + " " + item.tbl_Users.lname,
                Id = item.Id,
                req_id = item.req_id,
                req_money_value = item.req_money_value,
                req_status = item.req_status,
                sell_date_time = item.sell_date_time,
                sell_dest_account_number = item.tbl_Users.dest_Account_Number,
                sell_dest_card_number = item.tbl_Users.dest_Card_Number,
                //sell_gold_value = item.sell_gold_value,
                sell_tracking_code = item.sell_tracking_code,
                sell_user_comment = item.sell_user_comment
            };

            return PartialView(SellViewModel);
        }

        public ActionResult pass(int id)
        {
            db = new ApplicationDbContext();
            var MyReq = db.Requests_tbl.SingleOrDefault(p => p.req_id == id);
            if (MyReq.req_status != 1)
            {
                MyReq.tbl_Users.rial_charge -= MyReq.req_money_value;

                MyReq.req_status = 1;
                db.SaveChanges();
            }
            db.Dispose();
            return RedirectToAction("Index");
        }

        public ActionResult reject(int id)
        {
            db = new ApplicationDbContext();
            var MyReq = db.Requests_tbl.SingleOrDefault(p => p.req_id == id);
            if (MyReq.req_status != -1)
            {
                if (MyReq.req_status == 1)
                {
                    MyReq.tbl_Users.rial_charge += MyReq.req_money_value;
                }

                MyReq.req_status = -1;
                db.SaveChanges();
            }
            db.Dispose();
            return RedirectToAction("Index");
        }

        public ActionResult reset(int id)
        {
            db = new ApplicationDbContext();
            var MyReq = db.Requests_tbl.SingleOrDefault(p => p.req_id == id);
            if (MyReq.req_status != 0)
            {
                if (MyReq.req_status == 1)
                {
                    MyReq.tbl_Users.rial_charge += MyReq.req_money_value;
                }

                MyReq.req_status = 0;
                db.SaveChanges();
            }

            db.Dispose();
            return RedirectToAction("Index");
        }

    }
}
