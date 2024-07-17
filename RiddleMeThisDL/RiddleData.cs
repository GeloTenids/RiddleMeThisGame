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

        public int AddRiddle(Riddles riddle)
        {
            return sqlData.AddRiddle(riddle.number, riddle.question, riddle.answer);
        }

        public int UpdateRiddle(Riddles riddle)
        {
            return sqlData.UpdateRiddle(riddle.number, riddle.question, riddle.answer);
        }

        public int DeleteRiddle(Riddles riddle)
        {
            return sqlData.DeleteRiddle(riddle.number);
        }

    }
}
