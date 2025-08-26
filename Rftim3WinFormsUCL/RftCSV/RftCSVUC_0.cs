using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3WinFormsCL;
using System.Data;
using System.Text;

namespace Rftim3WinFormsUCL.RftCSV
{
    public partial class RftCSVUC_0 : UserControl
    {
        private readonly SqlConnection sqlConn;
        private readonly IRftUserControlCL rftUserControlCL;

        public RftCSVUC_0(IHost host)
        {
            InitializeComponent();

            rftUserControlCL = host.Services.GetRequiredService<IRftUserControlCL>();
            rftUserControlCL.RftUserControl = this;
            rftUserControlCL.RftContentProperties();

            RftDatabaseConnections sqlConnection = host.Services.GetRequiredService<RftDatabaseConnections>();
            sqlConn = new SqlConnection(sqlConnection.LeetCodeConnection);

            RefreshGrid();
        }

        private void RefreshGrid()
        {
            try
            {
                sqlConn.Open();
                SqlDataAdapter dataAdapter = new("select * from _00175_CombineTwoTables_Address", sqlConn);
                DataTable dataTable = new();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                sqlConn.Close();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            RftWriteToCSVFile(dataGridView1);
        }

        public static void RftWriteToCSVFile(DataGridView dataGridView)
        {
            if (dataGridView.Rows.Count == 0) return;

            StringBuilder sb = new();

            string columnsHeader = "";
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                columnsHeader += $"{dataGridView.Columns[i].Name},";
            }
            sb.Append($"{columnsHeader}{Environment.NewLine}");

            foreach (DataGridViewRow dgvRow in dataGridView.Rows)
            {
                if (!dgvRow.IsNewRow)
                {
                    for (int c = 0; c < dgvRow.Cells.Count; c++)
                    {
                        sb.Append($"{dgvRow.Cells[c].Value},");
                    }
                    sb.Append(Environment.NewLine);
                }
            }

            Thread thread = new(() =>
            {
                using SaveFileDialog dialog = new();
                dialog.Filter = "CSV files (*.csv)|*.csv";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    using StreamWriter sw = new(dialog.FileName, false);
                    sw.WriteLine(sb.ToString());
                }
    
                MessageBox.Show("CSV file saved.");
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
    }
}
