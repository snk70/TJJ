using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TJJ
{
    public static class GetUserInfo
    {
        public static IdentitySample.Models.ApplicationUser GetLogedInUserInfo(string UserName,IdentitySample.Models.ApplicationDbContext DB)
        {
            return DB.Users.SingleOrDefault(p => p.UserName==UserName);
        }
    }
}