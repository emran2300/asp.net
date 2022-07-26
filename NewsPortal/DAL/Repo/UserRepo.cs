using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class UserRepo : IRepo<User,int>
    {
        private newsPortalEntities db;

        public UserRepo(newsPortalEntities db)
        {
            this.db = db;
        }

        public bool Create(User obj)
        {
            db.Users.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var obj = Get(id);
            db.Users.Remove(obj);
            return db.SaveChanges() > 0;
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public bool Update(User obj)
        {
            var find = db.Users.Find(obj.Id);

            if(find != null)
            {
                db.Entry(find).CurrentValues.SetValues(obj);
                return db.SaveChanges() > 0;
            }
            return false;
        }
    }
}
