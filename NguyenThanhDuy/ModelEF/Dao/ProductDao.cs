using ModelEF.Model;
using ModelEF.ModelCustomer;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.Dao
{
    public class ProductDao
    {
        NguyenThanhDuyContext db = null;
        public ProductDao()
        {
            db = new NguyenThanhDuyContext();
        }
        public IEnumerable<Product> ListAll(string seach, int page = 1, int pagesize = 1)
        {
            IQueryable<Product> model = (IQueryable<Product>)db.Products;
            if (!string.IsNullOrEmpty(seach))
            {
                model = (IOrderedQueryable<Product>)model.Where(x => x.Name.Contains(seach));
            }
            return model.OrderBy(x => x.Quantity).OrderByDescending(x=>x.UnitCost).ToPagedList(page, pagesize);
        }
        public IEnumerable<ProductCustomer> ListAlls(string seach, int page = 1, int pagesize = 1)
        {
            IQueryable<ProductCustomer> model = from s in db.Products
                               join a in db.Categories
                               on s.IDCategory equals a.ID
                               where s.Name.Contains(seach)
                               select new ProductCustomer
                               {
                                   ID = s.ID,
                                   Name = s.Name,
                                   Description = s.Description,
                                   Images = s.Image,
                                   UnitCost = s.UnitCost,
                                   Quantity = s.Quantity,
                                   CategoryName = a.Name
                               };
            return model.OrderByDescending(x => x.Name).ToPagedList(page, pagesize);
        }
        public bool delete(int id)
        {
            try
            {
                var category = db.Products.Find(id);
                db.Products.Remove(category);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public Product getbyid(int id)
        {
            return db.Products.Find(id);
        }
        public int quantityproduct()
        {
            return db.Products.Count();
        }
        public List<Product> listnewproduct(int number)
        {
            return db.Products.OrderByDescending(x=>x.ID).Take(number).ToList();
        }
        public IEnumerable<ProductCustomer> ListAllnew(int id)
        {
            var list_product = (from s in db.Products
                                join a in db.Categories
                                on s.IDCategory equals a.ID
                                where s.ID.Equals(id)
                                select new ProductCustomer
                                {
                                    ID = s.ID,
                                    Name = s.Name,
                                    Description = s.Description,
                                    Images = s.Image,
                                    UnitCost = s.UnitCost,
                                    Quantity = s.Quantity,
                                    CategoryName = a.Name,
                                    Status = s.Status,
                                }).ToList();
            return list_product;
        }
        public List<Product> listallproduct()
        {
            return db.Products.OrderByDescending(x => x.ID).ToList();
        }
        public List<Product> listallproductsale()
        {
            return db.Products.OrderByDescending(x => x.UnitCost).ToList();
        }
        public List<Product> listallproductlimit()
        {
            return db.Products.OrderByDescending(x => x.UnitCost).Take(3).ToList();
        }
        
        public List<Product> getproduct(int id)
        {
            var list = from s in db.Products
                       where s.ID == id
                       select s;
            return (List<Product>)list;
        }
    }
}
