using ActionFIlterDemo.AuthData;
using FiltersDemo.AuthData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ActionFIlterDemo.Controllers
{
    [ActionFilter]
    [HandleError(View = "Error")]
    [AuthAttribute]
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Users = "rp1887@gmail.com")]
        public ActionResult About()
        {
            ViewBag.Message = "Hi Rajendra.";

            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        [OutputCache(Duration = 60)]
        public string cacheIndex()
        {
            ViewBag.Message = "Current Time Is";

            return DateTime.Now.ToString("T");
        }


        public ActionResult ErrorHandleIndex()
        {
            throw new NullReferenceException();
            return View();
        }
        [HandleException]
        public string TestRange(int id)
        {
            if (id > 100)
            {
                return String.Format("The value of id={0}", id);
            }
            else
            {
                throw new ArgumentOutOfRangeException("id", id, "");
            }
        }
    }
}