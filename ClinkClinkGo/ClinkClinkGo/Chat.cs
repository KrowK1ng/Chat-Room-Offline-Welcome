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
    public partial class Chat : Form
    {
        private Form1 initiator;
        public Chat(Form1 _form1)
        {
            initiator = _form1;
            InitializeComponent();
        }

        private void Chat_Load(object sender, EventArgs e)
        {
            ChatHandler.chat = ChatTB;
        }

        private void Chat_FormClosing(object sender, FormClosingEventArgs e)
        {
            initiator.Close();
            //Chat
        }

        private void Chat_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void SendMessage()
        {
            ClientSend.SendMessage(MessageTB.Text);
            ChatHandler.WriteLine($"[{DateTime.Now} {Client.instance.name}] {MessageTB.Text}");
            MessageTB.Text = "";
        }

        private void MessageTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && MessageTB.Text.Length > 0)
            {
                SendMessage();
            }
        }

        private void SendButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (MessageTB.Text.Length > 0)
            {
                SendMessage();
            }
        }
    }
}
