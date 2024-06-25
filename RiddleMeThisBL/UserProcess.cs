using RiddleMeThisDL;
using RiddleMeThisModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiddleMeThisBL
{
    public class UserProcess
    {
        public List<User> getUser() 
        {
            UserData data = new UserData();
            return data.GetUsers();
        }
        public bool AddUserAndScore(string user, Points score)
        {
            bool result = false;
            UserData data = new UserData();
            User users = new User { userName = user, points = score };

            if (data.AddUser(users) > 0 ) {
                result = true;
            }
            return result;
        }
        public void UpdateScore(string user, Points score) 
        {
            UserData userData = new UserData();
            User users = new User { userName = user, points = score };
            userData.UpdateUser(users);
        }
        public bool DeleteUser(string user)
        {
            bool result = false;
            UserData userData = new UserData();
            User users = new User { userName = user};
            if (userData.DeleteUser(users) == 1) 
            {
                result = true;
            }
            return result;
        }
        public Points getScore(string user) 
        {
            Points score = new Points();
            foreach (var scores in getUser()) 
            {
                if (scores.userName.Equals(user)) 
                {
                   score = scores.points;
                   break;
                }
            }
            return score;

        }
        public bool verifyUser(string user) 
        {
            bool result = new bool();
            foreach (var users in getUser()) 
            {
                if (users.userName.Equals(user)) 
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
    }
}
