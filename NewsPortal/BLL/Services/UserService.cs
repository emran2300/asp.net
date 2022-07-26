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
    public class UserService
    {
        public static List<UserModel>Get()
        {
            var data = DataAccessFactory.GetUserDataAccess().Get();
            var user = new List<UserModel>();
            foreach (var item in data)
            {
                user.Add(new UserModel() { Id = item.Id, Name = item.Name });
            }
            return user;
        }
        public static User GetById(int id)
        {
            return DataAccessFactory.GetUserDataAccess().Get(id);
        }
        public static bool Create(UserModel model)
        {
            var user = new User()
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email
            };

            return DataAccessFactory.GetUserDataAccess().Create(user);
        }
        public static bool Update(User user)
        {
            return DataAccessFactory.GetUserDataAccess().Update(user);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.GetUserDataAccess().Delete(id);
        }
    }
}
