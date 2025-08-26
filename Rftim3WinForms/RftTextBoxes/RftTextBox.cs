namespace Rftim3WinForms.RftTextBoxes
{
    internal class RftTextBox
    {
        private TextBox? textBox;

        public RftTextBox(Form form)
        {
            SystemInfo();
            form.Controls.Add(textBox);
        }

        private void SystemInfo()
        {
            textBox = new()
            {
                Width = 1920,
                Height = 1080,
                Multiline = true
            };

            textBox.AppendText(SystemInformation.ComputerName.ToString());
            textBox.AppendText(Environment.NewLine);
            textBox.AppendText(SystemInformation.UserName.ToString());
            textBox.AppendText(Environment.NewLine);
            textBox.AppendText(SystemInformation.UserDomainName.ToString());
            textBox.AppendText(Environment.NewLine);
            textBox.AppendText(SystemInformation.BootMode.ToString());
            textBox.AppendText(Environment.NewLine);
            textBox.AppendText(SystemInformation.MonitorCount.ToString());
            textBox.AppendText(Environment.NewLine);
            textBox.AppendText($"{SystemInformation.PrimaryMonitorSize.Width} x {SystemInformation.PrimaryMonitorSize.Height}");
            textBox.AppendText(Environment.NewLine);
            textBox.AppendText(SystemInformation.PowerStatus.BatteryChargeStatus.ToString());
            textBox.AppendText(Environment.NewLine);
            textBox.AppendText(SystemInformation.PowerStatus.PowerLineStatus.ToString());
        }
    }
}
