using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TJJ.Models;


namespace TJJ
{
    public interface IDepositsRepository
    {
        IEnumerable<tbl_Deposits> GetAllDeposits();
        
        tbl_Deposits Get_Deposit_BY_ID(int Deposit_ID);

        bool Insert_Deposit(tbl_Deposits user_info);

        bool Update_Deposit(tbl_Deposits user_info);

        bool SaveChanges();

        bool Delete_Deposit_BY_ID(int Deposit_ID);
        bool Delete_Deposit(tbl_Deposits Deposit_Info);

        bool Dispos_db();
    }
}
