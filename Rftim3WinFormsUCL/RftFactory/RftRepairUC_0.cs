using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3WinFormsCL;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;

namespace Rftim3WinFormsUCL.RftFactory
{
    public partial class RftRepairUC_0 : UserControl
    {
        private readonly IRftUserControlCL rftUserControlCL;
        private readonly SqlConnection sqlConnectRepair;
        private readonly SqlConnection? sqlConnectT2;

        // Email smtp setup
        private readonly SmtpClient smtpClient = new();
        private MailMessage mailMessage = new();

        public RftRepairUC_0(IHost host)
        {
            InitializeComponent();

            rftUserControlCL = host.Services.GetRequiredService<IRftUserControlCL>();
            rftUserControlCL.RftUserControl = this;
            rftUserControlCL.RftContentProperties();

            RftDatabaseConnections sqlConn = host.Services.GetRequiredService<RftDatabaseConnections>();
            sqlConnectRepair = new SqlConnection(sqlConn.RepairConnection);

            // Refresh datagrid's at from load
            RefreshGridExcel(Excel_grid);
            SetupEmailQueryTo(Email_To_Grid);
            SetupEmailQueryCC(Email_CC_grid);
            RefreshGridExcelShiftReport(Email_shift_grid, toolStripStatusLabel3.Text!);

            // Setup email
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("groupEmail", "blank");
            smtpClient.Port = 25;
            smtpClient.EnableSsl = false;
            smtpClient.Host = "smtpa.domain.com";

            RefreshShiftLabel();

            // Determine hostname
            toolStripStatusLabel3.Text = Dns.GetHostName();

            comboBox1.Items.AddRange([
                "BROSE",
                "ELDOR",
                "GRUNDFOS",
                "ISKRA",
                "SAGINAW",
                "TRW",
                "NES",
                "METERSIT"
                ]);

            // Initialize combobox index at startup
            comboBox1.SelectedIndex = 3;

            // Refreshing datagrid'd
            RefreshGridStatusIN(IN_grid, SerialnumberIN_text_box.Text);
            RefreshGridStatusIN(IN_grid, SerialnumberOUT_text_box.Text);
            RefreshGridStatusOUT(OUT_grid, SerialnumberIN_text_box.Text);
            RefreshGridStatusOUT(OUT_grid, SerialnumberOUT_text_box.Text);
        }

        private void SerialnumberIN_text_box_Click(object sender, EventArgs e)
        {
            // Reseting color codes and messages when textbox clicked
            Result_group_box.BackColor = Color.Transparent;
            Result_label.Text = "";
            SerialnumberIN_text_box.Text = "";
        }

