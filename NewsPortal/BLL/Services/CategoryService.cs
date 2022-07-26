using BLL.BOs;
using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CategoryService
    {
        public static List<CategoryModel>Get()
        {
            var data = DataAccessFactory.GetCategoryDataAccess().Get();
            var cat  = new List<CategoryModel>();
            foreach(var item in data)
            {
                cat.Add(new CategoryModel()
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }
            return cat;
        }
        public static Category GetById(int id)
        {
            return DataAccessFactory.GetCategoryDataAccess().Get(id);
        }
        public static bool Create(CategoryModel model)
        {
            var category = new Category()
            {
                Name = model.Name,
                Id = model.Id
            };
            return DataAccessFactory.GetCategoryDataAccess().Create(category);
        }
        public static bool Update(Category category)
        {
            return DataAccessFactory.GetCategoryDataAccess().Update(category);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.GetCategoryDataAccess().Delete(id);    
        }
    }
}
