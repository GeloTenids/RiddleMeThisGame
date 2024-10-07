using RiddleMeThisModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiddleMeThisDL
{
    public class SqlUserData
    {
        string connectionString
      = "Data Source =DESKTOP-L8FR2GU\\SQLEXPRESS; Initial Catalog = db_riddles; Integrated Security = True;";
     //= "Server=tcp:172.188.88.220,1433;Database=db_riddles;User Id=sa;Password=pass123!;";

        SqlConnection sqlConnection;

        public SqlUserData()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public List<User> GetUsers()
        {
            string selectStatement = "SELECT username, score FROM tbl_user";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            List<User> users = new List<User>();

            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                string username = reader["username"].ToString();
                Points points = new Points();
                points.score = Convert.ToInt16(reader["score"]);

                User readUser = new User();
                readUser.userName = username;
                readUser.points = points;

                users.Add(readUser);
            }

            sqlConnection.Close();

            return users;
        }

        public int AddUser(string username, Points score)
        {
            int success;

            string user = username;
            int point = Convert.ToInt32(score.score);

            string insertStatement = "INSERT INTO tbl_user VALUES (@username, @score)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@username", user);
            insertCommand.Parameters.AddWithValue("@score", point);
            sqlConnection.Open();

            success = insertCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }

        public int UpdateUser(string username, Points score)
        {
            int success;

            string user = username;
            int point = Convert.ToInt32(score.score);

            string updateStatement = $"UPDATE tbl_user SET score = @score WHERE username = @username";
            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);
            sqlConnection.Open();

            updateCommand.Parameters.AddWithValue("@score", point);
            updateCommand.Parameters.AddWithValue("@username", user);

            success = updateCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }

        public int DeleteUser(string username)
        {
            int success;

            string deleteStatement = $"DELETE FROM tbl_user WHERE username = @username";
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);
            sqlConnection.Open();

            deleteCommand.Parameters.AddWithValue("@username", username);

            success = deleteCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }
    }
}
