using ModelEF.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUngDung.Areas.Admin.Models;
using TestUngDung.Common;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        //Get: Admin/login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
           
                var dao = new UserAccountDao();
                var result = dao.login(model.UserName, model.Password);
                if (result)
                {
                    var user = dao.getbyuser(model.UserName);
                    var usersession = new UserLogin();
                    usersession.Username = user.UserName;
                    Session.Add(CommonConstans.USER_SESSION, usersession);
                    return RedirectToAction("Index", "Home");
                }
                else
                {                    
                    ModelState.AddModelError("", "Tài khoản mật khẩu không chính xác");
                }
            return View("Index");
            
        }
    }
}