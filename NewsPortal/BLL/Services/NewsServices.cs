using BLL.BOs;
using DAL;
using DAL.EF;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class NewsServices
    {
        public static List<NewsModel>Get()
        {
            var data = DataAccessFactory.GetNewsDataAccess().Get();
            var news = new List<NewsModel>();
            foreach (var item in data)
            {
                news.Add(new NewsModel()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Type = item.Type,
                    Date = item.Date,
                    C_Id = item.C_Id,
                    U_Id = item.U_Id
                });
            }
            return news;
        }
        public static NewsModel GetById(int id)
        {
            var data =  DataAccessFactory.GetNewsDataAccess().Get(id);
            return new NewsModel() { Id = data.Id,Title = data.Title,Type = data.Type,C_Id = data.C_Id, U_Id = data.U_Id, Date = data.Date  };
        }
        public static bool Create(NewsModel model)
        {
            var news = new News()
            {
                Id = model.Id,
                Title = model.Title,
                Date = model.Date,
                C_Id = model.C_Id,
                U_Id = model.U_Id,
                Type = model.Type
            };
            return DataAccessFactory.GetNewsDataAccess().Create(news);
        }
        public static bool Update(News news)
        {
            return DataAccessFactory.GetNewsDataAccess().Update(news);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.GetNewsDataAccess().Delete(id);
        }

    }
}
