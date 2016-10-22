using SRC.MyClient.MyTree.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SRC.MyClient.MyTree.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new ItemTreeBusinessLogic().GetRootData();
            return View(model);
        }
        public ActionResult AddItem()
        {
            return View();
        }

        public ActionResult DeleteItem()
        {
            return View();
        }
    }
}