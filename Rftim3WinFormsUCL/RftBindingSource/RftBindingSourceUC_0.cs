using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3WinFormsCL;
using System.ComponentModel;
using System.Data;

namespace Rftim3WinFormsUCL.RftBindingSource
{
    public partial class RftBindingSourceUC_0 : UserControl
    {
        private readonly IRftUserControlCL rftUserControlCL;

        public RftBindingSourceUC_0(IHost host)
        {
            InitializeComponent();

            rftUserControlCL = host.Services.GetRequiredService<IRftUserControlCL>();
            rftUserControlCL.RftUserControl = this;
            rftUserControlCL.RftContentProperties();

            // Sample 1
            //PopulateDataViewAndFind();
            //PopulateDataViewAndSort();
            //PopulateDataViewAndFilter();
            //PopulateDataViewAndAdvancedSort();
            //PopulateBindingSourceWithFonts();

            //// Sample 2
            //Form1_Load();

            // Sample 3
            //InitializeControlsAndDataSource();
            InitializeControlsAndData();
        }

        #region Sample1
        private void PopulateDataViewAndFind()
        {
            DataSet set1 = new();

            // Some xml data to populate the DataSet with.
            string musicXml =
                "<?xml version='1.0' encoding='UTF-8'?>" +
                "<music>" +
                "<recording><artist>Coldplay</artist><cd>X&amp;Y</cd></recording>" +
                "<recording><artist>Dave Matthews</artist><cd>Under the Table and Dreaming</cd></recording>" +
                "<recording><artist>Natalie Merchant</artist><cd>Tigerlily</cd></recording>" +
                "<recording><artist>U2</artist><cd>How to Dismantle an Atomic Bomb</cd></recording>" +
                "</music>";

            // Read the xml.
            StringReader reader = new(musicXml);
            set1.ReadXml(reader);

            // Get a DataView of the table contained in the dataset.
            DataTableCollection tables = set1.Tables;
            DataView view1 = new(tables[0]);

            // Create a DataGridView control and add it to the form.
            //DataGridView datagridview1 = new DataGridView
            //{
            //    AutoGenerateColumns = true
            //};
            //this.Controls.Add(datagridview1);

            // Create a BindingSource and set its DataSource property to
            // the DataView.
            //BindingSource source1 = new BindingSource
            //{
            //    DataSource = view1
            //};

            bindingSource1.DataSource = view1;

            // Set the data source for the DataGridView.
            dataGridView1.DataSource = bindingSource1;

            // Set the Position property to the results of the Find method.
            int itemFound = bindingSource1.Find("artist", "Natalie Merchant");
            bindingSource1.Position = itemFound;
        }

        private void PopulateDataViewAndSort()
        {
            DataSet set1 = new();

            // Some xml data to populate the DataSet with.
            string musicXml =
                "<?xml version='1.0' encoding='UTF-8'?>" +
                "<music>" +
                "<recording><artist>Coldplay</artist><cd>X&amp;Y</cd></recording>" +
                "<recording><artist>Dave Matthews</artist><cd>Under the Table and Dreaming</cd></recording>" +
                "<recording><artist>Dave Matthews</artist><cd>Live at Red Rocks</cd></recording>" +
                "<recording><artist>Natalie Merchant</artist><cd>Tigerlily</cd></recording>" +
                "<recording><artist>U2</artist><cd>How to Dismantle an Atomic Bomb</cd></recording>" +
                "</music>";

            // Read the xml.
            StringReader reader = new(musicXml);
            set1.ReadXml(reader);

            // Get a DataView of the table contained in the dataset.
            DataTableCollection tables = set1.Tables;
            DataView view1 = new(tables[0]);

            // Create a DataGridView control and add it to the form.
            //DataGridView datagridview1 = new DataGridView
            //{
            //    AutoGenerateColumns = true
            //};
            //this.Controls.Add(datagridview1);

            // Create a BindingSource and set its DataSource property to
            // the DataView.
            BindingSource source1 = new()
            {
                DataSource = view1
            };

            // Set the data source for the DataGridView.
            dataGridView2.DataSource = source1;

            source1.Sort = "cd";
        }

