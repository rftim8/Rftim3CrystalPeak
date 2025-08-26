namespace Rftim3WinForms.RftListViews
{
    internal class RftListView1
    {
        private ListView? listView3;

        public RftListView1(Form form)
        {
            AppStructure();
            form.Controls.Add(listView3);
        }

        private void AppStructure()
        {
            listView3 = new()
            {
                Alignment = ListViewAlignment.Left,
                FullRowSelect = true,
                HeaderStyle = ColumnHeaderStyle.None,
                TabIndex = 12,
                UseCompatibleStateImageBehavior = false,
                View = View.Details,
                Width = 1920,
                Height = 1080
            };
            listView3.Items.Clear();
            listView3.Columns.Clear();

            ColumnHeader columnHeader0List3 = new()
            {
                Width = 348
            };
            listView3.Columns.AddRange([columnHeader0List3]);

            ListViewItem titleSeparator0List3 = new(["", ""])
            {
                Font = new Font("Verdana", 5f)
            };
            ListViewItem item0List3 = new(["App Structure"])
            {
                ForeColor = Color.DodgerBlue,
                Font = new Font("Verdana", 12f)
            };
            ListViewItem titleSeparator1List3 = new(["", ""])
            {
                Font = new Font("Verdana", 5f)
            };

            ListViewItem item1List3 = new(["1. 69 user controls at C# level"]);
            ListViewItem item2List3 = new(["2. paint on demand"]);

            listView3.Items.AddRange(
                new ListViewItem[] {
                    titleSeparator0List3,
                    item0List3,
                    titleSeparator1List3,
                    item1List3,
                    item2List3
                });
        }
    }
}
