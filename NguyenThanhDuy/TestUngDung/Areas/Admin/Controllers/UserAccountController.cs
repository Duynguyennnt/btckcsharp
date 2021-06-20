using ModelEF.Dao;
using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class UserAccountController : BaseController
    {
        // GET: Admin/UserAccount
        public ActionResult Index(string seach, int page = 1, int pagesize = 5)
        {
            var dao = new UserAccountDao();
            var model = dao.ListAll(seach, page, pagesize);
            ViewBag.seach = seach;
            return View(model);
        }
        public JsonResult Delete(int userid)
        {
            var dele = new UserAccountDao();
            bool re = dele.delete(userid);
            return Json(re, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = new UserAccountDao().getbyid(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(UserAccount account)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserAccountDao();
                bool result = dao.update(account);
                if (result)
                {
                    SetAlert("Cập nhật thành công", "success");
                    return RedirectToAction("Index");
                }
                else
                {
                    SetAlert("Cập nhật thất bại vui lòng thử lại", "error");
                    return RedirectToAction("Index");
                }
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserAccount account)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserAccountDao();
                int id = dao.insert(account);
                if (id > 0)
                {
                    SetAlert("Thêm Tài Khoản Thành Công", "success");
                    return RedirectToAction("Index");
                }
                else
                {
                    SetAlert("Thêm Tài Khoản Thành Công", "error");
                    return RedirectToAction("Index");
                }
            }
            return View("Index");
        }
    }
}