using ModelEF.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var categr = new CategoryDao();
            var modect = categr.quantitycategory();
            ViewBag.countct = modect;
            var qttpro = new ProductDao();
            var d = qttpro.quantityproduct();
            ViewBag.prd = d;
            var acc = new UserAccountDao();
            var modeacc = acc.getcountacc();
            ViewBag.acccount = modeacc;
            return View();
        }
    }
}