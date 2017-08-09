using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhatsAppMessenger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string password;
            string from = "9566935533";
            string err;

            WhatsAppApi.Register.WhatsRegisterV2.RequestCode(from, out password, out err, "sms");

            //WhatsAppApi.WhatsApp wa = new WhatsAppApi.WhatsApp("9566935533", "Test", "Test", true);

            WhatsAppApi.WhatsApp wa = new WhatsAppApi.WhatsApp("919566935533", "", "Karthik", false, false);


            wa.OnConnectSuccess += () =>
            {
                MessageBox.Show("Connected");
                wa.OnLoginSuccess += (phoneNumber, data) =>
                {
                    wa.SendMessage(textBox1.Text, textBox2.Text);
                    MessageBox.Show("Message Sent");
                };

                wa.OnLoginFailed += (data) =>
                {
                    MessageBox.Show("Login failed");
                };

                wa.Login();
            };

            wa.OnConnectFailed += (ex) =>
            {
                MessageBox.Show("Connection failed");
            };
            wa.Connect();

        }
    }
}
