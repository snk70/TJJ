using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TJJ.Models;
using IdentitySample.Models;


namespace TJJ
{
    public interface IUsersRepository
    {
        IEnumerable<ApplicationUser> GetAllUsers();

        ApplicationUser Get_User_BY_ID(string User_ID);
        ApplicationUser Get_User_BY_UserName(string User_Name);


        bool Insert_User(ApplicationUser user_info);

        bool Update_User(ApplicationUser user_info);

        bool Is_User_New(ApplicationUser User_Info);

        string[] Is_User_New(string Code_Meli,string Mobile_Num,string E_mail,string User_Name);

        bool Delete_User_BY_ID(string User_ID);
        bool Delete_User_BY_UserName(string User_Name);
        bool Delete_User(ApplicationUser User_Info);

        Task<ApplicationUser> Forget_Login_Info(string inf);

        bool Disposi_db();
    }
}
