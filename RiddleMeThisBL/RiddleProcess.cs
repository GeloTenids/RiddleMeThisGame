using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiddleMeThisDL;
using RiddleMeThisModel;

namespace RiddleMeThisBL
{
    public class RiddleProcess
    {
        public bool getAnswer(string answer) 
        {
            answer.ToLower();
            RiddleData riddleData = new RiddleData();
            bool result = new bool();
            foreach(var answers in riddleData.riddles) 
            {
                if(answers.answer.Equals(answer.ToLower())) 
                {
                    result = true;
                    break;
                }
                else 
                {
                    result = false;
                }
            }
            return result;
        }
        public List<Riddles> getRiddle() 
        {
            RiddleData riddleData = new RiddleData();
            return riddleData.riddles;
        }
        public List<User> setUserAndScore(string user, int score) 
        {
            RiddleData data = new RiddleData(user, score);

            return data.CreateCurrentUser(user, score);
        }
    }
}
