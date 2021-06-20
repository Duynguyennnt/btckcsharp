using ModelEF.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var modelpr = new ProductDao();
            ViewBag.Newproducts = modelpr.listnewproduct(9);
            var modect = new CategoryDao();
            ViewBag.NewCategory = modect.ListAllnumber(4);
            ViewBag.ProductAll = modelpr.listallproduct();
            ViewBag.ProductAllsale = modelpr.listallproductsale();
            ViewBag.Productlimit = modelpr.listallproductlimit();
            return View();
        }
    }
}