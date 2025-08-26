namespace Rftim3WinForms.RftListViews
{
    internal class RftListView0
    {
        private ListView? listView2;

        public RftListView0(Form form)
        {
            LatestUpdates();
            form.Controls.Add(listView2);
        }

        private void LatestUpdates()
        {
            listView2 = new()
            {
                Alignment = ListViewAlignment.Left,
                FullRowSelect = true,
                HeaderStyle = ColumnHeaderStyle.None,
                TabIndex = 11,
                UseCompatibleStateImageBehavior = false,
                View = View.Details,
                Width = 1920,
                Height = 1080
            };
            listView2.Items.Clear();
            listView2.Columns.Clear();

            ColumnHeader columnHeader0List2 = new()
            {
                Width = 348
            };
            listView2.Columns.AddRange([columnHeader0List2]);

            ListViewItem titleSeparator0List2 = new(["", ""])
            {
                Font = new Font("Verdana", 5f)
            };
            ListViewItem item0List2 = new(["Latest Updates"])
            {
                ForeColor = Color.DodgerBlue,
                Font = new Font("Verdana", 12f)
            };
            ListViewItem titleSeparator1List2 = new(["", ""])
            {
                Font = new Font("Verdana", 5f)
            };

            ListViewItem item1List2 = new(["1. Added customized gauges to the welcome panel"]);
            ListViewItem item2List2 = new(["2. Refined welcome panel layout"]);

            listView2.Items.AddRange(
                new ListViewItem[] {
                    titleSeparator0List2,
                    item0List2,
                    titleSeparator1List2,
                    item1List2,
                    item2List2
                });
        }
    }
}
