using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinkClinkGo
{
    public partial class Form1 : Form
    {
        private Chat chatForm;
        public Form1()
        {
            InitializeComponent();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            string _name = NameField.Text;
            string ip = IPField.Text;
            int _port = Int32.Parse(PortField.Text);

            Program.client = new Client(ip, _port, _name);
            Program.client.ConnectToServer();
            chatForm = new Chat(this);
            chatForm.Show();
            this.Hide();
        }

        private void Thread1_Tick(object sender, EventArgs e)
        {
            GameLogic.Update();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Client.Quit();
        }
    }
}