        private void PopulateDataViewAndFilter()
        {
            DataSet set1 = new();

            // Some xml data to populate the DataSet with.
            string musicXml =
                "<?xml version='1.0' encoding='UTF-8'?>" +
                "<music>" +
                "<recording><artist>Coldplay</artist><cd>X&amp;Y</cd></recording>" +
                "<recording><artist>Dave Matthews</artist><cd>Under the Table and Dreaming</cd></recording>" +
                "<recording><artist>Dave Matthews</artist><cd>Live at Red Rocks</cd></recording>" +
                "<recording><artist>Natalie Merchant</artist><cd>Tigerlily</cd></recording>" +
                "<recording><artist>U2</artist><cd>How to Dismantle an Atomic Bomb</cd></recording>" +
                "</music>";

            // Read the xml.
            StringReader reader = new(musicXml);
            set1.ReadXml(reader);

            // Get a DataView of the table contained in the dataset.
            DataTableCollection tables = set1.Tables;
            DataView view1 = new(tables[0]);

            // Create a DataGridView control and add it to the form.
            //DataGridView datagridview1 = new DataGridView
            //{
            //    AutoGenerateColumns = true
            //};
            //this.Controls.Add(datagridview1);

            // Create a BindingSource and set its DataSource property to
            // the DataView.
            BindingSource source1 = new()
            {
                DataSource = view1
            };

            // Set the data source for the DataGridView.
            dataGridView3.DataSource = source1;

            //The Filter string can include Boolean expressions.
            source1.Filter = "artist = 'Dave Matthews' OR cd = 'Tigerlily'";
        }

        private void PopulateDataViewAndAdvancedSort()
        {
            DataSet set1 = new();

            // Some xml data to populate the DataSet with.
            string musicXml =
                "<?xml version='1.0' encoding='UTF-8'?>" +
                "<music>" +
                "<recording><artist>Dave Matthews</artist><cd>Under the Table and Dreaming</cd></recording>" +
                "<recording><artist>Coldplay</artist><cd>X&amp;Y</cd></recording>" +
                "<recording><artist>Dave Matthews</artist><cd>Live at Red Rocks</cd></recording>" +
                "<recording><artist>U2</artist><cd>Joshua Tree</cd></recording>" +
                "<recording><artist>U2</artist><cd>How to Dismantle an Atomic Bomb</cd></recording>" +
                "<recording><artist>Natalie Merchant</artist><cd>Tigerlily</cd></recording>" +
                "</music>";

            // Read the xml.
            StringReader reader = new(musicXml);
            set1.ReadXml(reader);

            // Get a DataView of the table contained in the dataset.
            DataTableCollection tables = set1.Tables;
            DataView view1 = new(tables[0]);

            // Create a DataGridView control and add it to the form.
            //DataGridView datagridview1 = new DataGridView
            //{
            //    AutoGenerateColumns = true
            //};
            //this.Controls.Add(datagridview1);

            // Create a BindingSource and set its DataSource property to
            // the DataView.
            BindingSource source1 = new()
            {
                DataSource = view1
            };

            // Set the data source for the DataGridView.
            dataGridView4.DataSource = source1;

            source1.Sort = "artist ASC, cd ASC";
        }

        //readonly TextBox box1 = new TextBox();

        private void PopulateBindingSourceWithFonts()
        {
            bindingSource1 = [];
            bindingSource1.Add(new Font(FontFamily.Families[2], 8.0F));
            bindingSource1.Add(new Font(FontFamily.Families[4], 9.0F));
            bindingSource1.Add(new Font(FontFamily.Families[6], 10.0F));
            bindingSource1.Add(new Font(FontFamily.Families[8], 11.0F));
            bindingSource1.Add(new Font(FontFamily.Families[10], 12.0F));
            //DataGridView view1 = new DataGridView
            //{
            //    DataSource = bindingSource1,
            //    AutoGenerateColumns = true,
            //    Dock = DockStyle.Top
            //};
            //this.Controls.Add(view1);
            dataGridView5.DataSource = bindingSource1;
            //textBox1.Dock = DockStyle.Bottom;
            textBox1.Text = "Sample Text";
            //this.Controls.Add(textBox1);
            textBox1.DataBindings.Add("Text", bindingSource1, "Name");
            dataGridView5.Columns[7].DisplayIndex = 0;
        }

