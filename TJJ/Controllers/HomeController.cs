using IdentitySample.Models;
using System.Web.Mvc;

namespace IdentitySample.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        TJJ.IUsersRepository UserRepository;

        public HomeController()
        {
            UserRepository = new TJJ.Services.Users_Repository(db);
        }


        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Terms()
        {
            return View();
        }


        [HttpGet]
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
