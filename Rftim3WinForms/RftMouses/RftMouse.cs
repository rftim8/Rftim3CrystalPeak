namespace Rftim3WinForms.RftMouses
{
    internal class RftMouse
    {
        private readonly Form form;
        private Panel? panel;
        private Point lastLocation;

        public RftMouse(Form form)
        {
            RftMouseDrag();
            form.Controls.Add(panel);
            this.form = form;
        }

        private void RftMouseDrag()
        {
            panel = new()
            {
                Width = 1920,
                Height = 1080,
                Dock = DockStyle.Top
            };

            panel.MouseDown += new MouseEventHandler(RftMouseDragDown);
            panel.MouseMove += new MouseEventHandler(RftMouseDragMove);
        }

        private void RftMouseDragDown(object? sender, MouseEventArgs e)
        {
            lastLocation = e.Location;
        }

        private void RftMouseDragMove(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                form.Location = new Point(form.Location.X - lastLocation.X + e.X, form.Location.Y - lastLocation.Y + e.Y);
                panel!.Update();
            }
        }
    }
}
