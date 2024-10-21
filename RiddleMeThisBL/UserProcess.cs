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
            smtpUserService smtp = new smtpUserService();
            bool result = false;
            UserData data = new UserData();
            User users = new User { userName = user, points = score };
            if (verifyUser(user))
            {
                return result = false;
            }
            if (data.AddUser(users) > 0 && smtp.AddUser(user) == true)
            {
                return result = true;
            }
            
            return result;
        }
        public bool UpdateScore(string user, Points score) 
        {
            smtpUserService smtp = new smtpUserService();
            bool result = new bool();
            UserData userData = new UserData();
            User users = new User { userName = user, points = score };
            if (userData.UpdateUser(users) != 0 && smtp.UpdateUser(user, users.points.score)) 
            {
                result = true;
            }
            return result;
        }
        public bool DeleteUser(string user)
        {
            smtpUserService smtp = new smtpUserService();
            bool result = false;
            UserData userData = new UserData();
            User users = new User { userName = user};
            if (userData.DeleteUser(users) == 1 && smtp.DeleteUser(user)) 
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
