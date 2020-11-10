using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    class ServerSend
    {
        private static void SendTCPData(int _tcpClient, Packet _packet)
        {
            _packet.WriteLength();
            Server.clients[_tcpClient].tcp.SendData(_packet);
        }
        private static void SendTCPDataToAll(Packet _packet)
        {
            _packet.WriteLength();
            for (int i = 1; i <= Server.maxPlayers; i++)
            {
                Server.clients[i].tcp.SendData(_packet);
            }
        }
        private static void SendTCPDataToAllExcept(int _exceptClient,Packet _packet)
        {
            _packet.WriteLength();
            for (int i = 1; i <= Server.maxPlayers; i++)
            {
                if (i != _exceptClient)
                {
                    Server.clients[i].tcp.SendData(_packet);
                }
            }
        }

        #region Packets
        public static void Welcome(int _tcpClient, string _msg)
        {
            using (Packet _packet = new Packet((int)ServerPackets.welcome))
            {
                _packet.Write(_msg);
                _packet.Write(_tcpClient);

                SendTCPData(_tcpClient,_packet);
            }
        }

        public static void ClientConnected(int _tcpClient, string _username)
        {
            using (Packet _packet = new Packet((int)ServerPackets.clientConnected))
            {
                _packet.Write(_username);

                SendTCPDataToAllExcept(_tcpClient, _packet);
            }
        }

        public static void SendMessage(int _tcpClient, string _username , string _msg)
        {
            using (Packet _packet = new Packet((int)ServerPackets.sendMessage))
            {
                _packet.Write(_username);
                _packet.Write(_msg);

                SendTCPDataToAllExcept(_tcpClient, _packet);
            }
        }

        public static void ClientDisconnected(int _tcpClient, string _username)
        {
            using (Packet _packet = new Packet((int)ServerPackets.clientDisconnected))
            {
                _packet.Write(_username);

                SendTCPDataToAllExcept(_tcpClient, _packet);
            }
        }
        #endregion
    }
}
