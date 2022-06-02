using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using Task8._1._1.DAL.Interfaces;
using Task8._1._1.Entities;

namespace Task8._1._1.DAL
{
    public class AwardsSqlDAO : IAwardsDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        //private static SqlConnection _connection = new SqlConnection(_connectionString);

        public IEnumerable<Award> GetAwards()
        {
            SqlConnection _connection = new SqlConnection(_connectionString);
        bool orderedById = true;
            using (_connection)
            {
                var query = "SELECT * FROM Awards"
                    + (orderedById ? " ORDER BY AwardID" : "");

                var command = new SqlCommand(query, _connection);

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Award(
                        Id:(int)reader["AwardID"],
                        title:reader["Title"] as string);
                }
            }
        }

        public Award AddAward(string title)
        {
            SqlConnection _connection = new SqlConnection(_connectionString);
            using (_connection)
            {
                var query = "INSERT INTO Awards(AwardID, Title) " +
                    "VALUES(@AwardID, @Title); SELECT CAST(scope_identity() AS INT) AS NewID";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@AwardID", "@Title");

                // DBNull.Value

                _connection.Open();

                var result = command.ExecuteScalar();

                if (result != null)
                    return new Award(
                        Id: (int)result,
                        title: title);

                throw new InvalidOperationException(
                    string.Format("Cannot add Note with parameters: {0}",
                    title));
            }
        }

        public Award GetAward(int id)
        {
            SqlConnection _connection = new SqlConnection(_connectionString);
            using (_connection)
            {
                string query = "SELECT * FROM Awards WHERE AwardID=@id";

                var command = new SqlCommand(query, _connection);
                //{
                //    CommandType = System.Data.CommandType.StoredProcedure
                //};

                command.Parameters.AddWithValue("@id", id);

                _connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Award(
                        Id: (int)reader["AwardID"],
                        title: reader["Title"] as string);
                }

                throw new InvalidOperationException("Cannot find Note with ID = " + id);
            }
        }

        public void RemoveAward(Guid id)
        {
            // TODO: Remove note from SQL Database
        }

        public void EditAward(int id, string newText)
        {
            // TODO: Edit note via SQL Database   
        }

        #region NOT_IMPLEMENTED
        public Award GetAward(Guid id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
