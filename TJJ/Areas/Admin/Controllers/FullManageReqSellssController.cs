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
    public class FullManageReqSellssController : Controller
    {
        private TJJ_CMSEntities db = new TJJ_CMSEntities();

        // GET: Admin/FullManageReqSellss
        public ActionResult Index()
        {
            var tbl_Request_Money = db.tbl_Request_Money.Include(t => t.AspNetUser);
            return View(tbl_Request_Money.ToList());
        }

        // GET: Admin/FullManageReqSellss/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Request_Money tbl_Request_Money = db.tbl_Request_Money.Find(id);
            if (tbl_Request_Money == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Request_Money);
        }

        // GET: Admin/FullManageReqSellss/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "fname");
            return View();
        }

        // POST: Admin/FullManageReqSellss/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "req_id,Id,req_status,sell_gold_value,req_money_value,sell_date_time,sell_tracking_code,sell_dest_account_number,sell_img,sell_user_comment,sell_admin_comment")] tbl_Request_Money tbl_Request_Money)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Request_Money.Add(tbl_Request_Money);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "fname", tbl_Request_Money.Id);
            return View(tbl_Request_Money);
        }

        // GET: Admin/FullManageReqSellss/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Request_Money tbl_Request_Money = db.tbl_Request_Money.Find(id);
            if (tbl_Request_Money == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "fname", tbl_Request_Money.Id);
            return View(tbl_Request_Money);
        }

        // POST: Admin/FullManageReqSellss/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "req_id,Id,req_status,sell_gold_value,req_money_value,sell_date_time,sell_tracking_code,sell_dest_account_number,sell_img,sell_user_comment,sell_admin_comment")] tbl_Request_Money tbl_Request_Money)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Request_Money).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "fname", tbl_Request_Money.Id);
            return View(tbl_Request_Money);
        }

        // GET: Admin/FullManageReqSellss/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Request_Money tbl_Request_Money = db.tbl_Request_Money.Find(id);
            if (tbl_Request_Money == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Request_Money);
        }

        // POST: Admin/FullManageReqSellss/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Request_Money tbl_Request_Money = db.tbl_Request_Money.Find(id);
            db.tbl_Request_Money.Remove(tbl_Request_Money);
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
