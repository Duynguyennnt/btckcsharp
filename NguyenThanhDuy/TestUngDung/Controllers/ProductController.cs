using ModelEF.Dao;
using ModelEF.Model;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
namespace TestUngDung.Controllers
{
    public class ProductController : Controller
    {
        NguyenThanhDuyContext db = new NguyenThanhDuyContext();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult Category()
        {
            var model = new CategoryDao().ListAllnumber(11);
            return PartialView(model);
        }
        public ActionResult Detail(int id)
        {
            var model = new ProductDao();
            ViewBag.Productsdetail = model.ListAllnew(id);
            return View();
        }
    }
}