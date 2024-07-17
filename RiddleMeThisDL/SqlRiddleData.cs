using System;
using System.Collections.Generic;
using RiddleMeThisModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiddleMeThisDL
{
    public class SqlRiddleData
    {
        string connectionString
       //= "Data Source =DESKTOP-L8FR2GU\\SQLEXPRESS; Initial Catalog = db_riddles; Integrated Security = True;";
       = "Server = tcp:172.188.88.220,1433;Database = db_riddles;User Id= sa;Password = pass123!;";

        SqlConnection sqlConnection;

        public SqlRiddleData()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public List<Riddles> GetRiddle()
        {
            string selectStatement = "SELECT riddleNumber, riddleQuestion, riddleAnswer FROM tbl_riddle";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            List<Riddles> riddles = new List<Riddles>();

            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                string question = reader["riddleQuestion"].ToString();
                string answer = reader["riddleAnswer"].ToString();

                Riddles readRiddle = new Riddles();
                readRiddle.question = question;
                readRiddle.answer = answer;
                readRiddle.number = Convert.ToInt16(reader["riddleNumber"]);

                riddles.Add(readRiddle);
            }

            sqlConnection.Close();

            return riddles;
        }

        public int AddRiddle(int number, string riddleQuestion, string riddleAnswer)
        {
            int success;

            string insertStatement = "INSERT INTO tbl_riddle VALUES (@riddleNumber, @riddleQuestion, @riddleAnswer)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@riddleNumber", number);
            insertCommand.Parameters.AddWithValue("@riddleQuestion", riddleQuestion);
            insertCommand.Parameters.AddWithValue("@riddleAnswer", riddleAnswer);
            sqlConnection.Open();

            success = insertCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }

        public int UpdateRiddle(int number, string riddleQuestion, string riddleAnswer)
        {
            int success;

            string updateStatement = $"UPDATE tbl_riddle SET riddleQuestion = @riddleQuestion, riddleAnswer = @riddleAnswer WHERE riddleNumber = @riddleNumber";
            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);
            sqlConnection.Open();

            updateCommand.Parameters.AddWithValue("@riddleNumber", number);
            updateCommand.Parameters.AddWithValue("@riddleQuestion", riddleQuestion);
            updateCommand.Parameters.AddWithValue("@riddleAnswer", riddleAnswer);

            success = updateCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }

        public int DeleteRiddle(int riddleNumber)
        {
            int success;

            string deleteStatement = $"DELETE FROM tbl_riddle WHERE riddleNumber = @riddleNumber";
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);
            sqlConnection.Open();

            deleteCommand.Parameters.AddWithValue("@riddleNumber", riddleNumber);

            success = deleteCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }

    }
}
