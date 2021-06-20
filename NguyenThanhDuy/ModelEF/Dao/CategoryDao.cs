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
    public class CategoryDao
    {
        NguyenThanhDuyContext db = null;
        public CategoryDao()
        {
            db = new NguyenThanhDuyContext();
        }
        public IEnumerable<Category> ListAll(string seach, int page = 1, int pagesize = 4)
        {
            IQueryable<Category> model = (IQueryable<Category>)db.Categories;
            if (!string.IsNullOrEmpty(seach))
            {
                model = (IOrderedQueryable<Category>)model.Where(x => x.Name.Contains(seach));
            }
            return model.OrderByDescending(x => x.Name).ToPagedList(page, pagesize);
        }
        public List<Category> ListAlls()
        {
            return db.Categories.ToList();
        }
        public List<Category> ListAllnumber(int number)
        {
            return db.Categories.Take(number).ToList();
        }
        
        public long insert(Category entity)
        {
            db.Categories.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool update(Category entity)
        {
            try
            {
                var category = db.Categories.Find(entity.ID);
                category.Name = entity.Name;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public Category getbyid(int id)
        {
            return db.Categories.Find(id);
        }

        public bool delete(int id)
        {
            try
            {
                var category = db.Categories.Find(id);
                db.Categories.Remove(category);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public int quantitycategory()
        {
            return db.Categories.Count();
        }
    }
}
