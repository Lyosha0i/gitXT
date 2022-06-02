using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Task8._1._1.DAL.Interfaces;
using Task8._1._1.Entities;
using System.Threading;

namespace Task8._1._1.DAL
{
    public class UsersSqlDAO : IUsersDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        //private static SqlConnection _connection = new SqlConnection(_connectionString);

        //private void Pizzas()
        //{
        //    _connection.Open();
        //}
        public IEnumerable<User> GetUsers()
        {
            SqlConnection _connection = new SqlConnection(_connectionString);

        bool orderedById = true;
            using (_connection)
            {
                string query = "SELECT * FROM Users"
                    + (orderedById ? " ORDER BY UserID" : "");

                var command = new SqlCommand(query, _connection);

                //if (_connection.)
                //static void NewOrder(Order order)
                //{
                    //Thread myThread3 = new Thread(Pizzas);
                    //myThread3.Start();
                //}
                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new User(
                        Id: (int)reader["UserID"],
                        date: (DateTime)reader["DateOfBirth"],
                        name: reader["Name"] as string);
                }
            }
        }

        public User AddUser(DateTime date, string name)
        {
            SqlConnection _connection = new SqlConnection(_connectionString);
            int age=0;
            //int crutch = GetUsers().Max(u => u.ID2) + 1;
            using (_connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO Users(UserID, DateOfBirth, Age, Name) " +
                    "VALUES(@UserID, @DateOfBirth, @Age, @Name); SELECT MAX(UserID) FROM Users";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@UserID", 5);//
                command.Parameters.AddWithValue("@DateOfBirth", date);
                command.Parameters.AddWithValue("@Age", DateTime.Now.Year - date.Year + (Math.Sign(DateTime.Now.DayOfYear - date.DayOfYear) - 1) / 2);//Maybe, this formula is wrong.
                command.Parameters.AddWithValue("@Name", name);

                // DBNull.Value

                //_connection.Close();
                _connection.Open();

                var result = command.ExecuteScalar();
                _connection.Open();
                try
                {
                    _connection.Open();
                    if (result != null)
                        return new User(
                            Id: (int)result,
                            date: date,
                            age: age,
                            name: name);
                }
                finally
                {
                    _connection.Close();
                    _connection.Open();
                }

                throw new InvalidOperationException(
                    string.Format("Cannot add Note with parameters: {0}, {1};",
                    name, date));
            }
        }

        public User GetUser(int id)
        {
            SqlConnection _connection = new SqlConnection(_connectionString);
            using (_connection)
            {
                string query = "SELECT * FROM Users WHERE UserID=@id";

                var command = new SqlCommand(query, _connection);
                //{
                //    CommandType = System.Data.CommandType.StoredProcedure
                //};

                command.Parameters.AddWithValue("@id", id);

                _connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new User(
                        Id: (int)reader["UserId"],
                        date: (DateTime)reader["DateOfBirth"],
                        name: reader["Name"] as string);
                }

                throw new InvalidOperationException("Cannot find Note with ID = " + id);
            }
        }

        public void RemoveUser(Guid id)
        {
            // TODO: Remove note from SQL Database
        }

        public void EditUser(int id, string newText)
        {
            // TODO: Edit note via SQL Database   
        }

        #region NOT_IMPLEMENTED
        public User GetUser(Guid id)
        {
            throw new NotImplementedException();
        }
        #endregion 
    }
}
