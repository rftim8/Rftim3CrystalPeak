using Microsoft.Data.SqlClient;
using System.Data;

namespace Rftim3Tracer
{
    public class RftADO
    {
        private static SqlConnection? sqlConnection;
        private static readonly SqlCommand RftSqlCommand = new();

        public RftADO(string connectionString)
        {
            sqlConnection = new SqlConnection(connectionString);
            RftSqlCommand.Connection = sqlConnection;
            RftSqlCommand.CommandType = CommandType.StoredProcedure;
            
            RftSQLSelect();
        }

        private static void RftSQLSelect()
        {
            try
            {
                sqlConnection!.Open();
                SqlCommand x = new("select * from Categories", sqlConnection);
                SqlDataReader y = x.ExecuteReader();
                if (y.HasRows)
                {
                    while (y.Read())
                    {
                        Console.WriteLine($"{y.GetInt32(0)}\t" +
                            $"{y.GetString(1)}\t" +
                            $"{y.GetString(2)}\t");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                sqlConnection!.Close();
            }
        }

        private static string RftVerifyLogin(string username, string password)
        {
            string id = "";
            try
            {
                RftSqlCommand.Parameters.Clear();
                RftSqlCommand.CommandText = "rft_sploginverify";
                _ = RftSqlCommand.Parameters.AddWithValue("@Username", username);
                _ = RftSqlCommand.Parameters.AddWithValue("@Password", password);
                sqlConnection!.Open();
                SqlDataReader RftSqlDataReader = RftSqlCommand.ExecuteReader();
                if (RftSqlDataReader.HasRows)
                {
                    _ = RftSqlDataReader.Read();
                    id = RftSqlDataReader.GetInt32(0).ToString();
                }
                RftSqlDataReader.Close();
            }
            catch (SqlException)
            {
                throw;
            }
            finally
            {
                sqlConnection!.Close();
            }

            return id;
        }
    }
}
