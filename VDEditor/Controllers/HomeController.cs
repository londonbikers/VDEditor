using System.Web.Mvc;

namespace VDEditor.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to VD Editor";
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
