using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using RiddleMeThisModel;

namespace RiddleMeThisDL
{
    public class RiddleData
    {
        List<Riddles> riddles;
        SqlRiddleData sqlData;
        public RiddleData()
        {
            riddles = new List<Riddles>();
            sqlData = new SqlRiddleData();

            //UserFactory _userFactory = new UserFactory();
            //users = _userFactory.GetDummyUsers();
        }

        public List<Riddles> GetRiddles()
        {
            riddles = sqlData.GetRiddle();
            return riddles;
        }

        //public int AddUser(User user)
        //{
        //    return sqlData.AddUser(user.userName, user.points);
        //}

        //public int UpdateUser(User user)
        //{
        //    return sqlData.UpdateUser(user.userName, user.points);
        //}

        //public int DeleteUser(User user)
        //{
        //    return sqlData.DeleteUser(user.userName);
        //}

    }
}
