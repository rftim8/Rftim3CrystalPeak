using System.ComponentModel;

namespace Rftim3WinFormsCL
{
    public class RftTableLayoutPanelCL : TableLayoutPanel, IRftTableLayoutPanelCL
    {
        private static TableLayoutPanel? rftTableLayoutPanel;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TableLayoutPanel? RftTableLayoutPanel
        {
            get { return rftTableLayoutPanel; }
            set { rftTableLayoutPanel = value; }
        }

        public void RftDefaultProperties() => DefaultProperties();

        private static void DefaultProperties()
        {
            if (rftTableLayoutPanel != null)
            {
                rftTableLayoutPanel.Dock = DockStyle.Fill;
                rftTableLayoutPanel.Height = 30;
                rftTableLayoutPanel.RowCount = 1;
                rftTableLayoutPanel.ColumnCount = 4;
                rftTableLayoutPanel.BringToFront();
                rftTableLayoutPanel.BackColor = Color.Green;
                rftTableLayoutPanel.BorderStyle = BorderStyle.Fixed3D;
                rftTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
                rftTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100f));
                rftTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100f));
                rftTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100f));
            }
        }
    }
}
