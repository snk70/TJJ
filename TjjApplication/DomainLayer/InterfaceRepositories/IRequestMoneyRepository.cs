using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TJJ.Models;


namespace TJJ
{
    public interface IRequestMoneyRepository
    {
        TJJ.Models.tbl_Request_Money Get_Req_BY_ID(int Req_ID);
        IEnumerable<TJJ.Models.tbl_Request_Money> Get_User_Reqs_All(string U_ID);
        bool Insert_User_New_Req(TJJ.Models.tbl_Request_Money Req_Info);
        bool Delete_Req_Sell_BY_ID(int Req_ID);
        bool Update_Req_Sell(tbl_Request_Money Req_Info);

        bool Dispose();
        bool Save_Change_DB();
    }
}