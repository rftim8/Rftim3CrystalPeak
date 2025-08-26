using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3WinFormsCL;
using System.Data;

namespace Rftim3WinFormsUCL.RftDataGridView
{
    public partial class RftDataGridViewUC_0 : UserControl
    {
        private readonly SqlConnection sqlConn;
        private readonly SqlConnection sqlConnNorth;
        private int contextMenuRowIndex;
        private readonly string newLine = Environment.NewLine;
        private readonly IRftUserControlCL rftUserControlCL;

        public RftDataGridViewUC_0(IHost host)
        {
            InitializeComponent();

            rftUserControlCL = host.Services.GetRequiredService<IRftUserControlCL>();
            rftUserControlCL.RftUserControl = this;
            rftUserControlCL.RftContentProperties();


            RftDatabaseConnections sqlConnection = host.Services.GetRequiredService<RftDatabaseConnections>();
            sqlConn = new SqlConnection(sqlConnection.LeetCodeConnection);
            sqlConnNorth = new SqlConnection(sqlConnection.NorthwindConnection);

            Sample2();
            Sample3();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                sqlConn.Open();
                SqlDataAdapter sqlDataAdapter = new("select * from _00175_CombineTwoTables_Address", sqlConn);
                DataTable dataTable = new();
                sqlDataAdapter.Fill(dataTable);
                dataGridView10.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                sqlConn.Close();
            }
        }

        #region Sample 1
        private readonly ContextMenuStrip employeeMenuStrip = new();
        private readonly ContextMenuStrip managerMenuStrip = new();
        private readonly ToolStripMenuItem toolStripMenuItem1 = new();
        private readonly ToolStripMenuItem toolStripMenuItem2 = new();
        private readonly ToolStripMenuItem toolStripMenuItem3 = new();

        protected override void OnLoad(EventArgs e)
        {
            toolStripMenuItem1.Text = "View Employee Sales Report";
            toolStripMenuItem2.Text = "View Team Sales Report";
            toolStripMenuItem3.Text = "View Company Sales Team Ranking Report";
            dataGridView1.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(DataGridView1_DataBindingComplete!);
            dataGridView1.CellToolTipTextNeeded += new DataGridViewCellToolTipTextNeededEventHandler(DataGridView1_CellToolTipTextNeeded!);
            dataGridView1.RowContextMenuStripNeeded += new DataGridViewRowContextMenuStripNeededEventHandler(DataGridView1_RowContextMenuStripNeeded!);
            toolStripMenuItem1.Click += new EventHandler(ToolStripMenuItem1_Click!);
            toolStripMenuItem2.Click += new EventHandler(ToolStripMenuItem2_Click!);
            toolStripMenuItem3.Click += new EventHandler(ToolStripMenuItem3_Click!);

            employeeMenuStrip.Items.Add(toolStripMenuItem1);

            managerMenuStrip.Items.Add(toolStripMenuItem2);
            managerMenuStrip.Items.Add(toolStripMenuItem3);

            PopulateDataGridView();

            base.OnLoad(e);
        }

        private void PopulateDataGridView()
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToDeleteRows = false;

            string query = "SELECT e1.*, e2.FirstName + ' ' + e2.LastName AS Manager "
                + "FROM employees AS e1 LEFT JOIN employees AS e2 "
                + "ON e1.ReportsTo = e2.EmployeeID";

            SqlDataAdapter sqlDataAdapter1 = new(query, sqlConnNorth);

            DataTable dataTable1 = new()
            {
                Locale = System.Globalization.CultureInfo.InvariantCulture
            };
            sqlDataAdapter1.Fill(dataTable1);

