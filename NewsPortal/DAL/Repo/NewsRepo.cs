using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class NewsRepo : IRepo<News,int>
    {
        private newsPortalEntities db;

        public NewsRepo(newsPortalEntities db)
        {
            this.db = db;
        }

        public bool Create(News obj)
        {
            db.News.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            db.News.Remove(Get(id));
            return db.SaveChanges() > 0;
        }

        public List<News> Get()
        {
            return db.News.ToList();
        }

        public News Get(int id)
        {
            return db.News.Find(id);
        }

        public bool Update(News obj)
        {
            var find = db.News.Find(obj.Id);

            if(find != null)
            {
                db.Entry(find).CurrentValues.SetValues(obj);
                return db.SaveChanges() >0;
            }
            return false;
        }
    }
}
