using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvertedSoftware.PLogger.ExampleMvcApplication
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            for (int i = 0; i < 1000; i++)
                Plogger.Log(string.Empty, true, 2, null, i.ToString());

            return View();
        }

    }
}