        private void BindingSource1_CurrentChanged(object? sender, EventArgs e)
        {
            //textBox1.Text = bindingSource1.Current!.ToString();
            textBox1.Font = (Font)bindingSource1.Current!;
        }
        #endregion

        #region Sample2
        private void Form1_Load()
        {
            bindingSource1 = [];
            textBox2.Text = "Wingdings";
            button1.Text = "Search";

            MyFontList fonts = [];
            for (int i = 0; i < FontFamily.Families.Length; i++)
            {
                if (FontFamily.Families[i].IsStyleAvailable(FontStyle.Regular)) fonts.Add(new Font(FontFamily.Families[i], 11.0F, FontStyle.Regular));
            }
            bindingSource1.DataSource = fonts;
            listBox1.DataSource = bindingSource1;
            listBox1.DisplayMember = "Name";
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (bindingSource1!.SupportsSearching != true)
            {
                MessageBox.Show("Cannot search the list.");
            }
            else
            {
                int foundIndex = bindingSource1.Find("Name", textBox2.Text);

                if (foundIndex > -1) listBox1.SelectedIndex = foundIndex;
                else MessageBox.Show("Font was not found.");
            }
        }

        public class MyFontList : BindingList<Font>
        {
            protected override bool SupportsSearchingCore
            {
                get { return true; }
            }
            protected override int FindCore(PropertyDescriptor prop, object key)
            {
                // Ignore the prop value and search by family name.
                for (int i = 0; i < Count; ++i)
                {
                    if (Items[i].FontFamily.Name.Equals((string)key, StringComparison.CurrentCultureIgnoreCase)) return i;
                }
                return -1;
            }
        }
        #endregion

        #region Sample 3
        private void InitializeControlsAndDataSource()
        {
            bindingSource2 = [];
            DataSet set1 = new();
            set1.Tables.Add("Menu");
            set1.Tables[0].Columns.Add("Beverages");

            // Add some rows to the table.
            set1.Tables[0].Rows.Add("coffee");
            set1.Tables[0].Rows.Add("tea");
            set1.Tables[0].Rows.Add("hot chocolate");
            set1.Tables[0].Rows.Add("milk");
            set1.Tables[0].Rows.Add("orange juice");

            // Set the data source to the DataSet.
            bindingSource2.DataSource = set1;

            //Set the DataMember to the Menu table.
            bindingSource2.DataMember = "Menu";

            // Add the control data bindings.
            dataGridView6.DataSource = bindingSource2;
            textBox3.DataBindings.Add("Text", bindingSource2, "Beverages", true, DataSourceUpdateMode.OnPropertyChanged);
            textBox4.DataBindings.Add("Text", bindingSource2, "Beverages", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void BindingSource2_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            // Check if the data source has been updated, and that no error has occurred.
            if (e.BindingCompleteContext == BindingCompleteContext.DataSourceUpdate && e.Exception is null)
            {
                // If not, end the current edit.
                e.Binding!.BindingManagerBase!.EndCurrentEdit();
            }
        }

        private void InitializeControlsAndData()
        {
            DataSet set1 = new();
            set1.Tables.Add("Menu");
            set1.Tables[0].Columns.Add("Beverages");

            // Add some rows to the table.
            set1.Tables[0].Rows.Add("coffee");
            set1.Tables[0].Rows.Add("tea");
            set1.Tables[0].Rows.Add("hot chocolate");
            set1.Tables[0].Rows.Add("milk");
            set1.Tables[0].Rows.Add("orange juice");

            // Add the control data bindings.
            dataGridView6.DataSource = set1;
            dataGridView6.DataMember = "Menu";
            textBox3.DataBindings.Add("Text", set1, "Menu.Beverages", true, DataSourceUpdateMode.OnPropertyChanged);
            textBox4.DataBindings.Add("Text", set1, "Menu.Beverages", true, DataSourceUpdateMode.OnPropertyChanged);

            BindingManagerBase bmb = BindingContext![set1, "Menu"];
            bmb.BindingComplete += new BindingCompleteEventHandler(BindingSource2_BindingComplete!);
        }
        #endregion
    }
}
