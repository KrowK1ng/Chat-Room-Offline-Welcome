using System;
using System.Collections.Generic;
using System.Text;

namespace ClinkClinkGo
{
    class ClientHandle
    {
        public static void Welcome(Packet _packet)
        {
            string _msg = _packet.ReadString();
            int _myId = _packet.ReadInt();

            ChatHandler.WriteLine($"[{DateTime.Now} Server] {_msg}");
            Client.instance.myId = _myId;
            ClientSend.WelcomeRecieved();
        }

        public static void ClientConnected(Packet _packet)
        {
            string _username = _packet.ReadString();

            ChatHandler.WriteLine($"{_username} connected to the chat.");
        }

        public static void GetMessage(Packet _packet)
        {
            string _username = _packet.ReadString();
            string _msg = _packet.ReadString();

            ChatHandler.WriteLine($"[{DateTime.Now} {_username}] {_msg}");
        }

        public static void ClientDisconnected(Packet _packet)
        {
            string _username = _packet.ReadString();

            ChatHandler.WriteLine($"{_username} leaved the chat.");
        }
    }
}
