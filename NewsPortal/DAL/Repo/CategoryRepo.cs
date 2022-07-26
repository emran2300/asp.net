using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class CategoryRepo : IRepo<Category, int>
    {
        private newsPortalEntities db;

        public CategoryRepo(newsPortalEntities db)
        {
            this.db = db;
        }

        public bool Create(Category obj)
        {
            db.Categories.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            db.Categories.Remove(Get(id));
            return db.SaveChanges() > 0;
        }

        public List<Category> Get()
        {
            return db.Categories.ToList();
        }

        public Category Get(int id)
        {
            return db.Categories.Find(id);
        }

        public bool Update(Category obj)
        {
            var find = db.Categories.Find(obj.Id);

            if(find != null)
            {
                db.Entry(find).CurrentValues.SetValues(obj);
                return db.SaveChanges() > 0;
            }
            return false;
        }
    }
}
