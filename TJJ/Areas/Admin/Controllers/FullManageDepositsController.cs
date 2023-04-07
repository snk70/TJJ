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
    [Authorize(Roles ="KeyMaster")]
    public class FullManageDepositsController : Controller
    {
        private TJJ_CMSEntities db = new TJJ_CMSEntities();

        // GET: Admin/FullManageDeposits
        public ActionResult Index()
        {
            var tbl_Deposits = db.tbl_Deposits.Include(t => t.AspNetUser);
            return View(tbl_Deposits.ToList());
        }

        // GET: Admin/FullManageDeposits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Deposits tbl_Deposits = db.tbl_Deposits.Find(id);
            if (tbl_Deposits == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Deposits);
        }

        // GET: Admin/FullManageDeposits/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "fname");
            return View();
        }

        // POST: Admin/FullManageDeposits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "deposit_id,Id,deposit_status,charge_gold_value,deposit_money_value,deposit_date_time,deposit_tracking_code,deposit_dest_account_number,deposit_img,deposit_comment")] tbl_Deposits tbl_Deposits)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Deposits.Add(tbl_Deposits);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "fname", tbl_Deposits.Id);
            return View(tbl_Deposits);
        }

        // GET: Admin/FullManageDeposits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Deposits tbl_Deposits = db.tbl_Deposits.Find(id);
            if (tbl_Deposits == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "fname", tbl_Deposits.Id);
            return View(tbl_Deposits);
        }

        // POST: Admin/FullManageDeposits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "deposit_id,Id,deposit_status,charge_gold_value,deposit_money_value,deposit_date_time,deposit_tracking_code,deposit_dest_account_number,deposit_img,deposit_comment")] tbl_Deposits tbl_Deposits)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Deposits).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "fname", tbl_Deposits.Id);
            return View(tbl_Deposits);
        }

        // GET: Admin/FullManageDeposits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Deposits tbl_Deposits = db.tbl_Deposits.Find(id);
            if (tbl_Deposits == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Deposits);
        }

        // POST: Admin/FullManageDeposits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Deposits tbl_Deposits = db.tbl_Deposits.Find(id);
            db.tbl_Deposits.Remove(tbl_Deposits);
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
