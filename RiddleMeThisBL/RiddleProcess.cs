using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiddleMeThisDL;
using RiddleMeThisModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RiddleMeThisBL
{
    public class RiddleProcess
    {
        public bool getAnswer(string answer) 
        {
            RiddleData riddleData = new RiddleData();
            bool result = new bool();
            foreach(var answers in riddleData.GetRiddles()) 
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
            return riddleData.GetRiddles();
        }
        public bool AddRiddles(int number, string question, string answer)
        {
            bool result = false;
            RiddleData data = new RiddleData();
            Riddles riddle = new Riddles { number = number, question = question, answer = answer };

            if (data.AddRiddle(riddle) > 0)
            {
                result = true;
            }
            return result;
        }
        public bool UpdateRiddle(int number, string question, string answer)
        {
            bool result = new bool();
            RiddleData data = new RiddleData();
            Riddles riddle = new Riddles { number = number, question = question, answer = answer };
            if (data.UpdateRiddle(riddle) != 0)
            {
                result = true;
            }
            return result;
        }
        public bool DeleteRiddle(int riddleNumber)
        {
            bool result = false;
            RiddleData riddleData = new RiddleData();
            Riddles riddle = new Riddles();
            riddle.number = riddleNumber;
            if (riddleData.DeleteRiddle(riddle) == 1)
            {
                result = true;
            }
            return result;
        }
    }
}
