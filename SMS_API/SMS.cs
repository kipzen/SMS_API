using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace SMS_API
{
    public partial class SMS : Form
    {
        public SMS()
        {
            InitializeComponent();
        }

        private void home_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SerialPort sp = new SerialPort();
                sp.PortName = comboBoxportName.Text;
                sp.Open();
                sp.WriteLine("AT" + Environment.NewLine);
                Thread.Sleep(100);
                sp.WriteLine("AT+CMGF=1" + Environment.NewLine);
                Thread.Sleep(100);
                sp.WriteLine("AT+CMGS=\'"+textBoxPhoneNum.Text+"\'" + Environment.NewLine);
                Thread.Sleep(100);
                sp.WriteLine(textBox1.Text+ Environment.NewLine);
                Thread.Sleep(100);

                sp.Write(new byte[] { 26 }, 0, 1);
                Thread.Sleep(100);

                var response = sp.ReadExisting();

                if (response.Contains("ERROR"))
                    MessageBox.Show("Send Failed","Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
                else
                    MessageBox.Show("Message Send", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sp.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
