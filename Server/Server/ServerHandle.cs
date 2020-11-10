using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    class ServerHandle
    {
        public static void WelcomeRecieved(int _fromClient,Packet _packet)
        {
            int _clientIdCheck = _packet.ReadInt();
            string _username = _packet.ReadString();

            Server.clients[_fromClient].username = _username;

            Console.WriteLine($"{Server.clients[_fromClient].tcp.socket.Client.RemoteEndPoint} connected as {_username}");

            if(_fromClient != _clientIdCheck)
            {
                Console.WriteLine("Very Bad Error");
            }

            ServerSend.ClientConnected(_fromClient,_username);
        }

        public static void GetMessage(int _fromClient,Packet _packet)
        {
            string _username = _packet.ReadString();
            string _msg = _packet.ReadString();

            ServerSend.SendMessage(_fromClient, _username, _msg);
        }
    }
}
