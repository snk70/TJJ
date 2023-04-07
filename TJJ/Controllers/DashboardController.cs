using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TJJ.Controllers
{
    [Authorize]

    public class DashboardController : Controller
    {

        IdentitySample.Models.ApplicationDbContext db;
        TJJ.ITicketRepository TicketRepository;
        TJJ.IDepositsRepository DepositsRepository;
        TJJ.INotificationsRepository NotificationsRepository;

        // GET: Dashboard
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Manage");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult SellGoldCharge(TJJ.Data_Base.DataViewModels.SellRequestViewModel SellViewModel)
        {
            db = new IdentitySample.Models.ApplicationDbContext();
            var UserInfo = db.Users.SingleOrDefault(p => p.UserName == User.Identity.Name);

            if (ModelState.IsValid && SellViewModel.sell_gold_value > 0 && SellViewModel.sell_gold_value <= UserInfo.gold_charge)
            {
                UserInfo.gold_charge -= SellViewModel.sell_gold_value;
                UserInfo.rial_charge += Data_Layer.TJJ_Config_Data.GetGoldValueWithDecrease(Data_Layer.TJJ_Config_Data.RequestGoldPriceToRial(SellViewModel.sell_gold_value), 0.01);

                TicketRepository = new TJJ.Services.TicketsRepository(db);
                string MsgTXT = UserInfo.fname + " " + UserInfo.lname + " عزیز؛ فروش طلای خام آنلاین و افزایش شارژ ریالی حساب کاربری شما ثبت شد و با کسر کارمزد مشخص، در حساب کاربری شما اعمال گردید." + "\n \n مشخصات درخواست: \n" + "میزان شارژ ريالی درخواستی: " + SellViewModel.sell_gold_value + " ريال" + "\n" + "میزان شارژ طلای خام کسر شده: " + SellViewModel.sell_gold_value + " گرم" + "\n" + "تاریخ ارسال درخواست: " + Data_Layer.Tjj_Convertors.Get_Date_and_Time(DateTime.Now);
                TicketRepository.Insert_Ticket(new TJJ.Models.tbl_Tickets() { Id = UserInfo.Id, read_ticket = false, ticket_answer_id = 0, ticket_date_time = DateTime.Now, ticket_desc = MsgTXT, ticket_subject = "خرید طلای خام" });
                TicketRepository.SaveChanges();

                NotificationsRepository = new TJJ.Services.Notifications_Repository(db);
                NotificationsRepository.InsertNotification(new Models.tbl_User_Notifications() { Id = UserInfo.Id, not_comment = MsgTXT, not_creation_date_time = DateTime.Now, not_subject = "فروش طلای خام", not_text = MsgTXT, read_user_not = false });
                NotificationsRepository.SaveChanges();

                db.Dispose();

                return RedirectToAction("messages");
            }


            if (SellViewModel.sell_gold_value > UserInfo.gold_charge)
            {
                ModelState.AddModelError("", "میزان گرم وارد شده از شارژ طلای خام شما بیشتر می باشد.");
            }

            if (SellViewModel.sell_gold_value <= 0)
            {
                ModelState.AddModelError("", "مقدار گرم طلای خام وارد شده نامعتبر می باشد");
            }

            return View(SellViewModel);
        }

        [HttpGet]
        public ActionResult SellGoldCharge()
        {
            return View();
        }

        public ActionResult messages()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult buy_gold_charge(TJJ.Data_Base.DataViewModels.InsertBuyGoldChargeViewModel BuyGoldViewModel)
        {
            db = new IdentitySample.Models.ApplicationDbContext();
            var UserInfo = db.Users.SingleOrDefault(p => p.UserName == User.Identity.Name);

            if (ModelState.IsValid && BuyGoldViewModel.charge_rial_value <= UserInfo.rial_charge)
            {
                UserInfo.gold_charge += Data_Layer.TJJ_Config_Data.GetGoldValueWithDecrease(Data_Layer.TJJ_Config_Data.RequestRialToGram(BuyGoldViewModel.charge_rial_value), 0.01);
                UserInfo.rial_charge = UserInfo.rial_charge - BuyGoldViewModel.charge_rial_value;

                TicketRepository = new TJJ.Services.TicketsRepository(db);
                string MsgTXT = UserInfo.fname + " " + UserInfo.lname + " عزیز؛ خرید طلای خام آنلاین و افزایش شارژ طلای خام حساب کاربری شما ثبت شد و با کسر کارمزد مشخص، در حساب کاربری شما اعمال گردید." + "\n \n مشخصات درخواست: \n" + "میزان شارژ طلای خام درخواستی: " + Data_Layer.TJJ_Config_Data.RequestRialToGram(BuyGoldViewModel.charge_rial_value) + " گرم" + "\n" + "مبلغ شارژ ريالی کسر شده: " + Data_Layer.TJJ_Config_Data.GetGoldPriceClear(Data_Layer.TJJ_Config_Data.RequestGoldPriceToRial(Data_Layer.TJJ_Config_Data.RequestRialToGram(BuyGoldViewModel.charge_rial_value)).ToString()) + "\n" + "تاریخ ارسال درخواست: " + Data_Layer.Tjj_Convertors.Get_Date_and_Time(DateTime.Now);
                TicketRepository.Insert_Ticket(new TJJ.Models.tbl_Tickets() { Id = UserInfo.Id, read_ticket = false, ticket_answer_id = 0, ticket_date_time = DateTime.Now, ticket_desc = MsgTXT, ticket_subject = "خرید طلای خام" });
                TicketRepository.SaveChanges();

                NotificationsRepository = new TJJ.Services.Notifications_Repository(db);
                NotificationsRepository.InsertNotification(new Models.tbl_User_Notifications() { Id = UserInfo.Id, not_comment = MsgTXT, not_creation_date_time = DateTime.Now, not_subject = "خرید طلای خام", not_text = MsgTXT, read_user_not = false });
                NotificationsRepository.SaveChanges();

                db.Dispose();

                return RedirectToAction("messages");
            }


            if (BuyGoldViewModel.charge_rial_value > UserInfo.rial_charge)
            {
                ModelState.AddModelError("", "اعتبار شارژ ریالی حساب کاربری شما برای خرید این مقدار طلای خام کافی نمی باشد.");
            }

            if (BuyGoldViewModel.charge_rial_value <= 0)
            {
                ModelState.AddModelError("", "مقدار گرم طلای خام وارد شده نامعتبر می باشد");
            }

            return View(BuyGoldViewModel);
        }

        [HttpGet]
        public ActionResult buy_gold_charge()
        {
            return View();
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deposit(TJJ.Data_Base.DataViewModels.DepositIncreaseRial BuyRequestViewModel, HttpPostedFileBase deposit_img)
        {

            if (ModelState.IsValid && (deposit_img == null || (deposit_img != null && deposit_img.ContentLength <= 1000000)))
            {
                db = new IdentitySample.Models.ApplicationDbContext();
                DepositsRepository = new TJJ.Services.Deposits_Repository(db);

                var UserInfo = TJJ.GetUserInfo.GetLogedInUserInfo(User.Identity.Name, db);

                TJJ.Models.tbl_Deposits NewDeposit = new Models.tbl_Deposits()
                {
                    Id = UserInfo.Id,

                    deposit_comment = BuyRequestViewModel.deposit_comment,
                    deposit_date_time = DateTime.Now,
                    deposit_dest_account_number = BuyRequestViewModel.deposit_dest_account_number,
                    deposit_money_value = BuyRequestViewModel.charge_rial_value,
                    deposit_tracking_code = BuyRequestViewModel.deposit_tracking_code,
                    deposit_status = 0,
                    deposit_img = ""
                };

                #region Upload Image
                if (deposit_img != null)
                {
                    if (deposit_img.ContentLength < 1000000)
                    {
                        //کاربر تصمیم ب آپلود عکس گرفته
                        string str_IMG_File_Name = User.Identity.Name + "_" + Data_Layer.TJJ_Config_Data.Get_Uniq_File_Name(deposit_img.FileName);
                        deposit_img.SaveAs(Server.MapPath(Data_Layer.TJJ_Config_Data.Get_Full_Path_Deposit_File(str_IMG_File_Name)));
                        NewDeposit.deposit_img = str_IMG_File_Name;
                    }
                    else if (deposit_img.ContentLength > 1000000)
                    {
                        NewDeposit.deposit_img = "lg";
                    }
                }
                #endregion

                DepositsRepository.Insert_Deposit(NewDeposit);

                if (!DepositsRepository.SaveChanges())
                {
                    return View(BuyRequestViewModel);
                }

                TicketRepository = new TJJ.Services.TicketsRepository(db);
                string MsgTXT = UserInfo.fname + " " + UserInfo.lname + " عزیز؛ درخواست افزایش شارژ ريالی حساب کاربری شما ثبت شد و پس از بررسی و تأیید پشتیبان سایت، در حساب کاربری شما اعمال می گردد." + "\n \n مشخصات درخواست: \n" + "مبلغ شارژ درخواستی: " + NewDeposit.deposit_money_value + " ريال" + "\n" + "\n" + "تاریخ ارسال درخواست: " + Data_Layer.Tjj_Convertors.Get_Date_and_Time(NewDeposit.deposit_date_time);
                TicketRepository.Insert_Ticket(new TJJ.Models.tbl_Tickets() { Id = UserInfo.Id, read_ticket = false, ticket_answer_id = 0, ticket_date_time = DateTime.Now, ticket_desc = MsgTXT, ticket_subject = "درخواست خرید" });
                TicketRepository.SaveChanges();

                NotificationsRepository = new TJJ.Services.Notifications_Repository(db);
                NotificationsRepository.InsertNotification(new Models.tbl_User_Notifications() { Id = UserInfo.Id, not_comment = MsgTXT, not_creation_date_time = DateTime.Now, not_subject = "خرید طلای خام", not_text = MsgTXT, read_user_not = false });
                NotificationsRepository.SaveChanges();

                DepositsRepository.Dispos_db();

                return RedirectToAction("messages");
            }

            if (deposit_img.ContentLength > 1000000)
            {
                ModelState.AddModelError("", "حجم فایل بارگذاری شده بیش از حد مجاز می باشد(\"حداکثر حجم مجاز 1 مگابایت می‌باشد\")");
            }

            return View(BuyRequestViewModel);
        }

        public ActionResult Deposit()
        {
            return View();
        }


        public void Read_All_Notifications()
        {
            db = new IdentitySample.Models.ApplicationDbContext();
            var UInfo = TJJ.GetUserInfo.GetLogedInUserInfo(User.Identity.Name, db);

            TJJ.INotificationsRepository NotificationsRepository;
            NotificationsRepository = new TJJ.Services.Notifications_Repository(db);

            NotificationsRepository.ReadAllNots(UInfo.Id);
            NotificationsRepository.SaveChanges();
            NotificationsRepository.Dispos();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult SendTicket(TJJ.Data_Base.DataViewModels.InsertTicketViewModel TicketViewModel)
        {
            if (ModelState.IsValid)
            {
                db = new IdentitySample.Models.ApplicationDbContext();
                TicketRepository = new TJJ.Services.TicketsRepository(db);
                var Uid = TJJ.GetUserInfo.GetLogedInUserInfo(User.Identity.Name, db).Id;

                var New_Ticket = new TJJ.Models.tbl_Tickets()
                {
                    Id = Uid,
                    read_ticket = false,
                    ticket_answer_id = -1,
                    ticket_date_time = DateTime.Now,
                    ticket_desc = TicketViewModel.ticket_desc,
                    ticket_subject = TicketViewModel.ticket_subject,
                };

                TicketRepository.Insert_Ticket(New_Ticket);
                TicketRepository.Dispos_DB();

                return RedirectToAction("messages");
            }
            return View(TicketViewModel);
        }

        [HttpGet]
        public ActionResult SendTicket()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Get_Money()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Get_Money(TJJ.Data_Base.DataViewModels.GetMoney GetMoneyViewModel)
        {
            db = new IdentitySample.Models.ApplicationDbContext();
            var GetmoneytUserInfo = db.Users.SingleOrDefault(p => p.UserName == User.Identity.Name);


            if (ModelState.IsValid && GetMoneyViewModel.MoneyValue >= Data_Layer.TJJ_Config_Data.GoldPriceRial && GetmoneytUserInfo.rial_charge >= GetMoneyViewModel.MoneyValue)
            {


                var NewGetMoney = new Models.tbl_Request_Money()
                {
                    Id = GetmoneytUserInfo.Id,
                    req_money_value = GetMoneyViewModel.MoneyValue,
                    req_status = 0,
                    sell_admin_comment = "",
                    sell_date_time = DateTime.Now,
                    sell_user_comment = GetMoneyViewModel.Comments,

                    //sell_gold_value = 0,
                    //sell_img="",
                    //sell_tracking_code="12343",


                };

                db.Requests_tbl.Add(NewGetMoney);

                string MsgTXT = GetmoneytUserInfo.fname + " " + GetmoneytUserInfo.lname + " عزیز؛ درخواست واریز شارژ ريالی حساب کاربری به شماره حساب بانکی شما ثبت شد و پس از بررسی و تأیید پشتیبان سایت، واریز صورت گرفته و تغییرات در حساب کاربری شما اعمال می گردد." + "\n \n مشخصات درخواست: \n" + "مبلغ درخواستی: " + Data_Layer.Tjj_Convertors.GetClearNumber(NewGetMoney.req_money_value.ToString()) + " ريال" + "\n" + "\n" + "تاریخ ارسال درخواست: " + Data_Layer.Tjj_Convertors.Get_Date_and_Time(NewGetMoney.sell_date_time);
                db.Tickets_tbl.Add(new Models.tbl_Tickets() { Id = GetmoneytUserInfo.Id, read_ticket = false, ticket_answer_id = 0, ticket_date_time = DateTime.Now, ticket_desc = MsgTXT, ticket_subject = "درخواست واریز وجه شارژ ريالی" });

                db.SaveChanges();

                return RedirectToAction("messages");
            }
            else if (GetMoneyViewModel.MoneyValue < Data_Layer.TJJ_Config_Data.GoldPriceRial)
            {
                ModelState.AddModelError("", "حداقل مبلغ درخواستی برای واریز به حساب شما، مبلغ معادل یک گرم طلا خام می باشد.");
                return View(GetMoneyViewModel);
            }
            else if (GetMoneyViewModel.MoneyValue > GetmoneytUserInfo.rial_charge)
            {
                ModelState.AddModelError("", "موجودی اعتبار شارژ ریالی شما کافی نمی باشد");
                return View(GetMoneyViewModel);
            }
            else
            {
                ModelState.AddModelError("", "لطفا اطلاعات خواسته شده را وارد نمایید");
                return View(GetMoneyViewModel);
            }
        }


        public string Get_Gold_Price_Value(double GoldValue)
        {
            Data_Layer.TJJ_Config_Data.InitializeTradeValues();
            //return ;
            return Data_Layer.TJJ_Config_Data.GetGoldPriceClear(Data_Layer.TJJ_Config_Data.RequestGoldPriceToRial((float)GoldValue).ToString());
        }


        public string Get_Gold_Gram_Value(string RialValue)
        {

            //return RialValue;

            if (Data_Layer.TJJ_Config_Data.StringIsNumberDouble(RialValue))
            {
                Data_Layer.TJJ_Config_Data.InitializeTradeValues();

                double GoldPrice = double.Parse(Data_Layer.TJJ_Config_Data.GoldPriceRial.ToString());

                return "مبلغ شارژ "+Data_Layer.TJJ_Config_Data.GetGoldPriceClear(RialValue)+" ریال معادل "+(double.Parse(RialValue) / GoldPrice).ToString()+" گرم طلای خام";
            }
            else
            {
                return "مقدار وارد شده معتبر نمیباشد";
            }
        }




    }
}