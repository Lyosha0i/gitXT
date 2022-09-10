using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using Task8._1._1.DAL.Interfaces;
using Task8._1._1.Entities;

namespace Task8._1._1.DAL
{
    public class UsersAwardsSqlDAO : IUsersAwardsDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        private static SqlConnection _connection = new SqlConnection(_connectionString);

        public IEnumerable<UserAward> GetUsersAwards()
        {
            //bool orderedById = true;
            using (_connection)
            {
                var query = "SELECT * FROM UsersAwards";

                var command = new SqlCommand(query, _connection);

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new UserAward(
                        user: (int)reader["UserID"],
                        award: (int)reader["AwardID"]);
                }
            }
        }

        public UserAward AddUserAward(User user, Award award)
        {
            using (_connection)
            {
                var query = "INSERT INTO UsersAwards(UserID, AwardID) " +
                    "VALUES(@UserID, @AwardID); SELECT CAST(scope_identity() AS INT) AS NewID";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@UserID", user.ID2);
                command.Parameters.AddWithValue("@AwardID", award.ID2);

                // DBNull.Value

                _connection.Open();

                var result = command.ExecuteScalar();

                if (result != null)
                    return new UserAward(
                        user: user,
                        award:award);

                throw new InvalidOperationException(
                    string.Format("Cannot add Note with parameters: {0}, {1};",
                    user, award));
            }
        }

        public UserAward GetUserAward(Guid id)
        {
            throw new NotImplementedException();
        }

        public void RemoveUserAward(User user, Award award)
        {
            SqlConnection _connection = new SqlConnection(_connectionString);

            using (_connection)
            {
                string query = "DELETE FROM UsersAwards WHERE UserID=@user AND AwardID=@award";

                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@user", user.ID2);
                command.Parameters.AddWithValue("@award", award.ID2);

                //if (_connection.)
                //static void NewOrder(Order order)
                //{
                //Thread myThread3 = new Thread(Pizzas);
                //myThread3.Start();
                //}
                _connection.Open();

                var reader = command.ExecuteReader();

                //if(reader.Read())
                //return new User(
                //        Id: (int)reader["UserID"],
                //        date: default,//
                //        name: reader["Name"] as string);

                //throw new InvalidOperationException();
            }
        }

        public void RemoveUserAward(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
