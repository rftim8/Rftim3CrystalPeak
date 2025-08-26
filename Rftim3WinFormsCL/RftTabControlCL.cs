namespace Rftim3WinFormsCL
{
    public class RftTabControlCL : TabControl, IRftTabControlCL
    {
        private static TabControl? rftTabControl;

        public static TabControl? RftTabControl
        {
            get => rftTabControl;
            set => rftTabControl = value;
        }

        public static void InitTabControl()
        {
            RftTabControl!.DrawMode = TabDrawMode.OwnerDrawFixed;
            RftTabControl.DrawItem += TabControl_DrawItem;
            RftTabControl.MouseDown += TabControl_MouseDown;
        }

        public static void CreateTabPage(string? pageName)
        {
            if (pageName != null)
            {
                TabPage tabPage = new($"{pageName}    ");
                RftTabControl!.TabPages.Add(tabPage);
            }
        }

        private static void TabControl_DrawItem(object? sender, DrawItemEventArgs e)
        {
            TabPage tabPage = RftTabControl!.TabPages[e.Index];
            Rectangle tabRect = RftTabControl.GetTabRect(e.Index);

            // Draw tab text
            TextRenderer.DrawText(e.Graphics, tabPage.Text, tabPage.Font, tabRect, tabPage.ForeColor);

            // Draw close button ("X")
            Rectangle closeRect = new(tabRect.Right - 14, tabRect.Top + 2, 14, 14);
            e.Graphics.DrawString("X", e.Font!, Brushes.Black, closeRect.Location);
        }

        private static void TabControl_MouseDown(object? sender, MouseEventArgs e)
        {
            for (int i = 0; i < RftTabControl!.TabPages.Count; i++)
            {
                Rectangle tabRect = RftTabControl.GetTabRect(i);
                Rectangle closeRect = new(tabRect.Right - 14, tabRect.Top + 2, 14, 14);

                if (closeRect.Contains(e.Location))
                {
                    RftTabControl.TabPages.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
