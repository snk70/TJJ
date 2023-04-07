using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TJJ.DataViewModels.RequestMoney;
using TJJ.Models;

namespace TJJ.Services
{
    public class SellRequestRepository : IRequestMoneyRepository
    {
        IdentitySample.Models.ApplicationDbContext DB;
        public SellRequestRepository(IdentitySample.Models.ApplicationDbContext My_DB)
        {
            this.DB = My_DB;
        }


        public tbl_Request_Money Get_Req_BY_ID(int Req_ID)
        {
            var tb_inf = DB.Requests_tbl.Find(Req_ID);
            Save_Change_DB();
            return tb_inf;
        }

        public IEnumerable<tbl_Request_Money> Get_User_Reqs_All(string U_ID)
        {
            var tb_inf = DB.Requests_tbl.Where(p => p.Id==U_ID);
            Save_Change_DB();
            return tb_inf;
        }

        public bool Insert_User_New_Req(tbl_Request_Money Req_Info)
        {
            try
            {
                DB.Requests_tbl.Add(Req_Info);
                Save_Change_DB();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update_Req_Sell(tbl_Request_Money Req_Info)
        {
            try
            {
                DB.Entry(Req_Info).State = System.Data.Entity.EntityState.Modified;
                Save_Change_DB();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete_Req_Sell_BY_ID(int Req_ID)
        {
            try
            {
                var tb_inf = DB.Requests_tbl.Find(Req_ID);
                DB.Requests_tbl.Remove(tb_inf);
                Save_Change_DB();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Dispose()
        {
            try
            {
                DB.SaveChanges();
                DB.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Save_Change_DB()
        {
            DB.SaveChanges();
            return true;
        }


    }
}