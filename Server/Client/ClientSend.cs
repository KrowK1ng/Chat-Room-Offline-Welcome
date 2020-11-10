﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    class ClientSend
    {
        private static void SendTCPData(Packet _packet)
        {
            _packet.WriteLength();
            Client.instance.tcp.SendData(_packet);
        }

        #region Packets
        public static void WelcomeRecieved()
        {
            using (Packet _packet = new Packet((int)ClientPackets.welcomeReceived))
            {
                _packet.Write(Client.instance.myId);
                _packet.Write(Client.instance.name);

                SendTCPData(_packet);
            }
        }
        #endregion
    }
}
