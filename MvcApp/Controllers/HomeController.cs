using Repository.Data;
using Repository.Models;
using System.Web.Mvc;

namespace MvcApp.Controllers
{
    public class HomeController : Controller
    {
        //IDataSession is a pluggable DbContext. See non service classes in Repository.Data for more info.
        private IDataSession _dataSession;

        public HomeController(IDataSession dataSession)
        {
            _dataSession = dataSession;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}