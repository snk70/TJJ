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

namespace TJJ.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]

    public class ManageTicketsController : Controller
    {
        private ApplicationDbContext db;
        // GET: Admin/ManageTickets
        public ActionResult Index()
        {
            db = new ApplicationDbContext();
            var AllTickets = db.Tickets_tbl.ToList();

            List<ManageTicketsViewModel> AllTicketViewModel = new List<ManageTicketsViewModel>();
            foreach (var item in AllTickets)
            {
                ManageTicketsViewModel TicketViewModel = new ManageTicketsViewModel()
                {
                    Id = item.Id,
                    read_ticket = item.read_ticket,
                    ticket_answer_id = item.ticket_answer_id,
                    ticket_date_time = item.ticket_date_time,
                    ticket_desc = item.ticket_desc,
                    ticket_id = item.ticket_id,
                    ticket_subject = item.ticket_subject,
                    FullName = item.tbl_Users.fname + " " + item.tbl_Users.lname
                };
                AllTicketViewModel.Add(TicketViewModel);
            }
            db.Dispose();

            return View(AllTicketViewModel);
        }

        [HttpPost]
        public ActionResult SendTicket(ManageTicketsViewModel SendTicketViewModel)
        {
            if (SendTicketViewModel == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TJJ.Models.tbl_Tickets NewTicket = new TJJ.Models.tbl_Tickets()
            {
                Id = SendTicketViewModel.Id,
                read_ticket = false,
                ticket_answer_id = SendTicketViewModel.ticket_answer_id,
                ticket_date_time = DateTime.Now,
                ticket_desc = SendTicketViewModel.ticket_desc,
                ticket_subject = SendTicketViewModel.ticket_subject,
            };
            db = new ApplicationDbContext();
            db.Tickets_tbl.Add(NewTicket);
            db.SaveChanges();
            db.Dispose();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SendTicket(string userid, int ticketid)
        {
            if (userid != null && userid != "" && ticketid > -1)
            {
                db = new ApplicationDbContext();

                if (ticketid == 0)
                {
                    var item = db.Users.SingleOrDefault(p => p.Id == userid);

                    ManageTicketsViewModel TicketViewModel = new ManageTicketsViewModel()
                    {
                        Id = userid,
                        ticket_answer_id = ticketid,
                        FullName = item.fname + " " + item.lname,

                    };
                    return View(TicketViewModel);
                }
                else
                {
                    var item = db.Tickets_tbl.SingleOrDefault(p => p.ticket_id == ticketid);

                    ManageTicketsViewModel TicketViewModel = new ManageTicketsViewModel()
                    {
                        Id = userid,
                        ticket_answer_id = ticketid,
                        FullName = item.tbl_Users.fname + " " + item.tbl_Users.lname,

                    };
                    return View(TicketViewModel);
                }


            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }


        // GET: Admin/ManageTickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            db = new ApplicationDbContext();

            var item = db.Tickets_tbl.SingleOrDefault(p => p.ticket_id == id.Value);
            ManageTicketsViewModel TicketViewModel = new ManageTicketsViewModel()
            {
                FullName = item.tbl_Users.fname + " " + item.tbl_Users.lname,
                Id = item.Id,
                read_ticket = item.read_ticket,
                ticket_answer_id = item.ticket_answer_id,
                ticket_date_time = item.ticket_date_time,
                ticket_desc = item.ticket_desc,
                ticket_id = item.ticket_id,
                ticket_subject = item.ticket_subject
            };
            db.Dispose();

            return PartialView(TicketViewModel);
        }

        // GET: Admin/ManageTickets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ManageTickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ticket_id,Id,ticket_answer_id,ticket_date_time,ticket_subject,ticket_desc,read_ticket")] ManageTicketsViewModel manageTicketsViewModel)
        {
            if (ModelState.IsValid)
            {
                //db.ManageTicketsViewModels.Add(manageTicketsViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(manageTicketsViewModel);
        }

        // GET: Admin/ManageTickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //ManageTicketsViewModel manageTicketsViewModel = db.ManageTicketsViewModels.Find(id);
            //if (manageTicketsViewModel == null)
            //{
            //return HttpNotFound();
            //}
            return View();
        }

        // POST: Admin/ManageTickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ticket_id,Id,ticket_answer_id,ticket_date_time,ticket_subject,ticket_desc,read_ticket")] ManageTicketsViewModel manageTicketsViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manageTicketsViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(manageTicketsViewModel);
        }

        // GET: Admin/ManageTickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //ManageTicketsViewModel manageTicketsViewModel = db.ManageTicketsViewModels.Find(id);
            //if (manageTicketsViewModel == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }

        // POST: Admin/ManageTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //ManageTicketsViewModel manageTicketsViewModel = db.ManageTicketsViewModels.Find(id);
            //db.ManageTicketsViewModels.Remove(manageTicketsViewModel);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
