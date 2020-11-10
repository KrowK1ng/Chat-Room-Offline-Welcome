using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Server
{
    class Server
    {
        public static int maxPlayers { get; private set; }
        public static int port { get; private set; }
        private static TcpListener tcpListener;
        public static Dictionary<int,Client> clients = new Dictionary<int,Client>();

        public delegate void PacketHandler(int _fromClient,Packet _packet);
        public static Dictionary<int, PacketHandler> packetHandlers;

        public static void Start(int _port, int _maxPlayers)
        {
            maxPlayers = _maxPlayers;
            port = _port;

            InitializeServerData();
            tcpListener = new TcpListener(IPAddress.Any, port);
            tcpListener.Start();
            tcpListener.BeginAcceptTcpClient(new AsyncCallback(TCPConnectCallback),null);

            Console.WriteLine($"Server started on {port}");
        }

        private static void TCPConnectCallback(IAsyncResult _result)
        {
            TcpClient _client = tcpListener.EndAcceptTcpClient(_result);
            tcpListener.BeginAcceptTcpClient(new AsyncCallback(TCPConnectCallback),null);

            Console.WriteLine($"Connecting from {_client.Client.RemoteEndPoint}");

            for(int i = 1; i <= maxPlayers; i++)
            {
                if (clients[i].tcp.socket == null)
                {
                    clients[i].tcp.Connect(_client);
                    Console.WriteLine("Client Connected Succesefully");
                    return;
                }
            }

            Console.WriteLine("The server is full :(");
        }

        private static void InitializeServerData()
        {
            for(int i = 1; i <= maxPlayers; i++)
            {
                clients.Add(i,new Client(i));
            }

            packetHandlers = new Dictionary<int, PacketHandler>()
            {
                { (int)ClientPackets.welcomeReceived,  ServerHandle.WelcomeRecieved },
                { (int)ClientPackets.getMessage,  ServerHandle.GetMessage }
            };
        }
    }
}
