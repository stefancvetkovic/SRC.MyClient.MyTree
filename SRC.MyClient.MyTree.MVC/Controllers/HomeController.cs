using SRC.MyClient.MyTree.BusinessLogic;
using SRC.MyClient.MyTree.Model;
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
            try
            {
                var model = new ItemTreeBusinessLogic().GetRootData();
                return View(model);
            }
            catch (Exception)
            {
                //TODO:Logovanje
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public ActionResult AddItem()
        {
            try
            {
                ViewBag.ParentId = new ItemTreeBusinessLogic().GetAllData();
                return View();
            }
            catch (Exception)
            {
                //TODO:Logovanje
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public ActionResult DeleteItem()
        {
            try
            {
                ViewBag.Id = new ItemTreeBusinessLogic().GetAllData();
                return View();
            }
            catch (Exception)
            {
                //TODO:Logovanje
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult DeleteItem(int id)
        {
            try
            {
                new ItemTreeBusinessLogic().DeleteItem(id);
            }
            catch (Exception)
            {
                //TODO:Logovanje
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
            
        }


        [HttpPost]
        public ActionResult AddItem(ItemTree item)
        {
            if (string.IsNullOrEmpty(item.ItemName))
            {
                return View(item);
            }
            try
            {
                new ItemTreeBusinessLogic().InsertData(item);
            }
            catch (Exception)
            {
                //TODO:Logovanje
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}