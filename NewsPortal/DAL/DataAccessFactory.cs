using DAL.EF;
using DAL.Interfaces;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        static newsPortalEntities db = new newsPortalEntities();

        public static IRepo<User,int> GetUserDataAccess()
        {
            return new UserRepo(db);
        }

        public static IRepo<Category,int> GetCategoryDataAccess()
        {
            return new CategoryRepo(db);
        }

        public static IRepo<News,int> GetNewsDataAccess()
        {
            return new NewsRepo(db);
        }
    }
}
