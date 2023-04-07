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

    public class ManageDepositsController : Controller
    {

        private ApplicationDbContext db;


        //public ActionResult TradeStatInitialize()
        //{
        //    GoldRialFilePath = Server.MapPath("~/p.txt");
        //    TradeStateFilePath = Server.MapPath("~/t.txt");

        //    if(System.IO.File.Exists(GoldRialFilePath))
        //    {
        //        Data_Layer.TJJ_Config_Data.GoldPriceRial = float.Parse(System.IO.File.ReadAllText(GoldRialFilePath));
        //    }

        //    if (System.IO.File.Exists(TradeStateFilePath))
        //    {
        //        Data_Layer.TJJ_Config_Data.IsTradeOpen = bool.Parse(System.IO.File.ReadAllText(TradeStateFilePath));
        //    }
        //}
        public ActionResult TradeToggle()
        {
            if(Data_Layer.TJJ_Config_Data.IsTradeOpen)
            {
                Data_Layer.TJJ_Config_Data.IsTradeOpen = false;

            }else
            {
                Data_Layer.TJJ_Config_Data.IsTradeOpen = true;
            }
            return RedirectToAction(actionName:"Index",controllerName: "ManageDeposits");
        }

        public ActionResult SetGoldPrice(string GoldPrice)
        {
            Data_Layer.TJJ_Config_Data.GoldPriceRial = float.Parse(GoldPrice.Replace(",", ""));
            return RedirectToAction(actionName: "Index", controllerName: "ManageDeposits");
        }

        // GET: Admin/ManageDeposits
        public ActionResult Index()
        {
            List<ManageDepositsViewModel> AllDepositsViewModel;


            db = new ApplicationDbContext();

            var AllDeposits = db.Deposits_tbl.ToList();
            AllDepositsViewModel = new List<ManageDepositsViewModel>();

            foreach (var item in AllDeposits)
            {
                string FullName = item.tbl_Users.fname + " " + item.tbl_Users.lname;

                AllDepositsViewModel.Add(new ManageDepositsViewModel()
                {
                    //charge_gold_value = item.charge_gold_value,
                    deposit_comment = item.deposit_comment,
                    deposit_date_time = item.deposit_date_time,
                    deposit_dest_account_number = item.deposit_dest_account_number,
                    deposit_id = item.deposit_id,
                    deposit_img = item.deposit_img,
                    deposit_money_value = item.deposit_money_value,
                    deposit_status = item.deposit_status,
                    deposit_tracking_code = item.deposit_tracking_code,
                    Id = item.Id,
                    UserFullName = FullName
                });
            }
            db.Dispose();
            return View(AllDepositsViewModel);
        }

        // GET: Admin/ManageDeposits/Details/5
        public ActionResult Details(int? id)
        {
            db = new ApplicationDbContext();

            var item = db.Deposits_tbl.SingleOrDefault(p => p.deposit_id == id.Value);

            string FullName = item.tbl_Users.fname + " " + item.tbl_Users.lname;

            ManageDepositsViewModel Deposit1ViewModel = new ManageDepositsViewModel()
            {
                
                deposit_comment = item.deposit_comment,
                deposit_date_time = item.deposit_date_time,
                deposit_dest_account_number = item.deposit_dest_account_number,
                deposit_id = item.deposit_id,
                deposit_img = item.deposit_img,
                deposit_money_value = item.deposit_money_value,
                deposit_status = item.deposit_status,
                deposit_tracking_code = item.deposit_tracking_code,
                Id = item.Id,
                UserFullName = FullName
            };
            db.Dispose();
            return PartialView(Deposit1ViewModel);
        }

        public ActionResult pass(int id)
        {
            db = new ApplicationDbContext();
            var MyDeposit = db.Deposits_tbl.SingleOrDefault(p => p.deposit_id == id);
            if (MyDeposit.deposit_status != 1)
            {
                MyDeposit.tbl_Users.rial_charge += MyDeposit.deposit_money_value;

                MyDeposit.deposit_status = 1;
                db.SaveChanges();
            }
            db.Dispose();
            return RedirectToAction("Index");
        }

        public ActionResult reject(int id)
        {
            db = new ApplicationDbContext();
            var MyDeposit = db.Deposits_tbl.SingleOrDefault(p => p.deposit_id == id);
            if (MyDeposit.deposit_status != -1)
            {
                if (MyDeposit.deposit_status == 1)
                {
                    MyDeposit.tbl_Users.rial_charge -= MyDeposit.deposit_money_value;
                }
                MyDeposit.deposit_status = -1;
                db.SaveChanges();
            }
            db.Dispose();
            return RedirectToAction("Index");
        }

        public ActionResult reset(int id)
        {
            db = new ApplicationDbContext();
            var MyDeposit = db.Deposits_tbl.SingleOrDefault(p => p.deposit_id == id);
            if (MyDeposit.deposit_status != 0)
            {
                if (MyDeposit.deposit_status == 1)
                {
                    MyDeposit.tbl_Users.rial_charge -= MyDeposit.deposit_money_value;
                }

                MyDeposit.deposit_status = 0;
                db.SaveChanges();
            }
            db.Dispose();
            return RedirectToAction("Index");
        }

    }
}
