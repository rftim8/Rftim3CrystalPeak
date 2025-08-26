using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3WinFormsCL;
using System.Data;
using System.Text;

namespace Rftim3WinFormsUCL.RftSQL
{
    public partial class RftMSSQLUC_0 : UserControl
    {
        private readonly SqlConnection sqlConn;
        private readonly IRftUserControlCL rftUserControlCL;

        public RftMSSQLUC_0(IHost host)
        {
            InitializeComponent();

            rftUserControlCL = host.Services.GetRequiredService<IRftUserControlCL>();
            rftUserControlCL.RftUserControl = this;
            rftUserControlCL.RftContentProperties();

            RftDatabaseConnections sqlConnection = host.Services.GetRequiredService<RftDatabaseConnections>();
            sqlConn = new SqlConnection(sqlConnection.NorthwindConnection);
            //RefreshGrid();
        }

        private void RefreshGrid()
        {
            try
            {
                sqlConn.Open();
                SqlDataAdapter dataAdapter = new("select * from Mok0", sqlConn);
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
            try
            {
                sqlConn.Open();
                SqlCommand sqlCommand = new("insert into Mok0 values(CURRENT_TIMESTAMP,@value0,@value1,@value2,@value3,@value4)", sqlConn);
                sqlCommand.Parameters.AddWithValue("@value0", textBox1.Text);
                sqlCommand.Parameters.AddWithValue("@value1", textBox2.Text);
                sqlCommand.Parameters.AddWithValue("@value2", numericUpDown1.Value);
                sqlCommand.Parameters.AddWithValue("@value3", decimal.Parse($"{numericUpDown2.Value}.{numericUpDown3.Value}"));
                sqlCommand.Parameters.AddWithValue("@value4", checkBox1.Checked);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConn.Close();
            }

            RefreshGrid();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                sqlConn.Open();
                SqlCommand sqlCommand = new("update Mok0 set timestamp=CURRENT_TIMESTAMP, name=@value0, surname=@value1, age=@value2, height=@value3, gender=@value4 where id = @value5", sqlConn);
                sqlCommand.Parameters.AddWithValue("@value0", textBox1.Text);
                sqlCommand.Parameters.AddWithValue("@value1", textBox2.Text);
                sqlCommand.Parameters.AddWithValue("@value2", numericUpDown1.Value);
                sqlCommand.Parameters.AddWithValue("@value3", decimal.Parse($"{numericUpDown2.Value}.{numericUpDown3.Value}"));
                sqlCommand.Parameters.AddWithValue("@value4", checkBox1.Checked);
                sqlCommand.Parameters.AddWithValue("@value5", numericUpDown4.Value);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConn.Close();
            }

            RefreshGrid();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                sqlConn.Open();
                SqlCommand sqlCommand = new("delete Mok0 where id = @value0", sqlConn);
                sqlCommand.Parameters.AddWithValue("@value0", numericUpDown4.Value);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConn.Close();
            }

            RefreshGrid();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0) return;
            StringBuilder sb = new();

            string columnsHeader = "";
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                columnsHeader += dataGridView1.Columns[i].Name + ",";
            }
            sb.Append(columnsHeader + Environment.NewLine);

            foreach (DataGridViewRow dgvRow in dataGridView1.Rows)
            {
                if (!dgvRow.IsNewRow)
                {
                    for (int c = 0; c < dgvRow.Cells.Count; c++)
                    {
                        sb.Append(dgvRow.Cells[c].Value + ",");
                    }
                    sb.Append(Environment.NewLine);
                }
            }

            SaveFileDialog sfd = new()
            {
                Filter = "CSV files (*.csv)|*.csv"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using StreamWriter sw = new(sfd.FileName, false);
                sw.WriteLine(sb.ToString());
            }

            MessageBox.Show("CSV file saved.");

        }
    }
}
