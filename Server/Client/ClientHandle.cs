using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    class ClientHandle
    {
        public static void Welcome(Packet _packet)
        {
            string _msg = _packet.ReadString();
            int _myId = _packet.ReadInt();

            Console.WriteLine($"Message from server: {_msg}");
            Client.instance.myId = _myId;
            ClientSend.WelcomeRecieved();
        }

        public static void ClientConnected(Packet _packet)
        {
            string _username = _packet.ReadString();

            Console.WriteLine($"{_username} connected to the chat.");
        }
    }
}
