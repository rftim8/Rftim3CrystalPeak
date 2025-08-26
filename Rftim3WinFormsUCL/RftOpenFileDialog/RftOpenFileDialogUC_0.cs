using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3WinFormsCL;
using System.Security;

namespace Rftim3WinFormsUCL.RftOpenFileDialog
{
    public partial class RftOpenFileDialogUC_0 : UserControl
    {
        private readonly IRftUserControlCL rftUserControlCL;

        public RftOpenFileDialogUC_0(IHost host)
        {
            InitializeComponent();

            rftUserControlCL = host.Services.GetRequiredService<IRftUserControlCL>();
            rftUserControlCL.RftUserControl = this;
            rftUserControlCL.RftContentProperties();

            InitializeOpenFileDialog();
        }

        private void InitializeOpenFileDialog()
        {
            openFileDialog1.Filter = "Images (*.PNG;*.BMP;*.JPG;*.GIF)|*.PNG;*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            openFileDialog1.Multiselect = true;
            openFileDialog1.Title = "My Image Browser";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Thread thread = new(() =>
            {
                DialogResult dr = openFileDialog1.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    foreach (string file in openFileDialog1.FileNames)
                    {
                        try
                        {
                            PictureBox pb = new();
                            Image loadedImage = Image.FromFile(file);
                            //pb.Height = loadedImage.Height;
                            //pb.Width = loadedImage.Width;
                            pb.Size = new Size(300, 300);
                            pb.SizeMode = PictureBoxSizeMode.StretchImage;
                            pb.BorderStyle = BorderStyle.Fixed3D;
                            pb.Image = loadedImage;
                            flowLayoutPanel1.Controls.Add(pb);
                        }
                        catch (SecurityException ex)
                        {
                            MessageBox.Show($"Security error. Please contact your administrator for details.\n\n" +
                                $"Error message: {ex.Message}\n\n" +
                                "Details (send to Support):\n\n" +
                                $"{ex.StackTrace}"
                            );
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Cannot display the image: {file[file.LastIndexOf('\\')..]}" +
                                ". You may not have permission to read the file, or " +
                                $"it may be corrupt.\n\nReported error: {ex.Message}"
                                );
                        }
                    }
                }
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
    }
}
