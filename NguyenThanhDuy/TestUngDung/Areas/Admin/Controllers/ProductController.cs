using ModelEF.Dao;
using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        NguyenThanhDuyContext db = new NguyenThanhDuyContext();
        // GET: Admin/Product
        public ActionResult Index(string seach, int page = 1, int pagesize = 5)
        {
            var dao = new ProductDao();
            var model = dao.ListAll(seach, page, pagesize);
            ViewBag.seach = seach;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var tyoe = new CategoryDao();
            var type = tyoe.ListAlls();
            ViewBag.type = type;
            setViewBag();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product sp, HttpPostedFileBase Images)
        {
            if (Images != null && Images.ContentLength > 0)
            {
                int id = int.Parse(db.Products.ToList().Last().ID.ToString());
                string _FileName = Path.GetFileName(Images.FileName);
                int index = Path.GetFileName(Images.FileName).IndexOf('.');
                _FileName = "sp" + id.ToString() + "." + Path.GetFileName(Images.FileName).Substring(index + 1);

                string path = Path.Combine(Server.MapPath("~/Assets/Admin/Images/" + _FileName));
                Images.SaveAs(path);

                //tbl_product unv = db.tbl_product.FirstOrDefault(x => x.product_id == id);
                sp.Image = _FileName;

                //db.SaveChanges();
            }

            if (ModelState.IsValid)
            {
                db.Products.Add(sp);
                db.SaveChanges();
                SetAlert("Thêm Sản Phẩm Thành Công", "success");
                return RedirectToAction("Index");
            }
            setViewBag();
            return View();
        }

        public JsonResult Delete(int productid)
        {
            var dele = new ProductDao();
            bool re = dele.delete(productid);
            return Json(re, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Detail(int id)
        {
            var product = new ProductDao().ListAllnew(id);
            return View(product);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var tyoe = new CategoryDao();
            var type = tyoe.ListAlls();
            ViewBag.type = type;
            var product = new ProductDao().getbyid(id);
            setViewBag(product.IDCategory);
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product sp, HttpPostedFileBase Images)
        {
            Product unv = db.Products.FirstOrDefault(x => x.ID == sp.ID);

            if (unv != null)
            {
                unv.Name = sp.Name;
                unv.Description = sp.Description;
                unv.UnitCost = sp.UnitCost;
                unv.Quantity = sp.Quantity;
                unv.IDCategory = sp.IDCategory;
                unv.Status = sp.Status;
                if (Images != null && Images.ContentLength > 0)
                {
                    long id = sp.ID;
                    string _FileName = "";
                    int index = Path.GetFileName(Images.FileName).IndexOf('.');
                    _FileName = "udsp" + id.ToString() + "." + Path.GetFileName(Images.FileName).Substring(index + 1);
                    string path = Path.Combine(Server.MapPath("~/Assets/Admin/Images/" + _FileName));
                    Images.SaveAs(path);
                    unv.Image = _FileName;
                }
            }
            if (ModelState.IsValid)
            {
                db.SaveChanges();
                SetAlert("Cập Nhật Sản Phẩm Thành Công", "success");
                return RedirectToAction("Detail/"+unv.ID);
            }
            return View();
        }
        public void setViewBag(int? selectedID = null)
        {
            var dao = new CategoryDao();
            ViewBag.IDCategory = new SelectList(dao.ListAlls(), "ID", "Name", selectedID);
        }
    }
}