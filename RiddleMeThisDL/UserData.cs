
using RiddleMeThisModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiddleMeThisModel;

namespace RiddleMeThisDL
{
    public class UserData
    {
        List<User> users;
        SqlUserData sqlData;
        public UserData()
        {
            users = new List<User>();
            sqlData = new SqlUserData();

            //UserFactory _userFactory = new UserFactory();
            //users = _userFactory.GetDummyUsers();
        }

        public List<User> GetUsers()
        {
            users = sqlData.GetUsers();
            return users;
        }

        public int AddUser(User user)
        {
            return sqlData.AddUser(user.userName, user.points);
        }

        public int UpdateUser(User user)
        {
            return sqlData.UpdateUser(user.userName, user.points);
        }

        public int DeleteUser(User user)
        {
            return sqlData.DeleteUser(user.userName);
        }
    }
}
