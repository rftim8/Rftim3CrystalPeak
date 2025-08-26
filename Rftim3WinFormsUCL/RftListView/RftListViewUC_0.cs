using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3WinFormsCL;
using System.Collections;

namespace Rftim3WinFormsUCL.RftListView
{
    public partial class RftListViewUC_0 : UserControl
    {
        private static IRftUserControlCL? rftUserControlCL;

        public RftListViewUC_0(IHost host)
        {
            InitializeComponent();

            rftUserControlCL = host.Services.GetRequiredService<IRftUserControlCL>();
            rftUserControlCL.RftUserControl = this;
            rftUserControlCL.RftContentProperties();

            Init();
            Init2();
        }

        #region Sample 1
        private readonly bool isRunningXPOrLater = OSFeature.Feature.IsPresent(OSFeature.Themes);
        private Hashtable[]? groupTables;
        int groupColumn = 0;

        private void Init()
        {
            ColumnHeader columnHeader0 = new()
            {
                Text = "Title",
                Width = -1
            };
            ColumnHeader columnHeader1 = new()
            {
                Text = "Author",
                Width = -1
            };
            ColumnHeader columnHeader2 = new()
            {
                Text = "Year",
                Width = -1
            };

            listView1.Columns.AddRange([columnHeader0, columnHeader1, columnHeader2]);

            ListViewItem item0 = new([
                "Programming Windows",
                "Petzold, Charles",
                "1998"
            ])
            {
                ForeColor = Color.Red
            };
            ListViewItem item1 = new([
                "Code: The Hidden Language of Computer Hardware and Software",
                "Petzold, Charles",
                "2000"
            ]);
            ListViewItem item2 = new([
                "Programming Windows with C#",
                "Petzold, Charles",
                "2001"
            ]);
            ListViewItem item3 = new([
                "Coding Techniques for Microsoft Visual Basic .NET",
                "Connell, John",
                "2001"
            ]);
            ListViewItem item4 = new([
                "C# for Java Developers",
                "Jones, Allen & Freeman, Adam",
                "2002"
            ]);
            ListViewItem item5 = new([
                "Microsoft .NET XML Web Services Step by Step",
                "Jones, Allen & Freeman, Adam",
                "2002"
            ]);
            listView1.Items.AddRange([item0, item1, item2, item3, item4, item5]);

            if (isRunningXPOrLater)
            {
                groupTables = new Hashtable[listView1.Columns.Count];
                for (int column = 0; column < listView1.Columns.Count; column++)
                {
                    groupTables[column] = CreateGroupsTable(column);
                }
                SetGroups(0);
            }
        }

        private void MyListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (listView1.Sorting == SortOrder.Descending || (isRunningXPOrLater && (e.Column != groupColumn))) listView1.Sorting = SortOrder.Ascending;
            else listView1.Sorting = SortOrder.Descending;
            groupColumn = e.Column;

            if (isRunningXPOrLater) SetGroups(e.Column);
        }

        private void SetGroups(int column)
        {
            listView1.Groups.Clear();
            Hashtable groups = groupTables![column];
            ListViewGroup[] groupsArray = new ListViewGroup[groups.Count];
            groups.Values.CopyTo(groupsArray, 0);
            Array.Sort(groupsArray, new ListViewGroupSorter(listView1.Sorting));
            listView1.Groups.AddRange(groupsArray);

            foreach (ListViewItem item in listView1.Items)
            {
                string subItemText = item.SubItems[column].Text;

                if (column == 0) subItemText = subItemText[..1];

                item.Group = (ListViewGroup)groups[subItemText]!;
            }
        }

        private Hashtable CreateGroupsTable(int column)
        {
            Hashtable groups = [];

            foreach (ListViewItem item in listView1.Items)
            {
                string subItemText = item.SubItems[column].Text;

                if (column == 0) subItemText = subItemText[..1];
                if (!groups.Contains(subItemText)) groups.Add(subItemText, new ListViewGroup(subItemText, HorizontalAlignment.Left));
            }

            return groups;
        }

        private class ListViewGroupSorter(SortOrder theOrder) : IComparer
        {
            private readonly SortOrder order = theOrder;

            public int Compare(object? x, object? y)
            {
                int result = string.Compare(((ListViewGroup)x!).Header, ((ListViewGroup)y!).Header);

                if (order == SortOrder.Ascending) return result;
                else return -result;
            }
        }
        #endregion

        #region Sample 2
        private void Init2()
        {
            listView2.Columns.AddRange([
                new ColumnHeader(),
                new ColumnHeader(),
                new ColumnHeader()
            ]);

            ListViewItem item0 = new([
                "Programming Windows",
                "Petzold, Charles",
                "1998"
            ], 0);
            ListViewItem item1 = new([
                "Code: The Hidden Language of Computer Hardware and Software",
                "Petzold, Charles",
                "2000"
            ], 0);
            ListViewItem item2 = new([
                "Programming Windows with C#",
                "Petzold, Charles",
                "2001"
            ], 0);
            ListViewItem item3 = new([
                "Coding Techniques for Microsoft Visual Basic .NET",
                "Connell, John",
                "2001"
            ], 0);
            ListViewItem item4 = new([
                "C# for Java Developers",
                "Jones, Allen & Freeman, Adam",
                "2002"
            ], 0);
            ListViewItem item5 = new([
                "Microsoft .NET XML Web Services Step by Step",
                "Jones, Allen & Freeman, Adam",
                "2002"
            ], 0);
            listView2.Items.AddRange([item0, item1, item2, item3, item4, item5]);
        }
        #endregion
    }
}
