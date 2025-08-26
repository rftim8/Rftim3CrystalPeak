using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3WinFormsCL;
using System.Data;
using System.Data.SQLite;

namespace Rftim3WinFormsUCL.RftComboBox
{
    public partial class RftComboBoxUC_0 : UserControl
    {
        private readonly SQLiteConnection sqlConnection;
        private readonly IRftUserControlCL rftUserControlCL;

        public RftComboBoxUC_0(IHost host)
        {
            InitializeComponent();

            rftUserControlCL = host.Services.GetRequiredService<IRftUserControlCL>();
            rftUserControlCL.RftUserControl = this;
            rftUserControlCL.RftContentProperties();

            RftDatabaseConnections sqliteConnection = host.Services.GetRequiredService<RftDatabaseConnections>();
            sqlConnection = new SQLiteConnection(sqliteConnection.SqliteConnection);

            Init();
        }

        private void Init()
        {
            foreach (Cursor cursor in CursorList())
            {
                comboBox1.Items.Add(cursor);
            }
        }

        private static Cursor[] CursorList()
        {

            return [
                Cursors.AppStarting, Cursors.Arrow, Cursors.Cross,
                Cursors.Default, Cursors.Hand, Cursors.Help,
                Cursors.HSplit, Cursors.IBeam, Cursors.No,
                Cursors.NoMove2D, Cursors.NoMoveHoriz, Cursors.NoMoveVert,
                Cursors.PanEast, Cursors.PanNE, Cursors.PanNorth,
                Cursors.PanNW, Cursors.PanSE, Cursors.PanSouth,
                Cursors.PanSW, Cursors.PanWest, Cursors.SizeAll,
                Cursors.SizeNESW, Cursors.SizeNS, Cursors.SizeNWSE,
                Cursors.SizeWE, Cursors.UpArrow, Cursors.VSplit, Cursors.WaitCursor
            ];
        }

        private void CursorSelectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.Cursor = (Cursor)comboBox1.SelectedItem!;
        }

        private void TestPanel_CursorChanged(object sender, EventArgs e)
        {
            string cursorEvent = string.Format("[{0}]: {1}", sender.GetType(), "Cursor changed");

            listView1.Items.Add(comboBox1.Text);
        }

        private void RefreshMainCbx(ComboBox comboBox)
        {
            comboBox.Items.Clear();
            try
            {
                sqlConnection.Open();
                using (SQLiteDataAdapter sqlDataAdapter = new("select * from SEGMENT_MAIN", sqlConnection))
                {
                    DataSet dataSet = new();
                    sqlDataAdapter.Fill(dataSet, "Nr. Crt.");
                    comboBox.Items.Add("--Select--");
                    for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                    {
                        comboBox.Items.Add(dataSet.Tables[0].Rows[i]["Segment_Main"].ToString()!);
                    }
                }
                comboBox.SelectedIndex = 0;
            }
            catch (Exception e)
            {
                e.ToString();
            }
            finally
            {
                sqlConnection.Close();
            }

        }
    }
}