        private void SerialnumberOUT_text_box_Click(object sender, EventArgs e)
        {
            // Reseting color codes and messages when textbox clicked
            Result_group_box.BackColor = Color.Transparent;
            Result_label.Text = "";
            SerialnumberOUT_text_box.Text = "";
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Refreshing datagrid
            RefreshGridExcel(Excel_grid);
            StringBuilder stringBuilder = new();
            string columnHeaders = "";
            try
            {
                for (int i = 1; i < Excel_grid.Columns.Count + 1; i++)
                {
                    columnHeaders += $"{Excel_grid.Columns[i - 1].HeaderText},\t\t";
                }
                stringBuilder.Append($"{columnHeaders}{Environment.NewLine}{Environment.NewLine}");

                for (int i = 0; i < Excel_grid.Rows.Count; i++)
                {
                    for (int j = 0; j < Excel_grid.Columns.Count; j++)
                    {
                        stringBuilder.Append($"{Excel_grid.Rows[i].Cells[j].Value},\t\t");
                    }
                    stringBuilder.Append(Environment.NewLine);
                }
                // SaveAs file
                using SaveFileDialog saveFile = new()
                {
                    Filter = "CSV Files (*.csv)|*.csv",
                    FileName = $"Shift Repair {DateTime.Today:D}"
                };
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new(saveFile.FileName, false))
                    {
                        sw.WriteLine(stringBuilder.ToString());
                    }
                    MessageBox.Show("Raportul a fost salvat!");
                }
            }
            catch (Exception f)
            {
                f.ToString();
            }
            finally
            {
            }
        }

        private void SendReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RefreshShiftLabel();
            RefreshGridExcelShiftReport(Email_shift_grid, toolStripStatusLabel3.Text!);
            StringBuilder stringBuilder = new();
            string columnHeaders = "";
            string filePathName = "";

            // Try catch for sending email
            try
            {
                for (int i = 1; i < Email_shift_grid.Columns.Count + 1; i++)
                {
                    columnHeaders += $"{Email_shift_grid.Columns[i - 1].HeaderText},\t\t";
                }
                stringBuilder.Append($"{columnHeaders}{Environment.NewLine}{Environment.NewLine}");

                for (int i = 0; i < Email_shift_grid.Rows.Count; i++)
                {
                    for (int j = 0; j < Email_shift_grid.Columns.Count; j++)
                    {
                        stringBuilder.Append($"{Email_shift_grid.Rows[i].Cells[j].Value},\t\t");
                    }
                    stringBuilder.Append(Environment.NewLine);
                }
                // SaveAs file
                string filename = $"Shift Repair {DateTime.Today:D}.csv";
                string fullPath = @"C:\temp\" + filename;
                filePathName = fullPath;
                using StreamWriter sw = new(fullPath, false);
                sw.WriteLine(stringBuilder.ToString());

            }
            catch (Exception f)
            {
                f.ToString();
            }
            finally
            {
            }

            #region Email
            progressBar1.Minimum = 0;
            progressBar1.Maximum = Email_To_Grid.RowCount;
            progressBar1.Value = 0;
            progressBar1.Step = 1;

            mailMessage = new MailMessage
            {
                From = new MailAddress("emailGroup.com")
            };
            Attachment attachment = new(filePathName);
            mailMessage.Attachments.Add(attachment);
            mailMessage.Subject = $"Repair-Report-Shift-{toolStripStatusLabel1.Text} Station-{toolStripStatusLabel3.Text} {DateTime.Today:D}";
            mailMessage.IsBodyHtml = false;
            mailMessage.Body = "";

            foreach (DataGridViewRow item1 in Email_To_Grid.Rows)
            {
                foreach (DataGridViewCell item in item1.Cells)
                {
                    mailMessage.To.Add(item.Value!.ToString()!);
                    foreach (DataGridViewRow item3 in Email_CC_grid.Rows)
                    {
                        foreach (DataGridViewCell item2 in item3.Cells)
                        {
                            mailMessage.CC.Add(item2.Value!.ToString()!);
                        }
                    }
                }
                smtpClient.Send(mailMessage);
                mailMessage.To.Clear();
                progressBar1.PerformStep();
                progressBar1.Refresh();
            }
            attachment.Dispose();
            MessageBox.Show("RAPORTUL A FOST TRIMIS!");
            progressBar1.Value = 0;
            progressBar1.Refresh();
            File.Delete(filePathName);
            #endregion
        }

        private void LogOutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Hide();
            //LoginForm loginForm = new LoginForm();
            //loginForm.Show();
        }

        private void ExitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Closing app connections when exited
            //Application.Exit();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    RefreshGridStatusOUT(OUT_grid, SerialnumberIN_text_box.Text);
                    RefreshGridStatusIN(IN_grid, SerialnumberIN_text_box.Text);
                    Result_group_box.BackColor = Color.Transparent;
                    Result_label.Text = "";
                    RefreshGridStatusINComboBox(IN_grid, "BROSE");
                    break;
                case 1:
                    RefreshGridStatusOUT(OUT_grid, SerialnumberIN_text_box.Text);
                    RefreshGridStatusIN(IN_grid, SerialnumberIN_text_box.Text);
                    Result_group_box.BackColor = Color.Transparent;
                    Result_label.Text = "";
                    RefreshGridStatusINComboBox(IN_grid, "ELDOR");
                    break;
                case 2:
                    RefreshGridStatusOUT(OUT_grid, SerialnumberIN_text_box.Text);
                    RefreshGridStatusIN(IN_grid, SerialnumberIN_text_box.Text);
                    Result_group_box.BackColor = Color.Transparent;
                    Result_label.Text = "";
                    RefreshGridStatusINComboBox(IN_grid, "GRUNDFOS");
                    break;
                case 3:
                    RefreshGridStatusOUT(OUT_grid, SerialnumberIN_text_box.Text);
                    RefreshGridStatusIN(IN_grid, SerialnumberIN_text_box.Text);
                    Result_group_box.BackColor = Color.Transparent;
                    Result_label.Text = "";
                    RefreshGridStatusINComboBox(IN_grid, "ISKRA");
                    break;
                case 4:
                    RefreshGridStatusOUT(OUT_grid, SerialnumberIN_text_box.Text);
                    RefreshGridStatusIN(IN_grid, SerialnumberIN_text_box.Text);
                    Result_group_box.BackColor = Color.Transparent;
                    Result_label.Text = "";
                    RefreshGridStatusINComboBox(IN_grid, "SAGINAW");
                    break;
                case 5:
                    RefreshGridStatusOUT(OUT_grid, SerialnumberIN_text_box.Text);
                    RefreshGridStatusIN(IN_grid, SerialnumberIN_text_box.Text);
                    Result_group_box.BackColor = Color.Transparent;
                    Result_label.Text = "";
                    RefreshGridStatusINComboBox(IN_grid, "TRW");
                    break;
                case 6:
                    RefreshGridStatusOUT(OUT_grid, SerialnumberIN_text_box.Text);
                    RefreshGridStatusIN(IN_grid, SerialnumberIN_text_box.Text);
                    Result_group_box.BackColor = Color.Transparent;
                    Result_label.Text = "";
                    RefreshGridStatusINComboBox(IN_grid, "NES");
                    break;
                case 7:
                    RefreshGridStatusOUT(OUT_grid, SerialnumberIN_text_box.Text);
                    RefreshGridStatusIN(IN_grid, SerialnumberIN_text_box.Text);
                    Result_group_box.BackColor = Color.Transparent;
                    Result_label.Text = "";
                    RefreshGridStatusINComboBox(IN_grid, "METERSIT");
                    break;
                default: break;
            }
        }

        private void SendFullReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshGridExcel(Excel_grid);
            StringBuilder stringBuilder = new();
            string columnHeaders = "";
            string filePathName = "";

            try
            {

                for (int i = 1; i < Excel_grid.Columns.Count + 1; i++)
                {
                    columnHeaders += $"{Excel_grid.Columns[i - 1].HeaderText},\t\t";
                }
                stringBuilder.Append($"{columnHeaders}{Environment.NewLine}{Environment.NewLine}");

                for (int i = 0; i < Excel_grid.Rows.Count; i++)
                {
                    for (int j = 0; j < Excel_grid.Columns.Count; j++)
                    {
                        stringBuilder.Append($"{Excel_grid.Rows[i].Cells[j].Value!.ToString()},\t\t");
                    }
                    stringBuilder.Append(Environment.NewLine);
                }
                // SaveAs file
                string filename = "Full-Repair-Report.csv";
                string fullPath = $@"C:\temp\{filename}";
                filePathName = fullPath;
                using StreamWriter sw = new(fullPath, false);
                sw.WriteLine(stringBuilder.ToString());
            }
            catch (Exception f)
            {
                f.ToString();
            }
            finally
            {
            }

            progressBar1.Minimum = 0;
            progressBar1.Maximum = Email_To_Grid.RowCount;
            progressBar1.Value = 0;
            progressBar1.Step = 1;

            mailMessage = new MailMessage
            {
                From = new MailAddress("groupEmail.com")
            };
            Attachment attachment = new(filePathName);
            mailMessage.Attachments.Add(attachment);
            mailMessage.Subject = $"Repair-Report {DateTime.Today:D}";
            mailMessage.IsBodyHtml = false;
            mailMessage.Body = "";

            foreach (DataGridViewRow item1 in Email_To_Grid.Rows)
            {
                foreach (DataGridViewCell item in item1.Cells)
                {
                    mailMessage.To.Add(item.Value!.ToString()!);
                    //foreach (DataGridViewRow item3 in Email_CC_grid.Rows)
                    //{
                    //    foreach (DataGridViewCell item2 in item3.Cells)
                    //    {
                    //        mailMessage.CC.Add(item2.Value.ToString());
                    //    }
                    //}
                }
                smtpClient.Send(mailMessage);
                mailMessage.To.Clear();
                progressBar1.PerformStep();
                progressBar1.Refresh();
            }
            attachment.Dispose();
            MessageBox.Show("RAPORTUL A FOST TRIMIS!");
            progressBar1.Value = 0;
            progressBar1.Refresh();
            File.Delete(filePathName);
        }

        private void SerialnumberIN_text_box_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                // Check if serialnumber textbox is not empty
                if (SerialnumberIN_text_box.Text != "")
                {
                    // Check if serialnumber is valid
                    //if (SearchT2Query(SerialnumberIN_text_box.Text, comboBox1.GetItemText(comboBox1.SelectedItem)!) != "")
                    //{
                        // Check if serialnumber needs repairing
                        if ((GetQueryCounter(SerialnumberIN_text_box.Text, "IN") == GetQueryCounter(SerialnumberIN_text_box.Text, "OUT")) | GetQueryStatus(SerialnumberIN_text_box.Text) == "")
                        {
                            // Register serialnumber for repair
                            InsertIntoGrid(
                                GetQueryTimestamp(), 
                                toolStripStatusLabel3.Text!, 
                                toolStripStatusLabel2.Text!, 
                                SerialnumberIN_text_box.Text, 
                                //SearchT2ProductPartnumber(
                                //    SerialnumberIN_text_box.Text, 
                                //    comboBox1.GetItemText(comboBox1.SelectedItem)!), 
                                "",
                                comboBox1.GetItemText(comboBox1.SelectedItem)!, 
                                "IN", 
                                GetQueryCounterValue(SerialnumberIN_text_box.Text), 0);
                            RefreshGridStatusOUT(OUT_grid, SerialnumberIN_text_box.Text);
                            RefreshGridStatusIN(IN_grid, SerialnumberIN_text_box.Text);
                            SerialnumberIN_text_box.Text = "";
                            Result_group_box.BackColor = Color.Green;
                            Result_label.Text = "INREGISTRAT PENTRU REPAIR";
                        }
                        else
                        {
                            // Case when serialnumber is not for repair
                            SerialnumberIN_text_box.Text = "";
                            Result_group_box.BackColor = Color.Red;
                            Result_label.Text = "PENTRU REPAIR";
                        }
                    //}
                    // Case if textbox is empty when leaving
                    //else if (SearchT2Query(SerialnumberIN_text_box.Text, comboBox1.GetItemText(comboBox1.SelectedItem)!) == "")
                    //{
                    //    Result_group_box.BackColor = Color.Red;
                    //    Result_label.Text = "BAZA DE DATE GRESITA";
                    //    SerialnumberIN_text_box.Text = "";
                    //}
                }
                e.IsInputKey = true;
            }
        }

        private void SerialnumberOUT_text_box_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                // Check if serialnumber textbox is not empty
                if (SerialnumberOUT_text_box.Text != "")
                {
                    // Check if serialnumber is valid
                    //if (SearchT2Query(SerialnumberOUT_text_box.Text, comboBox1.GetItemText(comboBox1.SelectedItem)!) != "")
                    //{
                        // Check if serialnumber needs repairing
                        if (GetQueryCounter(SerialnumberOUT_text_box.Text, "IN") > GetQueryCounter(SerialnumberOUT_text_box.Text, "OUT"))
                        {
                            // Repairing serialnumber
                            UpdateGridComboBox(SerialnumberOUT_text_box.Text);
                            InsertIntoGrid(GetQueryTimestamp(),
                                toolStripStatusLabel3.Text!,
                                toolStripStatusLabel2.Text!,
                                SerialnumberOUT_text_box.Text,
                                //SearchT2ProductPartnumber(
                                //    SerialnumberOUT_text_box.Text,
                                //    comboBox1.GetItemText(comboBox1.SelectedItem)!),
                                "",
                                comboBox1.GetItemText(comboBox1.SelectedItem)!,
                                "OUT",
                                GetQueryCounterValue(SerialnumberOUT_text_box.Text), 
                                1);
                            RefreshGridStatusOUT(OUT_grid, SerialnumberOUT_text_box.Text);
                            RefreshGridStatusIN(IN_grid, SerialnumberOUT_text_box.Text);
                            Counter_lbl.Text = GetCounter(toolStripStatusLabel2.Text!);
                            RefreshChart(chart1, toolStripStatusLabel2.Text!);
                            SerialnumberOUT_text_box.Text = "";
                            Result_group_box.BackColor = Color.Green;
                            Result_label.Text = "REPARAT";
                        }
                        else
                        {
                            // Case when serialnumber is not registered for repairing
                            SerialnumberOUT_text_box.Text = "";
                            Result_group_box.BackColor = Color.Red;
                            Result_label.Text = "NEINREGISTRAT";
                        }
                    //}
                    // Case if textbox is empty when leaving
                    //else if (SearchT2Query(SerialnumberOUT_text_box.Text, comboBox1.GetItemText(comboBox1.SelectedItem)!) == "")
                    //{
                    //    Result_group_box.BackColor = Color.Red;
                    //    Result_label.Text = "BAZA DE DATE GRESITA";
                    //    SerialnumberOUT_text_box.Text = "";
                    //}
                }
                e.IsInputKey = true;
            }
        }

        private void RefreshShiftLabel()
        {
            // Determine the shift
            string hourSpan = DateTime.Now.ToString("HH");
            int hour = Convert.ToInt32(hourSpan);

            if (hour >= 6 && hour < 14) toolStripStatusLabel1.Text = "1";
            else if (hour >= 14 && hour < 22) toolStripStatusLabel1.Text = "2";
            else if (hour >= 22 || hour < 6) toolStripStatusLabel1.Text = "3";
        }


        #region Security
        private string VerifyCredentialsQuery(string username, string t2database)
        {
            string? returnedUser = "";
            try
            {
                sqlConnectT2.Open();
                using SqlCommand sqlCommand = new($"select password from [{t2database}-copy].dbo.USER_DATA where username = @username", sqlConnectT2);
                sqlCommand.Parameters.AddWithValue("@username", username);
                returnedUser = sqlCommand.ExecuteScalar().ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show(t2database.ToString());
                MessageBox.Show(e.ToString());
            }
            finally
            {
                sqlConnectT2.Close();
            }
            return returnedUser!;
        }
        #endregion

        #region SQL Connections
        //private static readonly SqlConnection sqlConnectT2 = new(ConfigurationManager.AppSettings["connectionStringT2"]);
        #endregion

        #region Queries
        private void RefreshGridStatusIN(DataGridView dataGridView, string serialnumber)
        {
            try
            {
                sqlConnectRepair.Open();
                using SqlDataAdapter dataAdapter = new("if (select COUNT(status) from REG_OF_REPAIR where serialnumber = @serialnumber and status = 'IN') "
                                                              + "!= (select COUNT(status) from REG_OF_REPAIR where serialnumber = @serialnumber and status = 'OUT')"
                                                              + "select timestamp, username, serialnumber, productpartnumber, t2database, status from REG_OF_REPAIR where serialnumber = @serialnumber and status = 'IN'", sqlConnectRepair);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@serialnumber", serialnumber);
                using DataTable dataTable = new();
                dataAdapter.Fill(dataTable);
                dataGridView.DataSource = dataTable;
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
                e.ToString();
            }
            finally
            {
                sqlConnectRepair.Close();
            }
        }
        private void RefreshGridStatusOUT(DataGridView dataGridView, string serialnumber)
        {
            try
            {
                sqlConnectRepair.Open();
                using SqlDataAdapter dataAdapter = new($"if (select COUNT(status) from REG_OF_REPAIR where serialnumber = @serialnumber and status = 'IN')"
                                                              + "!= (select COUNT(status) from REG_OF_REPAIR where serialnumber = @serialnumber and status = 'OUT')"
                                                              + "select timestamp, username, serialnumber, productpartnumber, t2database, status from REG_OF_REPAIR where serialnumber = @serialnumber and status = 'OUT'", sqlConnectRepair);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@serialnumber", serialnumber);
                using DataTable dataTable = new();
                dataAdapter.Fill(dataTable);
                dataGridView.DataSource = dataTable;
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
                e.ToString();
            }
            finally
            {
                sqlConnectRepair.Close();
            }
        }
        private void RefreshGridStatusINComboBox(DataGridView dataGridView, string database)
        {
            try
            {
                sqlConnectRepair.Open();
                using SqlDataAdapter sqlDataAdapter = new($"select timestamp, username, serialnumber, productpartnumber, t2database, status, counter from REG_OF_REPAIR where t2database = @database and repair = 0", sqlConnectRepair);
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@database", database);
                using DataTable dataTable = new();
                sqlDataAdapter.Fill(dataTable);
                dataGridView.DataSource = dataTable;
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
                e.ToString();
            }
            finally
            {
                sqlConnectRepair.Close();
            }
        }
        private void UpdateGridComboBox(string serialnumber)
        {
            try
            {
                sqlConnectRepair.Open();
                using SqlCommand sqlCommand = new($"update REG_OF_REPAIR set repair = 1 where serialnumber = @serialnumber", sqlConnectRepair);
                sqlCommand.Parameters.AddWithValue("@serialnumber", serialnumber);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
                e.ToString();
            }
            finally
            {
                sqlConnectRepair.Close();
            }
        }
        private void InsertIntoGrid(string timestamp, string hostanme, string username, string serialnumber, string productpartnumber, string t2database, string status, int counter, int repair)
        {
            try
            {
                sqlConnectRepair.Open();
                using SqlCommand sqlCommand = new($"insert into REG_OF_REPAIR values(@timestamp,@hostname,@username,@serialnumber,@productpartnumber,@t2database,@status,@counter,@repair)", sqlConnectRepair);
                sqlCommand.Parameters.AddWithValue("@timestamp", timestamp);
                sqlCommand.Parameters.AddWithValue("@hostname", hostanme);
                sqlCommand.Parameters.AddWithValue("@username", username);
                sqlCommand.Parameters.AddWithValue("@serialnumber", serialnumber);
                sqlCommand.Parameters.AddWithValue("@productpartnumber", productpartnumber);
                sqlCommand.Parameters.AddWithValue("@t2database", t2database);
                sqlCommand.Parameters.AddWithValue("@status", status);
                sqlCommand.Parameters.AddWithValue("@counter", counter);
                sqlCommand.Parameters.AddWithValue("@repair", repair);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
                e.ToString();
            }
            finally
            {
                sqlConnectRepair.Close();
            }
        }
        private string GetQueryStatus(string serialnumber)
        {
            string? status = "";
            try
            {
                sqlConnectRepair.Open();
                using SqlCommand sqlCommand = new("select status from REG_OF_REPAIR where serialnumber = @serialnumber", sqlConnectRepair);
                sqlCommand.Parameters.AddWithValue("@serialnumber", serialnumber);
                status = sqlCommand.ExecuteScalar().ToString();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
                e.ToString();
            }
            finally
            {
                sqlConnectRepair.Close();
            }
            return status!;
        }
        private int GetQueryCounter(string serialnumber, string status)
        {
            int intValue = 0;
            try
            {
                sqlConnectRepair.Open();
                using SqlCommand sqlCommand = new($"select count(counter) from REG_OF_REPAIR where serialnumber = @serialnumber and status = @status", sqlConnectRepair);
                sqlCommand.Parameters.AddWithValue("@serialnumber", serialnumber);
                sqlCommand.Parameters.AddWithValue("@status", status);
                intValue = Convert.ToInt32(sqlCommand.ExecuteScalar());
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
                e.ToString();
            }
            finally
            {
                sqlConnectRepair.Close();
            }
            return intValue;
        }
        private int GetQueryCounterValue(string serialnumber)
        {
            int counter = 0;
            try
            {
                sqlConnectRepair.Open();
                using SqlCommand sqlCommand = new($"select count(status) from REG_OF_REPAIR where serialnumber = @serialnumber", sqlConnectRepair);
                sqlCommand.Parameters.AddWithValue("@serialnumber", serialnumber);
                counter = Convert.ToInt32(sqlCommand.ExecuteScalar()) + 1;
            }
            catch (Exception e)
            {
                // MessageBox.Show(e.ToString());
                e.ToString();
            }
            finally
            {
                sqlConnectRepair.Close();
            }
            return counter;
        }
        private string SearchT2ProductPartnumber(string serialnumber, string database)
        {
            string? partnumber = "";
            try
            {
                sqlConnectT2.Open();
                using SqlCommand sqlCommand = new($"select extproductpartnumber from [{database}-copy].dbo.SERIAL_NUMBERS where serialnumber = @serialnumber", sqlConnectT2);
                sqlCommand.Parameters.AddWithValue("@serialnumber", serialnumber);
                partnumber = sqlCommand.ExecuteScalar().ToString();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
                e.ToString();
            }
            finally
            {
                sqlConnectT2.Close();
            }
            return partnumber!;
        }
        private string SearchT2Query(string serialnumber, string database)
        {
            string? serial = "";
            try
            {
                sqlConnectT2.Open();
                using SqlCommand sqlCommand = new($"select serialnumber from [{database}-copy].dbo.SERIAL_NUMBERS where serialnumber = @serialnumber", sqlConnectT2);
                sqlCommand.Parameters.AddWithValue("@serialnumber", serialnumber);
                serial = sqlCommand.ExecuteScalar().ToString();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
                e.ToString();
            }
            finally
            {
                sqlConnectT2.Close();
            }
            return serial!;
        }
        private string GetQueryTimestamp()
        {
            string? timestamp = "";
            try
            {
                sqlConnectRepair.Open();
                using SqlCommand sqlCommand = new($"declare @crttime datetime = current_timestamp select convert(varchar(50), @crttime, 121)", sqlConnectRepair);
                timestamp = sqlCommand.ExecuteScalar().ToString();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
                e.ToString();
            }
            finally
            {
                sqlConnectRepair.Close();
            }
            return timestamp!;
        }
        private void RefreshGridExcel(DataGridView dataGridView)
        {
            try
            {
                sqlConnectRepair.Open();
                using SqlDataAdapter sqlDataAdapter = new("select timestamp, username, serialnumber, productpartnumber, t2database, status, counter from REG_OF_REPAIR order by serialnumber, counter", sqlConnectRepair);
                using DataTable dataTable = new();
                sqlDataAdapter.Fill(dataTable);
                dataGridView.DataSource = dataTable;
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
                e.ToString();
            }
            finally
            {
                sqlConnectRepair.Close();
            }
        }
        private void RefreshGridExcelShiftReport(DataGridView dataGridView, string hostname)
        {
            string dateSpan = DateTime.Today.ToString("yyyy-MM-dd");
            string dateSpanYesterday = DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd");
            string hourSpan = DateTime.Now.ToString("HH");
            int hour = Convert.ToInt32(hourSpan);

            try
            {
                sqlConnectRepair.Open();
                if (hour >= 6 && hour < 14)
                {
                    using SqlDataAdapter sqlDataAdapter = new("select timestamp, username, serialnumber, productpartnumber, t2database, status, counter from REG_OF_REPAIR where timestamp between '" + dateSpan + " 06:00:00.000' and '" + dateSpan + " 14:00:00.000' and hostname = @hostname order by serialnumber, counter", sqlConnectRepair);
                    sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@hostname", hostname);
                    using DataTable dataTable = new();
                    sqlDataAdapter.Fill(dataTable);
                    dataGridView.DataSource = dataTable;
                }
                else if (hour >= 14 && hour < 22)
                {
                    using SqlDataAdapter sqlDataAdapter = new("select timestamp, username, serialnumber, productpartnumber, t2database, status, counter from REG_OF_REPAIR where timestamp between '" + dateSpan + " 14:00:00.000' and '" + dateSpan + " 22:00:00.000' and hostname = @hostname order by serialnumber, counter", sqlConnectRepair);
                    sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@hostname", hostname);
                    using DataTable dataTable = new();
                    sqlDataAdapter.Fill(dataTable);
                    dataGridView.DataSource = dataTable;
                }
                else if (hour >= 0 && hour < 6)
                {
                    using SqlDataAdapter sqlDataAdapter = new("select timestamp, username, serialnumber, productpartnumber, t2database, status, counter from REG_OF_REPAIR where timestamp between '" + dateSpanYesterday + " 22:00:00.000' and '" + dateSpan + " 06:00:00.000' and hostname = @hostname order by serialnumber, counter", sqlConnectRepair);
                    sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@hostname", hostname);
                    using DataTable dataTable = new();
                    sqlDataAdapter.Fill(dataTable);
                    dataGridView.DataSource = dataTable;
                }
                else if (hour >= 22 && hour < 24)
                {
                    using SqlDataAdapter sqlDataAdapter = new("select timestamp, username, serialnumber, productpartnumber, t2database, status, counter from REG_OF_REPAIR where timestamp between '" + dateSpan + " 22:00:00.000' and '" + dateSpan + " 23:59:59.999' and hostname = @hostname order by serialnumber, counter", sqlConnectRepair);
                    sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@hostname", hostname);
                    using DataTable dataTable = new();
                    sqlDataAdapter.Fill(dataTable);
                    dataGridView.DataSource = dataTable;
                }

            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
                e.ToString();
            }
            finally
            {
                sqlConnectRepair.Close();
            }
        }
        private void DeleteFromGrid(string whereValue)
        {
            try
            {
                sqlConnectRepair.Open();
                using SqlCommand sqlCommand = new("delete from REG_OF_REPAIR where serialnumber = @whereValue", sqlConnectRepair);
                sqlCommand.Parameters.AddWithValue("@whereValue", whereValue);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
                e.ToString();
            }
            finally
            {
                sqlConnectRepair.Close();
            }
        }
        private void RefreshChart(Chart chart, string username)
        {
            chart.Series["Default"].Points.Clear();
            chart.Legends["Legend1"].CustomItems.Clear();
            string dateSpan = DateTime.Today.ToString("yyyy-MM-dd");
            string dateSpanYesterday = DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd");
            string hourSpan = DateTime.Now.ToString("HH");
            int hour = Convert.ToInt32(hourSpan);
            int index = 0;
            Random random = new();
            chart.Series[0].IsVisibleInLegend = false;
            try
            {
                sqlConnectRepair.Open();
                Color color = new();
                if (hour >= 6 && hour < 14)
                {
                    using SqlCommand sqlCommand = new($"select productpartnumber,count(status) as Total from REG_OF_REPAIR where status = 'OUT' and timestamp between '{dateSpan} 06:00:00.000' and '{dateSpan} 14:00:00.000' and username = @username group by GROUPING sets((t2database,productpartnumber)) order by productpartnumber", sqlConnectRepair);
                    sqlCommand.Parameters.AddWithValue("@username", username);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        color = Color.FromArgb(random.Next(25), random.Next(256), 255);
                        LegendItem legendItem = new();
                        chart.Series["Default"].Points.AddXY(sqlDataReader["productpartnumber"].ToString(), sqlDataReader["Total"]);
                        chart.Series["Default"].Points[index++].Color = color;
                        chart.Legends["Legend1"].CustomItems.Add(color, sqlDataReader["productpartnumber"].ToString());
                    }
                }
                else if (hour >= 14 && hour < 22)
                {
                    using SqlCommand sqlCommand = new($"select productpartnumber,count(status) as Total from REG_OF_REPAIR where status = 'OUT' and timestamp between '{dateSpan} 14:00:00.000' and '{dateSpan} 22:00:00.000' and username = @username group by GROUPING sets((t2database,productpartnumber)) order by productpartnumber", sqlConnectRepair);
                    sqlCommand.Parameters.AddWithValue("@username", username);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        color = Color.FromArgb(random.Next(25), random.Next(256), 255);
                        LegendItem legendItem = new();
                        chart.Series["Default"].Points.AddXY(sqlDataReader["productpartnumber"].ToString(), sqlDataReader["Total"]);
                        chart.Series["Default"].Points[index++].Color = color;
                        chart.Legends["Legend1"].CustomItems.Add(color, sqlDataReader["productpartnumber"].ToString());
                    }
                }
                else if (hour >= 0 && hour < 6)
                {
                    using SqlCommand sqlCommand = new($"select productpartnumber,count(status) as Total from REG_OF_REPAIR where status = 'OUT' and timestamp between '{dateSpanYesterday} 22:00:00.000' and '{dateSpan} 06:00:00.000' and username = @username group by GROUPING sets((t2database,productpartnumber)) order by productpartnumber", sqlConnectRepair);
                    sqlCommand.Parameters.AddWithValue("@username", username);
                    Series series = chart.Series["Default"];
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        color = Color.FromArgb(random.Next(25), random.Next(256), 255);
                        LegendItem legendItem = new();
                        chart.Series["Default"].Points.AddXY(sqlDataReader["productpartnumber"].ToString(), sqlDataReader["Total"]);
                        chart.Series["Default"].Points[index++].Color = color;
                        chart.Legends["Legend1"].CustomItems.Add(color, sqlDataReader["productpartnumber"].ToString());
                    }
                }
                else if (hour >= 22 && hour < 24)
                {
                    using SqlCommand sqlCommand = new($"select productpartnumber,count(status) as Total from REG_OF_REPAIR where status = 'OUT' and timestamp between '{dateSpan} 22:00:00.000' and '{dateSpan} 23:59:59.999' and username = @username group by GROUPING sets((t2database,productpartnumber)) order by productpartnumber", sqlConnectRepair);
                    sqlCommand.Parameters.AddWithValue("@username", username);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        color = Color.FromArgb(random.Next(25), random.Next(256), 255);
                        LegendItem legendItem = new();
                        chart.Series["Default"].Points.AddXY(sqlDataReader["productpartnumber"].ToString(), sqlDataReader["Total"]);
                        chart.Series["Default"].Points[index++].Color = color;
                        chart.Legends["Legend1"].CustomItems.Add(color, sqlDataReader["productpartnumber"].ToString());
                    }
                }

            }
            catch (Exception e)
            {
                e.ToString();
            }
            finally
            {
                sqlConnectRepair.Close();
            }
        }
        private string GetCounter(string username)
        {
            string? counter = "";
            string dateSpan = DateTime.Today.ToString("yyyy-MM-dd");
            string dateSpanYesterday = DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd");
            string hourSpan = DateTime.Now.ToString("HH");
            int hour = Convert.ToInt32(hourSpan);

            try
            {
                sqlConnectRepair.Open();
                if (hour >= 6 && hour < 14)
                {
                    using SqlCommand sqlCommand = new($"select count(status) from REG_OF_REPAIR where status = 'OUT' and timestamp between '{dateSpan} 06:00:00.000' and '{dateSpan} 14:00:00.000' and username = @username", sqlConnectRepair);
                    sqlCommand.Parameters.AddWithValue("@username", username);
                    counter = sqlCommand.ExecuteScalar().ToString();
                }
                else if (hour >= 14 && hour < 22)
                {
                    using SqlCommand sqlCommand = new($"select count(status) from REG_OF_REPAIR where status = 'OUT' and timestamp between '{dateSpan} 14:00:00.000' and '{dateSpan} 22:00:00.000' and username = @username", sqlConnectRepair);
                    sqlCommand.Parameters.AddWithValue("@username", username);
                    counter = sqlCommand.ExecuteScalar().ToString();
                }
                else if (hour >= 0 && hour < 6)
                {
                    using SqlCommand sqlCommand = new($"select count(status) from REG_OF_REPAIR where status = 'OUT' and timestamp between '{dateSpanYesterday} 22:00:00.000' and '{dateSpan} 06:00:00.000' and username = @username", sqlConnectRepair);
                    sqlCommand.Parameters.AddWithValue("@username", username);
                    counter = sqlCommand.ExecuteScalar().ToString();
                }
                else if (hour >= 22 && hour < 24)
                {
                    using SqlCommand sqlCommand = new($"select count(status) from REG_OF_REPAIR where status = 'OUT' and timestamp between '{dateSpan} 22:00:00.000' and '{dateSpan} 23:59:59.999' and username = @username", sqlConnectRepair);
                    sqlCommand.Parameters.AddWithValue("@username", username);
                    counter = sqlCommand.ExecuteScalar().ToString();
                }

            }
            catch (Exception e)
            {
                e.ToString();
            }
            finally
            {
                sqlConnectRepair.Close();
            }
            return counter!;
        }
        #endregion

        #region Email Setup
        private void SetupEmailQueryTo(DataGridView dataGridView)
        {
            try
            {
                sqlConnectRepair.Open();
                using SqlDataAdapter sqlDataAdapter = new("select email from REG_OF_EMAIL where mode = 'To'", sqlConnectRepair);
                using DataTable dataTable = new();
                sqlDataAdapter.Fill(dataTable);
                dataGridView.DataSource = dataTable;
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
                e.ToString();
            }
            finally
            {
                sqlConnectRepair.Close();
            }
        }
        private void SetupEmailQueryCC(DataGridView dataGridView)
        {
            try
            {
                sqlConnectRepair.Open();
                using SqlDataAdapter sqlDataAdapter = new("select email from REG_OF_EMAIL where mode = 'CC'", sqlConnectRepair);
                using DataTable dataTable = new();
                sqlDataAdapter.Fill(dataTable);
                dataGridView.DataSource = dataTable;
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
                e.ToString();
            }
            finally
            {
                sqlConnectRepair.Close();
            }
        }
        #endregion
    }
}
