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
        public List<Riddles> riddles = new List<Riddles>();
        public List<User> currentUser = new List<User>();    

        public RiddleData() { CreateRiddles();}
        public RiddleData(string userName, int score) { CreateRiddles(); CreateCurrentUser(userName, score); }

        public List<Riddles> CreateRiddles()
        {
            Riddles riddle1 = new Riddles
            {
                number = 1,
                question = "What question can you never answer yes to?",
                answer = "are you asleep yet?",
            };
            Riddles riddle2 = new Riddles
            {
                number = 2,
                question = "I have married many times but have always been single",
                answer = "priest",
            };
            Riddles riddle3 = new Riddles
            {
                number = 3,
                question = "Pronounced as a letter, written with three, i have a twin whom i cannot see.",
                answer = "eyes",

            };

            riddles.Add(riddle1);
            riddles.Add(riddle2);
            riddles.Add(riddle3);

            return riddles;
        }
        public List<User> CreateCurrentUser(string userName, int score) 
        {
            Points currentPoint = new Points { score = score, maxScore = 3};

            User current = new User {userName = userName, points = currentPoint};  

            currentUser.Add(current);
            
            return currentUser;
        }
        public List<Riddles> getRiddles() 
        {
            return riddles;
        }

    }
}
