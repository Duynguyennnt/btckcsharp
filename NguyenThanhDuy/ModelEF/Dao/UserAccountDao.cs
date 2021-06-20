using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
namespace ModelEF.Dao
{
    
    public class UserAccountDao
    {
        NguyenThanhDuyContext db = null;        
        public UserAccountDao()
        {
            db = new NguyenThanhDuyContext();
        }
        public bool login(string username, string password)
        {
            var result = db.UserAccounts.Count(x => x.UserName == username && x.Password == password);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public UserAccount getbyuser(string username)
        {
            return db.UserAccounts.SingleOrDefault(x=>x.UserName == username);
        }
        public IEnumerable<UserAccount> ListAll(string seach, int page = 1, int pagesize = 5)
        {
            IQueryable<UserAccount> model = db.UserAccounts;
            if (!string.IsNullOrEmpty(seach))
            {
                model = (IOrderedQueryable<UserAccount>)model.Where(x => x.UserName.Contains(seach));
            }
            return model.OrderByDescending(x => x.UserName).ToPagedList(page, pagesize);
        }
        public bool delete(int id)
        {
            try
            {
                var user = db.UserAccounts.Find(id);
                db.UserAccounts.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public UserAccount getbyid(int id)
        {
            return db.UserAccounts.Find(id);
        }
        public bool update(UserAccount entity)
        {
            try
            {
                var user = db.UserAccounts.Find(entity.ID);
                user.UserName = entity.UserName;
                user.Password = entity.Password;
                user.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public int insert(UserAccount entity)
        {
            db.UserAccounts.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public int getcountacc()
        {
            return db.UserAccounts.Count();
        }
    }

}
