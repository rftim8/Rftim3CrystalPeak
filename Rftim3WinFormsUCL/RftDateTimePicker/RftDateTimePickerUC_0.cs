using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3WinFormsCL;
using System.Collections;
using System.ComponentModel;

namespace Rftim3WinFormsUCL.RftDateTimePicker
{
    public partial class RftDateTimePickerUC_0 : UserControl
    {
        private readonly IRftUserControlCL rftUserControlCL;

        public RftDateTimePickerUC_0(IHost host)
        {
            InitializeComponent();

            rftUserControlCL = host.Services.GetRequiredService<IRftUserControlCL>();
            rftUserControlCL.RftUserControl = this;
            rftUserControlCL.RftContentProperties();

            Sample_2();
        }

        #region Sample 2
        public void Sample_2()
        {
            textBox1.Validating += new CancelEventHandler(TextBox1_Validate!);
            textBox1.LostFocus += new EventHandler(TextBox1_LostFocus!);
            SetCalendarLook();

            dateTimePicker1.Value = monthCalendar1.MinDate;
            dateTimePicker2.Value = monthCalendar1.MaxDate;
            textBox1.Text = monthCalendar1.MaxSelectionCount.ToString();
            for (Day day = Day.Monday; day <= Day.Default; day++)
            {
                comboBox1.Items.Add(day.ToString());
            }
            comboBox1.SelectedItem = comboBox1.Items[comboBox1.Items.IndexOf(monthCalendar1.FirstDayOfWeek.ToString())];
            LoadDates();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) monthCalendar1.ShowToday = true;
            else monthCalendar1.ShowToday = false;
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true) monthCalendar1.ShowTodayCircle = true;
            else monthCalendar1.ShowTodayCircle = false;
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value != monthCalendar1.MinDate)
            {
                if (dateTimePicker1.Value > monthCalendar1.MaxDate) dateTimePicker2.Value = dateTimePicker1.Value.AddDays(monthCalendar1.MaxSelectionCount);
                monthCalendar1.MinDate = dateTimePicker1.Value;
            }
        }

        private void DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker2.Value != monthCalendar1.MaxDate)
            {
                if (dateTimePicker2.Value < monthCalendar1.MinDate) dateTimePicker1.Value = dateTimePicker2.Value.AddDays(-monthCalendar1.MaxSelectionCount);
                monthCalendar1.MaxDate = dateTimePicker2.Value;
            }
        }

        private void TextBox1_keypress(object sender, KeyPressEventArgs k)
        {
            k.Handled = true;
            if ((k.KeyChar >= '0' && k.KeyChar <= '9') ||
                k.KeyChar == '\t' ||
                k.KeyChar == '\b' ||
                k.KeyChar == '\r')
            {
                k.Handled = false;
            }

            if (k.KeyChar == '\r') monthCalendar1.Focus();
        }

        private void TextBox1_Validate(object sender, CancelEventArgs c)
        {
            if (int.Parse(textBox1.Text) < 1 || int.Parse(textBox1.Text) > 365)
            {
                MessageBox.Show("Max Selection Count must be greater than zero and less than 366.");
                c.Cancel = true;
            }
        }

        private void TextBox1_LostFocus(object sender, EventArgs e)
        {
            monthCalendar1.MaxSelectionCount = int.Parse(textBox1.Text);
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            monthCalendar1.FirstDayOfWeek = (Day)comboBox1.SelectedIndex;
        }

        private void MonthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            label4.Text = $"Enter description for {monthCalendar1.SelectionStart.ToShortDateString()}";
            if (monthCalendar1.SelectionEnd != monthCalendar1.SelectionStart) label4.Text += $" to {monthCalendar1.SelectionEnd.ToShortDateString()}";

            textBox2.Enabled = true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; monthCalendar1.SelectionEnd >= monthCalendar1.SelectionStart.AddDays(i); i++)
            {
                listBox1.Items.Add($"{monthCalendar1.SelectionStart.AddDays(i).ToShortDateString()} {textBox2.Text}");
            }
            label4.Text = "";
            textBox2.Enabled = false;
            button1.Enabled = false;
            button3.Enabled = true;
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == "")
            {
                textBox2.Text = textBox2.Text.Trim();
                button1.Enabled = false;
            }
            else button1.Enabled = true;
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1) button2.Enabled = true;
            else button2.Enabled = false;
        }

        private void LoadDates()
        {
            string myInput;
            try
            {
                StreamReader myInputStream = File.OpenText("myDates.txt");
                while ((myInput = myInputStream.ReadLine()!) != null)
                {
                    monthCalendar1.AddBoldedDate(DateTime.Parse(myInput[..myInput.IndexOf(' ')]));
                    listBox1.Items.Add(myInput);
                }
                monthCalendar1.UpdateBoldedDates();
                myInputStream.Close();
                File.Delete("myDates.txt");
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine("An error occurred: '{0}'", fnfe);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            monthCalendar1.RemoveBoldedDate(DateTime.Parse(listBox1.SelectedItem!.ToString()![..listBox1.SelectedItem.ToString()!.IndexOf(' ')]));
            monthCalendar1.UpdateBoldedDates();
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            if (listBox1.Items.Count == 0) button3.Enabled = false;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            monthCalendar1.RemoveAllBoldedDates();
            monthCalendar1.UpdateBoldedDates();
            listBox1.Items.Clear();
            button3.Enabled = false;
        }

        private void SetCalendarLook()
        {
            monthCalendar1.MinDate = DateTime.Parse("1/1/1900");
            //monthCalendar1.MaxDate = DateTime.Parse("12/31/2099");

            checkBox1.Checked = true;
            checkBox2.Checked = true;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            StreamWriter myOutputStream = File.CreateText(@"/RftCS/RftWFCS/RftWFCS/RftOut/myDates.txt");
            IEnumerator myDates = listBox1.Items.GetEnumerator();
            while (myDates.MoveNext() == true)
            {

                myOutputStream.WriteLine(myDates.Current.ToString());
            }
            myOutputStream.Flush();
            myOutputStream.Close();
        }
        #endregion
    }
}
