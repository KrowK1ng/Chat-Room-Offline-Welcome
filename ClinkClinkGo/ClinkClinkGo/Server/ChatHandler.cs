using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinkClinkGo
{
    class ChatHandler
    {
        public static TextBox chat;
        public static void WriteLine(string _message)
        {
            if (chat != null)
            {
                chat.Text += _message + "\r\n";
            }
        }
    }
}
