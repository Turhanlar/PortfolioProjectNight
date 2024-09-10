using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjectNight.Controllers
{
    public class CateforyController : Controller
    {
       
        public ActionResult CategoryList()
        {
            return View();
        }

        public ActionResult CreeateCategory()
        {
            return View();
        }
    }
}