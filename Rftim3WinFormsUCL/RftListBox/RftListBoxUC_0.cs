using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3WinFormsCL;

namespace Rftim3WinFormsUCL.RftListBox
{
    public partial class RftListBoxUC_0 : UserControl
    {
        private readonly IRftUserControlCL rftUserControlCL;
        private readonly IRftFormCL rftFormCL;

        public RftListBoxUC_0(IHost host)
        {
            InitializeComponent();

            rftUserControlCL = host.Services.GetRequiredService<IRftUserControlCL>();
            rftUserControlCL.RftUserControl = this;
            rftUserControlCL.RftContentProperties();

            rftFormCL = host.Services.GetRequiredService<IRftFormCL>();

            Init3();
        }

        private int indexOfItemUnderMouseToDrag;
        private int indexOfItemUnderMouseToDrop;

        private Rectangle dragBoxFromMouseDown;
        private Point screenOffset;

        private void Init3()
        {
            listBox1.Items.AddRange([
                "one", "two", "three", "four",
                "five", "six", "seven", "eight",
                "nine", "ten"
            ]);
        }

        private void ListDragSource_MouseDown(object sender, MouseEventArgs e)
        {
            indexOfItemUnderMouseToDrag = listBox1.IndexFromPoint(e.X, e.Y);

            if (indexOfItemUnderMouseToDrag != ListBox.NoMatches)
            {
                Size dragSize = SystemInformation.DragSize;

                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);
            }
            else dragBoxFromMouseDown = Rectangle.Empty;
        }

        private void ListDragSource_MouseUp(object sender, MouseEventArgs e)
        {
            dragBoxFromMouseDown = Rectangle.Empty;
        }

        private void ListDragSource_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                if (dragBoxFromMouseDown != Rectangle.Empty && !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {
                    screenOffset = rftFormCL.RftForm!.Location;

                    DragDropEffects dropEffect = listBox1.DoDragDrop(listBox1.Items[indexOfItemUnderMouseToDrag], DragDropEffects.All | DragDropEffects.Link);

                    if (dropEffect == DragDropEffects.Move)
                    {
                        listBox1.Items.RemoveAt(indexOfItemUnderMouseToDrag);

                        if (indexOfItemUnderMouseToDrag > 0) listBox1.SelectedIndex = indexOfItemUnderMouseToDrag - 1;
                        else if (listBox1.Items.Count > 0) listBox1.SelectedIndex = 0;
                    }
                }
            }
        }

        private void ListDragSource_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            if (sender is ListBox lb)
            {
                Form f = lb.FindForm()!;

                if (((MousePosition.X - screenOffset.X) < f.DesktopBounds.Left) ||
                    ((MousePosition.X - screenOffset.X) > f.DesktopBounds.Right) ||
                    ((MousePosition.Y - screenOffset.Y) < f.DesktopBounds.Top) ||
                    ((MousePosition.Y - screenOffset.Y) > f.DesktopBounds.Bottom))
                {
                    e.Action = DragAction.Cancel;
                }
            }
        }

        private void ListDragTarget_DragOver(object? sender, DragEventArgs e)
        {
            if (!e.Data!.GetDataPresent(typeof(string)))
            {
                e.Effect = DragDropEffects.None;
                label1.Text = "None - no string data.";
                return;
            }

            if ((e.KeyState & (8 + 32)) == (8 + 32) && (e.AllowedEffect & DragDropEffects.Link) == DragDropEffects.Link) e.Effect = DragDropEffects.Link;
            else if ((e.KeyState & 32) == 32 && (e.AllowedEffect & DragDropEffects.Link) == DragDropEffects.Link) e.Effect = DragDropEffects.Link;
            else if ((e.KeyState & 4) == 4 && (e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move) e.Effect = DragDropEffects.Move;
            else if ((e.KeyState & 8) == 8 && (e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy) e.Effect = DragDropEffects.Copy;
            else if ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move) e.Effect = DragDropEffects.Move;
            else e.Effect = DragDropEffects.None;

            indexOfItemUnderMouseToDrop = listBox2.IndexFromPoint(listBox2.PointToClient(new Point(e.X, e.Y)));

            if (indexOfItemUnderMouseToDrop != ListBox.NoMatches) label1.Text = $"Drops before item #{indexOfItemUnderMouseToDrop + 1}";
            else label1.Text = "Drops at the end.";
        }

        private void ListDragTarget_DragDrop(object? sender, DragEventArgs e)
        {
            if (e.Data!.GetDataPresent(typeof(string)))
            {
                object item = e.Data.GetData(typeof(string))!;

                if (e.Effect == DragDropEffects.Copy || e.Effect == DragDropEffects.Move)
                {

                    if (indexOfItemUnderMouseToDrop != ListBox.NoMatches) listBox2.Items.Insert(indexOfItemUnderMouseToDrop, item);
                    else listBox2.Items.Add(item);
                }
            }
            label1.Text = "None";
        }

        private void ListDragTarget_DragEnter(object sender, DragEventArgs e)
        {
            label1.Text = "None";
        }

        private void ListDragTarget_DragLeave(object sender, EventArgs e)
        {
            label1.Text = "None";
        }
    }
}
