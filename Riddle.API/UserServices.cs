
using RiddleMeThisBL;
using RiddleMeThisModel;

namespace Riddle.API
{
    public class UserServices
    {
        UserProcess userProcess;
        RiddleProcess riddleProcess;

        public UserServices()
        {
            riddleProcess = new RiddleProcess();
            userProcess = new UserProcess();
        }

        public List<Users> GetUsers()
        {
            List<Users> user = new List<Users>();

            Points point = new Points();
            foreach (var users in userProcess.getUser())
            {
                Users current = new Users();
                current.username = users.userName;
                point.score = users.points.score;
                current.score = point.score;
                user.Add(current);
            }
            return user;
        }
        public bool AddUser(string name, int score)
        {
            Points point = new Points();
            point.score = score;
            return userProcess.AddUserAndScore(name, point);
        }
        public bool UpdateScore(string name, int score)
        {
            Points point = new Points();
            point.score = score;
            return userProcess.UpdateScore(name, point);
        }
        public bool DeleteUser(string name)
        {
            return userProcess.DeleteUser(name);
        }
    }
}