            dataGridView1.DataSource = dataTable1;
        }

        private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.Columns["EmployeeID"]!.Visible = false;
            dataGridView1.Columns["Address"]!.Visible = false;
            dataGridView1.Columns["TitleOfCourtesy"]!.Visible = false;
            dataGridView1.Columns["BirthDate"]!.Visible = false;
            dataGridView1.Columns["HireDate"]!.Visible = false;
            dataGridView1.Columns["PostalCode"]!.Visible = false;
            dataGridView1.Columns["Photo"]!.Visible = false;
            dataGridView1.Columns["Notes"]!.Visible = false;
            dataGridView1.Columns["ReportsTo"]!.Visible = false;
            dataGridView1.Columns["PhotoPath"]!.Visible = false;

            foreach (DataGridViewColumn i in dataGridView1.Columns)
            {
                i.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dataGridView1.AutoResizeColumns();
        }

        private void DataGridView1_RowContextMenuStripNeeded(object sender, DataGridViewRowContextMenuStripNeededEventArgs e)
        {
            DataGridViewRow dataGridViewRow1 = dataGridView1.Rows[e.RowIndex];

            toolStripMenuItem1.Enabled = true;

            if ((dataGridViewRow1.Cells["Title"].Value!.ToString() == "Sales Manager") || (dataGridViewRow1.Cells["Title"].Value!.ToString() == "Vice President, Sales"))
            {
                e.ContextMenuStrip = managerMenuStrip;
            }
            else e.ContextMenuStrip = employeeMenuStrip;

            contextMenuRowIndex = e.RowIndex;
        }

        private void DataGridView1_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow dataGridViewRow1 = dataGridView1.Rows[e.RowIndex];

                e.ToolTipText = $"EmployeeID {dataGridViewRow1.Cells["EmployeeID"].Value}:{newLine}";
                e.ToolTipText += $"{dataGridViewRow1.Cells["TitleOfCourtesy"].Value} {dataGridViewRow1.Cells["FirstName"].Value} {dataGridViewRow1.Cells["LastName"].Value}{newLine}";
                e.ToolTipText += $"{dataGridViewRow1.Cells["Title"].Value}{newLine}{newLine}";
                e.ToolTipText += $"{dataGridViewRow1.Cells["Address"].Value}{newLine}{dataGridViewRow1.Cells["City"].Value}, ";
                if (!string.IsNullOrEmpty(dataGridViewRow1.Cells["Region"].Value!.ToString()))
                {
                    e.ToolTipText += $"{dataGridViewRow1.Cells["Region"].Value}, ";
                }
                e.ToolTipText += $"{dataGridViewRow1.Cells["Country"].Value}, {dataGridViewRow1.Cells["PostalCode"].Value}{newLine}{dataGridViewRow1.Cells["HomePhone"].Value} " +
                    $"EXT:{dataGridViewRow1.Cells["Extension"].Value}{newLine}{newLine}";

                DateTime HireDate = (DateTime)dataGridViewRow1.Cells["HireDate"].Value!;
                e.ToolTipText += $"Employee since: {HireDate.Month}/{HireDate.Day}/{HireDate.Year}{newLine}Manager: {dataGridViewRow1.Cells["Manager"].Value}";
            }
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataGridViewRow dataGridViewRow1 = dataGridView1.Rows[contextMenuRowIndex];
            MessageBox.Show($"Sales Report for {dataGridViewRow1.Cells["FirstName"].Value} {dataGridViewRow1.Cells["LastName"].Value}{newLine}{newLine}Reporting not implemented.");
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DataGridViewRow dataGridViewRow1 = dataGridView1.Rows[contextMenuRowIndex];
            MessageBox.Show($"Sales Report for {dataGridViewRow1.Cells["FirstName"].Value} {dataGridViewRow1.Cells["LastName"].Value}'s Team{newLine}{newLine}Reporting not implemented.");
        }

        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            _ = dataGridView1.Rows[contextMenuRowIndex];
            MessageBox.Show($"Company Sales Ranking Report:{newLine}{newLine}Reporting not implemented.");
        }
        #endregion

        #region Sample 2
        private readonly ToolStripMenuItem wholeTable = new();
        private readonly ToolStripMenuItem lookUp = new();
        private ContextMenuStrip? strip;
        private string? cellErrorText;
        private readonly Label count = new();
        private int unsharedRowCounter;

        private void Sample2()
        {
            label1.Text = "Unshared Rows: ";
            label1.AutoSize = true;
            count.AutoSize = true;

            label2.AutoSize = true;
            label2.Text =
                "Try out the contextual menu, and hovering over the cells in the 'ReportsTo' column. " +
                "Notice what happens when trying to lookup a picture cell. " +
                "Row unsharing is minimized through the use of events.";

            dataGridView2.MultiSelect = false;
            dataGridView2.ReadOnly = true;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            wholeTable.Click += new EventHandler(WholeTable_Click!);
            lookUp.Click += new EventHandler(LookUp_Click!);
            dataGridView2.RowUnshared += new DataGridViewRowEventHandler(DataGridView2_RowUnshared!);
            dataGridView2.CellMouseEnter += new DataGridViewCellEventHandler(DataGridView2_CellMouseEnter!);
            dataGridView2.CellErrorTextNeeded += new DataGridViewCellErrorTextNeededEventHandler(DataGridView2_CellErrorTextNeeded!);
            dataGridView2.CellContextMenuStripNeeded += new DataGridViewCellContextMenuStripNeededEventHandler(DataGridView2_CellContextMenuStripNeeded!);
            dataGridView2.CellToolTipTextNeeded += new DataGridViewCellToolTipTextNeededEventHandler(DataGridView2_CellToolTipTextNeeded!);

            dataGridView2.DataSource = Populate("Select * from employees", true);
        }

        private void PostRowCreation()
        {
            SetBandColor(dataGridView2.Columns[0], Color.CadetBlue);
            SetBandColor(dataGridView2.Rows[1], Color.Coral);
            SetBandColor(dataGridView2.Columns[2], Color.DodgerBlue);
        }

        private static void SetBandColor(DataGridViewBand band, Color color)
        {
            band.Tag = color;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            PostRowCreation();

            foreach (DataGridViewBand band in dataGridView2.Columns)
            {
                if (band.Tag is not null) band.DefaultCellStyle.BackColor = (Color)band.Tag;
            }

            foreach (DataGridViewBand band in dataGridView2.Rows)
            {
                if (band.Tag is not null) band.DefaultCellStyle.BackColor = (Color)band.Tag;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            FreezeBand(dataGridView2.Rows[0]);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            FreezeBand(dataGridView2.Columns[1]);
        }

        private static void FreezeBand(DataGridViewBand band)
        {
            band.Frozen = true;
            DataGridViewCellStyle style = new()
            {
                BackColor = Color.DimGray
            };
            band.DefaultCellStyle = style;
        }

        private void DataGridView2_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            cellErrorText = string.Empty;

            if (strip is null)
            {
                strip = new ContextMenuStrip();
                lookUp.Text = "Look Up";
                wholeTable.Text = "See Whole Table";
                strip.Items.Add(lookUp);
                strip.Items.Add(wholeTable);
            }
            e.ContextMenuStrip = strip;
        }

        private void WholeTable_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = Populate(string.Format("Select * from employees"), true);
        }

        private DataGridViewCellEventArgs? theCellImHoveringOver;

        private void DataGridView2_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            theCellImHoveringOver = e;
        }

        private DataGridViewCellEventArgs? cellErrorLocation;

        private void LookUp_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView2.DataSource = Populate($"Select * from employees where {dataGridView2.Columns[theCellImHoveringOver!.ColumnIndex].Name} = '{dataGridView2.Rows[theCellImHoveringOver.RowIndex].Cells[theCellImHoveringOver.ColumnIndex].Value}'", true);
            }
            catch (SqlException)
            {
                cellErrorText = "Can't look this cell up";
                cellErrorLocation = theCellImHoveringOver;
            }
        }

        private void DataGridView2_CellErrorTextNeeded(object sender, DataGridViewCellErrorTextNeededEventArgs e)
        {
            if (cellErrorLocation is not null)
            {
                if (e.ColumnIndex == cellErrorLocation.ColumnIndex && e.RowIndex == cellErrorLocation.RowIndex)
                {
                    e.ErrorText = cellErrorText!;
                }
            }
        }

        private DataTable Populate(string query, bool resetUnsharedCounter)
        {
            if (resetUnsharedCounter) ResetCounter();

            SqlDataAdapter adapter = new(query, sqlConnNorth);

            DataTable table = new()
            {
                Locale = System.Globalization.CultureInfo.InvariantCulture
            };
            adapter.Fill(table);
            return table;
        }

        private void ResetCounter()
        {
            unsharedRowCounter = 0;
            count.Text = unsharedRowCounter.ToString();
        }

        private void DataGridView2_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (theCellImHoveringOver!.ColumnIndex == dataGridView2.Columns["ReportsTo"]!.Index && theCellImHoveringOver.RowIndex > -1)
            {
                string reportsTo = dataGridView2.Rows[theCellImHoveringOver.RowIndex].Cells[theCellImHoveringOver.ColumnIndex].Value!.ToString()!;

                if (string.IsNullOrEmpty(reportsTo)) e.ToolTipText = "The buck stops here!";
                else
                {
                    DataTable table = Populate($"select firstname, lastname from employees where employeeid = '{dataGridView2.Rows[theCellImHoveringOver.RowIndex].Cells[theCellImHoveringOver.ColumnIndex].Value}'", false);
                    e.ToolTipText = $"Reports to {table.Rows[0].ItemArray[0]} {table.Rows[0].ItemArray[1]}";
                }
            }
        }

        private void DataGridView2_RowUnshared(object sender, DataGridViewRowEventArgs row)
        {
            unsharedRowCounter += 1;
            count.Text = unsharedRowCounter.ToString();
        }
        #endregion

        #region Sample 3
        private readonly BindingSource masterBindingSource = [];
        private readonly BindingSource detailsBindingSource = [];

        private void Sample3()
        {
            dataGridView3.DataSource = masterBindingSource;
            dataGridView4.DataSource = detailsBindingSource;
            GetData();

            dataGridView3.AutoResizeColumns();
            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void GetData()
        {
            try
            {
                DataSet data = new()
                {
                    Locale = System.Globalization.CultureInfo.InvariantCulture
                };

                SqlDataAdapter masterDataAdapter = new("select * from Customers", sqlConnNorth);
                masterDataAdapter.Fill(data, "Customers");

                SqlDataAdapter detailsDataAdapter = new("select * from Orders", sqlConnNorth);
                detailsDataAdapter.Fill(data, "Orders");

                DataRelation relation = new("CustomersOrders", data.Tables["Customers"]!.Columns["CustomerID"]!, data.Tables["Orders"]!.Columns["CustomerID"]!);
                data.Relations.Add(relation);

                masterBindingSource.DataSource = data;
                masterBindingSource.DataMember = "Customers";

                detailsBindingSource.DataSource = masterBindingSource;
                detailsBindingSource.DataMember = "CustomersOrders";
            }
            catch (SqlException)
            {
                MessageBox.Show("To run this example, replace the value of the " +
                    "connectionString variable with a connection string that is " +
                    "valid for your system.");
            }
        }

        #endregion
    }
}
