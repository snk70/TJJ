using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TJJ.Models;

namespace TJJ
{
    public interface INotificationsRepository
    {
        IEnumerable<tbl_User_Notifications> GetAllNots(string UserID);
        IEnumerable<tbl_User_Notifications> GetUnReadNots(string UserID);
        bool ReadAllNots(string UserID);
        bool InsertNotification(tbl_User_Notifications NotInfo);
        bool SaveChanges();
        bool Dispos();
    }
}