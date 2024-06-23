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
       = "Data Source =DESKTOP-L8FR2GU\\SQLEXPRESS; Initial Catalog = db_riddles; Integrated Security = True;";

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

        //public int AddUser(string username, string password)
        //{
        //    int success;

        //    string insertStatement = "INSERT INTO users VALUES (@username, @password, @status)";

        //    SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

        //    insertCommand.Parameters.AddWithValue("@username", username);
        //    insertCommand.Parameters.AddWithValue("@password", password);
        //    insertCommand.Parameters.AddWithValue("@status", 1);
        //    sqlConnection.Open();

        //    success = insertCommand.ExecuteNonQuery();

        //    sqlConnection.Close();

        //    return success;
        //}

        //public int UpdateUser(string username, string password)
        //{
        //    int success;

        //    string updateStatement = $"UPDATE users SET password = @Password WHERE username = @username";
        //    SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);
        //    sqlConnection.Open();

        //    updateCommand.Parameters.AddWithValue("@Password", password);
        //    updateCommand.Parameters.AddWithValue("@username", username);

        //    success = updateCommand.ExecuteNonQuery();

        //    sqlConnection.Close();

        //    return success;
        //}

        //public int DeleteUser(string username)
        //{
        //    int success;

        //    string deleteStatement = $"DELETE FROM users WHERE username = @username";
        //    SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);
        //    sqlConnection.Open();

        //    deleteCommand.Parameters.AddWithValue("@username", username);

        //    success = deleteCommand.ExecuteNonQuery();

        //    sqlConnection.Close();

        //    return success;
        //}
    
    }
}
