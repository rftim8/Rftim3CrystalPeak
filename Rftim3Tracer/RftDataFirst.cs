using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Rftim3Tracer
{
    public class RftDataFirst
    {
        private static IConfiguration? config;
        private static SqlConnection? sqlConn;

        public RftDataFirst()
        {
            //config = new IConfigurationBuilder()
            //    .AddUserSecrets<RftDataFirst>()
            //    .Build();
            //sqlConn = new SqlConnection(config?.GetConnectionString(IRftDBNamesService.RftDBs.NorthwindDB.ToString()));

            ////RftSelect(sqlConn);
            ////RftStoredProcedure(sqlConn);
            //RftDataSet(sqlConn);
        }

        private static void RftSelect(SqlConnection sqlConn)
        {
            try
            {
                sqlConn.Open();

                using SqlCommand rftSqlCommand = new()
                {
                    Connection = sqlConn,
                    CommandType = CommandType.Text,
                    CommandText = "select * from Employees"
                };

                using SqlDataReader reader = rftSqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[0]} {reader[1]} {reader[2]}");
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static void RftStoredProcedure(SqlConnection sqlConn)
        {
            try
            {
                sqlConn.Open();

                using SqlCommand rftSqlCommand = new()
                {
                    Connection = sqlConn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "CustOrderHist"
                };
                rftSqlCommand.Parameters.Add("@CustomerID", SqlDbType.NChar, 5).Value = "BSBEV";

                using SqlDataReader reader = rftSqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[0]} {reader[1]}");
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static void RftDataSet(SqlConnection sqlConn)
        {
            try
            {
                sqlConn.Open();
                using SqlDataAdapter sqlDataAdapter = new("select * from Employees where EmployeeID <> @id", sqlConn);
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@id", 1);
                DataSet dataSet = new();
                sqlDataAdapter.Fill(dataSet, "EmployeeID");

                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    Console.WriteLine(dataSet.Tables[0].Rows[i]["EmployeeID"]);
                }
            }
            catch (Exception e)
            {
                e.ToString();
            }
            finally
            {
                sqlConn.Close();
            }
        }
    }
}
