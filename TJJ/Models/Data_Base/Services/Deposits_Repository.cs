using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentitySample.Models;
using System.Data.Entity;
using TJJ.Models;

namespace TJJ.Services
{
    public class Deposits_Repository : IDepositsRepository
    {

        ApplicationDbContext db;

        public Deposits_Repository(ApplicationDbContext DB)
        {
            this.db = DB;
        }

        public IEnumerable<TJJ.Models.tbl_Deposits> GetAllDeposits()
        {
            return db.Deposits_tbl;
        }

        public tbl_Deposits Get_Deposit_BY_ID(int Deposit_ID)
        {
            return db.Deposits_tbl.Find(Deposit_ID);
        }

        public bool Delete_Deposit(tbl_Deposits Deposit_Info)
        {
            try
            {
                db.Deposits_tbl.Remove(Deposit_Info);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete_Deposit_BY_ID(int Deposit_ID)
        {
            try
            {
                return Delete_Deposit(db.Deposits_tbl.Find(Deposit_ID));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Insert_Deposit(tbl_Deposits Deposit_info)
        {
            try
            {
                db.Deposits_tbl.Add(Deposit_info);
                //db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update_Deposit(tbl_Deposits Deposit_info)
        {
            try
            {
                db.Entry(Deposit_info).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Dispos_db()
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
    }
}
