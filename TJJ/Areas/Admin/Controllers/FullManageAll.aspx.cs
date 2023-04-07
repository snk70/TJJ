using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TJJ.Areas.Admin.Controllers
{
    public partial class FullManageAll : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if(User.IsInRole("KeyMaster") == false)
            {
                Response.Redirect("/Error_Not_Found");
            }
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            const string keep_link_text = "&%!@=+&%%$#";
            string domain_address = Request.Url.AbsoluteUri.Replace("://", keep_link_text).Replace(Request.Url.PathAndQuery, "").Replace(keep_link_text, "://");

            Response.Redirect(domain_address+ "/Manage");
        }
    }
}