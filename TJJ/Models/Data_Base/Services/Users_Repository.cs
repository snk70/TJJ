using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using IdentitySample.Models;

namespace TJJ.Services
{
    public class Users_Repository : IUsersRepository
    {
        ApplicationDbContext db;

        public Users_Repository(ApplicationDbContext DB)
        {
            this.db = DB;
        }

        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            return db.Users;
        }

        public ApplicationUser Get_User_BY_ID(string User_ID)
        {
            return db.Users.Find(User_ID);
        }

        public ApplicationUser Get_User_BY_UserName(string User_Name)
        {
            return db.Users.Single(p => p.UserName == User_Name);
        }

        public bool Delete_User(ApplicationUser User_Info)
        {
            try
            {
                db.Users.Remove(User_Info);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete_User_BY_ID(string User_ID)
        {
            ApplicationUser tbs = db.Users.Find(User_ID);
            return Delete_User(tbs);
        }

        public bool Delete_User_BY_UserName(string User_Name)
        {
            ApplicationUser tbs = db.Users.Single(p => p.UserName == User_Name);
            return Delete_User_BY_ID(tbs.Id);
        }

        public bool Insert_User(ApplicationUser user_info)
        {
            try
            {
                db.Users.Add(user_info);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update_User(ApplicationUser user_info)
        {
            try
            {
                //Old Method:
                /*  var db_tbs = db.Users_tbl.Find(user_info.user_id);
                  db_tbs = user_info;
                  db.SaveChanges();*/

                //New Method:
                db.Entry(user_info).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Disposi_db()
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

        public bool Is_User_New(ApplicationUser User_Info)
        {
            //int cnt = db.Users.Count(p => p.UserName == User_Info.UserName | p.Email == User_Info.Email | p.code_melli == User_Info.code_melli | p.PhoneNumber == User_Info.PhoneNumber);
            var app_us = db.Users.Count(p => p.UserName == User_Info.UserName || p.UserName == User_Info.Email || p.Email == User_Info.Email || p.Email == User_Info.UserName ||p.UserName==User_Info.PhoneNumber ||p.PhoneNumber==User_Info.UserName || p.code_melli == User_Info.code_melli || p.PhoneNumber == User_Info.PhoneNumber);

            if (app_us >0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public string[] Is_User_New(string Code_Meli, string Mobile_Num, string E_mail, string User_Name)
        {
            List<string> Err_List = new List<string>();

            if (Code_Meli != "" && Code_Meli != null)
                if (db.Users.Count(p => p.code_melli == Code_Meli) > 0)
                {
                    Err_List.Add("این کد ملی قبلا در سامانه ثبت شده");
                }

            if (Mobile_Num != "" && Mobile_Num != null)
                if (db.Users.Count(p => p.PhoneNumber == Mobile_Num) > 0)
                {
                    Err_List.Add("این شماره تلفن قبلا در سامانه ثبت شده");
                }

            if (E_mail != "" && E_mail != null)
                if (db.Users.Count(p => p.Email == E_mail) > 0)
                {
                    Err_List.Add("این ایمیل قبلا در سامانه ثبت شده");
                }

            if (User_Name != "" && User_Name != null)
                if (db.Users.Count(p => p.UserName == User_Name) > 0)
                {
                    Err_List.Add("این نام کاربری قبلا در سامانه ثبت شده");
                }

            return Err_List.ToArray();
        }

        public Task<ApplicationUser> Forget_Login_Info(string inf)
        {
            try
            {
                var us_tb = db.Users.SingleOrDefaultAsync(p => p.UserName == inf || p.Email == inf || p.PhoneNumber.ToString() == inf);
                return us_tb;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
