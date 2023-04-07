using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Tjj.Controllers
{
    [Authorize(Roles = "KeyMaster")]

    public class TestMailController : Controller
    {
        // GET: /TestMail/?txt=TestEmail&to=sinakordestani@gmail.com&s=Testsmssubject
        public async Task<ActionResult> Index(string txt,string TO,string s="Tjj Email Test")
        {

            IdentitySample.Models.EmailService es = new IdentitySample.Models.EmailService();
            //es.SendAsync();
            Microsoft.AspNet.Identity.IdentityMessage im = new Microsoft.AspNet.Identity.IdentityMessage();
            im.Body = txt;
            im.Destination = TO;
            //im.Destination = "kordestani_sina@yahoo.com";
            im.Subject = s;

            ViewBag.to = TO;
            ViewBag.s = s;
            ViewBag.txt = txt;

            await es.SendAsync(im);
            return View();
        }
    }
}