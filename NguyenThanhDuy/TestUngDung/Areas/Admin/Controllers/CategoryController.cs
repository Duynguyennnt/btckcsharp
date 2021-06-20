using ModelEF.Dao;
using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        public ActionResult Index(string seach, int page = 1, int pagesize = 4)
        {
            var dao = new CategoryDao();
            var model = dao.ListAll(seach, page, pagesize);
            ViewBag.seach = seach;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryDao();
                long id = dao.insert(category);
                if (id > 0)
                {
                    SetAlert("Thêm mới thành công", "success");
                    return RedirectToAction("Index");
                }
                else
                {
                    SetAlert("Thêm mới Thất Bại", "error");
                    return RedirectToAction("Index");
                }
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = new CategoryDao().getbyid(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryDao();
                bool result = dao.update(category);
                if (result)
                {
                    SetAlert("Cập Nhật Danh Mục Thành Công", "success");
                    return RedirectToAction("Index");
                }
                else
                {
                    SetAlert("Cập Nhật Danh Mục Thất Bại", "error");
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public JsonResult Delete(int categoryid)
        {
            var dele = new CategoryDao();
            bool re = dele.delete(categoryid);
            return Json(re, JsonRequestBehavior.AllowGet);
        }
    }
}