using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TJJ.Models;

namespace TJJ.Services
{
    public class Notifications_Repository : INotificationsRepository
    {
        IdentitySample.Models.ApplicationDbContext db;
        public Notifications_Repository(IdentitySample.Models.ApplicationDbContext DBC)
        {
            this.db = DBC;
        }

        public IEnumerable<tbl_User_Notifications> GetAllNots(string UserID)
        {
            return db.tbl_User_Notifications.Where(p => p.Id==UserID);
        }

        public IEnumerable<tbl_User_Notifications> GetUnReadNots(string UserID)
        {
            return db.tbl_User_Notifications.Where(p => p.Id==UserID && p.read_user_not==false);
        }

        public bool ReadAllNots(string UserID)
        {
            try
            {
                var AllNots = db.tbl_User_Notifications.Where(p => p.Id == UserID && p.read_user_not == false);
                foreach (var item in AllNots)
                {
                    item.read_user_not = true;
                }
                db.Entry(AllNots).State = System.Data.Entity.EntityState.Modified;
                //SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Dispos()
        {
            try
            {
                db.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SaveChanges()
        {
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool InsertNotification(tbl_User_Notifications NotInfo)
        {
            try
            {
                db.tbl_User_Notifications.Add(NotInfo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}