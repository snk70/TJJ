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

    public class FullManageUserNotificationsController : Controller
    {
        private TJJ_CMSEntities db = new TJJ_CMSEntities();

        // GET: Admin/FullManageUserNotifications
        public ActionResult Index()
        {
            var tbl_User_Notifications = db.tbl_User_Notifications.Include(t => t.AspNetUser);
            return View(tbl_User_Notifications.ToList());
        }

        // GET: Admin/FullManageUserNotifications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_User_Notifications tbl_User_Notifications = db.tbl_User_Notifications.Find(id);
            if (tbl_User_Notifications == null)
            {
                return HttpNotFound();
            }
            return View(tbl_User_Notifications);
        }

        // GET: Admin/FullManageUserNotifications/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "fname");
            return View();
        }

        // POST: Admin/FullManageUserNotifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ticket_id,Id,not_creation_date_time,not_subject,not_comment,not_text,read_user_not")] tbl_User_Notifications tbl_User_Notifications)
        {
            if (ModelState.IsValid)
            {
                db.tbl_User_Notifications.Add(tbl_User_Notifications);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "fname", tbl_User_Notifications.Id);
            return View(tbl_User_Notifications);
        }

        // GET: Admin/FullManageUserNotifications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_User_Notifications tbl_User_Notifications = db.tbl_User_Notifications.Find(id);
            if (tbl_User_Notifications == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "fname", tbl_User_Notifications.Id);
            return View(tbl_User_Notifications);
        }

        // POST: Admin/FullManageUserNotifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ticket_id,Id,not_creation_date_time,not_subject,not_comment,not_text,read_user_not")] tbl_User_Notifications tbl_User_Notifications)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_User_Notifications).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "fname", tbl_User_Notifications.Id);
            return View(tbl_User_Notifications);
        }

        // GET: Admin/FullManageUserNotifications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_User_Notifications tbl_User_Notifications = db.tbl_User_Notifications.Find(id);
            if (tbl_User_Notifications == null)
            {
                return HttpNotFound();
            }
            return View(tbl_User_Notifications);
        }

        // POST: Admin/FullManageUserNotifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_User_Notifications tbl_User_Notifications = db.tbl_User_Notifications.Find(id);
            db.tbl_User_Notifications.Remove(tbl_User_Notifications);
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
