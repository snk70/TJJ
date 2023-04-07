using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TJJ.Areas.Admin.Models;

namespace TJJ.Areas.Admin.Controllers
{
    [Authorize(Roles = "KeyMaster")]
    public class FullManageTicketsController : Controller
    {
        private TJJ_CMSEntities db = new TJJ_CMSEntities();

        // GET: Admin/FullManageTickets
        public ActionResult Index()
        {
            var tbl_Tickets = db.tbl_Tickets.Include(t => t.AspNetUser);
            return View(tbl_Tickets.ToList());
        }

        // GET: Admin/FullManageTickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Tickets tbl_Tickets = db.tbl_Tickets.Find(id);
            if (tbl_Tickets == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Tickets);
        }

        // GET: Admin/FullManageTickets/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "fname");
            return View();
        }

        // POST: Admin/FullManageTickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ticket_id,Id,ticket_answer_id,ticket_date_time,ticket_subject,ticket_desc,read_ticket")] tbl_Tickets tbl_Tickets)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Tickets.Add(tbl_Tickets);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "fname", tbl_Tickets.Id);
            return View(tbl_Tickets);
        }

        // GET: Admin/FullManageTickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Tickets tbl_Tickets = db.tbl_Tickets.Find(id);
            if (tbl_Tickets == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "fname", tbl_Tickets.Id);
            return View(tbl_Tickets);
        }

        // POST: Admin/FullManageTickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ticket_id,Id,ticket_answer_id,ticket_date_time,ticket_subject,ticket_desc,read_ticket")] tbl_Tickets tbl_Tickets)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Tickets).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "fname", tbl_Tickets.Id);
            return View(tbl_Tickets);
        }

        // GET: Admin/FullManageTickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Tickets tbl_Tickets = db.tbl_Tickets.Find(id);
            if (tbl_Tickets == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Tickets);
        }

        // POST: Admin/FullManageTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Tickets tbl_Tickets = db.tbl_Tickets.Find(id);
            db.tbl_Tickets.Remove(tbl_Tickets);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
