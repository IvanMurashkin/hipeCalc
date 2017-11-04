using DBModel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel {
    public static class DB {

        private const string CONN = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\GitRepository\hipeCalc\DBModel\AppData\HypeDB.mdf;Integrated Security=True";

        public static bool AddFavorite(Favorite fav) {

            using (var connection = new SqlConnection(CONN)) {
                SqlCommand command = new SqlCommand("INSERT INTO Favorite (Name, CreationDate, IsCustom) VALUES(@Name, @Now, @IsCustom)",
                    connection);

                command.Parameters.Add("@Name", SqlDbType.NVarChar);
                command.Parameters.Add("@Now", SqlDbType.DateTime);
                command.Parameters.Add("@IsCustom", SqlDbType.Bit);

                command.Parameters["@Name"].Value = fav.Name;
                command.Parameters["@Now"].Value = fav.CreationDate;
                command.Parameters["@IsCustom"].Value = fav.IsCustom;

                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }

        }

        public static bool DeleteFavorite(Favorite fav) {
            using (var connection = new SqlConnection(CONN)) {
                SqlCommand command = new SqlCommand("DELETE FROM Favorite WHERE Name = @Name", connection);

                command.Parameters.Add("@Name", SqlDbType.NVarChar);

                command.Parameters["@Name"].Value = fav.Name;

                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public static IList<Favorite> GetFavorits() {
            var result = new List<Favorite>();

            var connection = new SqlConnection(CONN);

            using (connection) {
                SqlCommand command = new SqlCommand(
                  "SELECT Id, Name, CreationDate, IsCustom FROM Favorite",
                  connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) {
                    while (reader.Read()) {

                        var fav = new Favorite();

                        fav.Id = reader.GetInt64(0);
                        fav.Name = reader.GetString(1);
                        fav.CreationDate = reader.IsDBNull(2) ? DateTime.MinValue : reader.GetDateTime(2);
                        fav.IsCustom = reader.GetBoolean(3);
                        
                        result.Add(fav);
                    }
                }
                reader.Close();
            }
            return result;
        }

        public static bool AddOperationHistory(OperationHistory item) {
            using (var connection = new SqlConnection(CONN)) {
                SqlCommand command = new SqlCommand("INSERT INTO OperationHistory (Name, Args, Result, ExcecTime) " +
                    " VALUES(@Name, @Args, @Result, @ExcecTime)",
                    connection);

                command.Parameters.Add("@Name", SqlDbType.NVarChar);
                command.Parameters.Add("@Args", SqlDbType.NVarChar);
                command.Parameters.Add("@Result", SqlDbType.Real);
                command.Parameters.Add("@ExcecTime", SqlDbType.BigInt);

                command.Parameters["@Name"].Value = item.Name;
                command.Parameters["@Args"].Value = item.Args;
                command.Parameters["@Result"].Value = item.Result;
                command.Parameters["@ExcecTime"].Value = item.ExcecTime;

                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public static OperationHistory GetOperationHistory(string operName, string args) {
            var result = new List<OperationHistory>();

            var connection = new SqlConnection(CONN);

            using (connection) {
                SqlCommand command = new SqlCommand("SELECT Id, Name, Args, Result, ExcecTime " + 
                    "FROM OperationHistory Where Name = @Name AND Args = @Args;", connection);


                command.Parameters.Add("@Name", SqlDbType.NVarChar);
                command.Parameters.Add("@Args", SqlDbType.NVarChar);


                command.Parameters["@Name"].Value = operName;
                command.Parameters["@Args"].Value = args;

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) {
                    while (reader.Read()) {

                        var operHistory = new OperationHistory();

                        operHistory.Id = reader.GetInt64(0);
                        operHistory.Name = reader.GetString(1);
                        operHistory.Args = reader.GetString(2);
                        operHistory.Result = reader.IsDBNull(3) ? double.NaN : reader.GetDouble(3);
                        operHistory.ExcecTime = reader.GetInt64(4);

                        result.Add(operHistory);
                    }
                }
                reader.Close();
            }

            return result.FirstOrDefault();
        }

        public static IList<string> GetHeavyOperations() {
            var result = new List<string>();

            var connection = new SqlConnection(CONN);

            using (connection) {
                SqlCommand command = new SqlCommand("SELECT Name, AVG(ExcecTime) FROM OperationHistory GROUP BY Name;", connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) {
                    while (reader.Read()) {

                        var avgTime = reader.GetInt64(1);

                        if (avgTime > 1000) {
                            result.Add(reader.GetString(0));

                        }
                    }
                }
                reader.Close();
            }

            return result;
        }

    }
}
