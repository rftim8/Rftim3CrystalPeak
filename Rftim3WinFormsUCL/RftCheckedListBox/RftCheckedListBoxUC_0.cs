using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3WinFormsCL;
using System.Data;

namespace Rftim3WinFormsUCL.RftCheckedListBox
{
    public partial class RftCheckedListBoxUC_0 : UserControl
    {
        private readonly SqlConnection leetCodeConnection;

        private readonly IRftUserControlCL rftUserControlCL;

        public RftCheckedListBoxUC_0(IHost host)
        {
            InitializeComponent();

            rftUserControlCL = host.Services.GetRequiredService<IRftUserControlCL>();
            rftUserControlCL.RftUserControl = this;
            rftUserControlCL.RftContentProperties();

            RftDatabaseConnections sqlConnection = host.Services.GetRequiredService<RftDatabaseConnections>();
            leetCodeConnection = new SqlConnection(sqlConnection.LeetCodeConnection);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();

            try
            {
                leetCodeConnection.Open();
                SqlCommand sqlCommand = new("select * from _00175_CombineTwoTables_Address", leetCodeConnection);
                SqlDataAdapter sqlDataAdapter = new(sqlCommand);
                DataSet dataSet = new();
                sqlDataAdapter.Fill(dataSet);
                for (int i = 0; i <= dataSet.Tables.Count; i++)
                {
                    checkedListBox1.Items.Add($"{dataSet.Tables[0].Rows[i]["addressId"]} ; " +
                        $"{dataSet.Tables[0].Rows[i]["personId"]} ; " +
                        $"{dataSet.Tables[0].Rows[i]["city"]} ; " +
                        $"{dataSet.Tables[0].Rows[i]["state"]}");
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                leetCodeConnection.Close();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
        }
    }
}
