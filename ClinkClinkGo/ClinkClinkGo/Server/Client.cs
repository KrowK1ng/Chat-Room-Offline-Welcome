using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace ClinkClinkGo
{
    class Client
    {
        public static Client instance;
        public static int dataBufferSize = 4096;

        public string ip = "127.0.0.1";
        public int port = 26950;
        public int myId = 0;
        public string name = "John";
        public TCP tcp;

        private bool isConnected = false;
        private delegate void PacketHandler(Packet _packet);
        private static Dictionary<int, PacketHandler> packetHandlers;

        public Client(string _ip,int _port,string _name)
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                // to destroy this object
            }

            instance.ip = _ip;
            instance.port = _port;
            instance.name = _name;
            Start();
        }

        private void Start()
        {
            tcp = new TCP();
        }
        
        public static void Quit()
        {
            instance.Disconnect();
        }

        public void ConnectToServer()
        {
            isConnected = true;
            InitializeClientData();
            tcp.Connect();
        }

        public class TCP
        {
            public TcpClient socket;

            private NetworkStream stream;
            private Packet recievedData;
            private byte[] recieveBuffer;

            public void Connect()
            {
                socket = new TcpClient
                {
                    ReceiveBufferSize = dataBufferSize,
                    SendBufferSize = dataBufferSize
                };

                recieveBuffer = new byte[dataBufferSize];
                socket.BeginConnect(instance.ip, instance.port, ConnectCallback, socket);
            }

            private void ConnectCallback(IAsyncResult _result)
            {
                socket.EndConnect(_result);

                if (!socket.Connected)
                {
                    Console.WriteLine("Connection Failed");
                    return;
                }

                Console.WriteLine("Connected Succesefuly");

                stream = socket.GetStream();

                recievedData = new Packet();

                stream.BeginRead(recieveBuffer, 0, dataBufferSize, RecieveCallback, null);
            }

            public void SendData(Packet _packet)
            {
                try
                {
                    if(socket != null)
                    {
                        stream.BeginWrite(_packet.ToArray(),0,_packet.Length(),null,null);
                    }
                }
                catch
                {
                    Console.WriteLine("ERROR");
                }
            }

            private void RecieveCallback(IAsyncResult _result)
            {
                try
                {
                    int _byteLength = stream.EndRead(_result);
                    if (_byteLength <= 0)
                    {
                        instance.Disconnect();
                        return;
                    }

                    byte[] _data = new byte[_byteLength];
                    Array.Copy(recieveBuffer, _data, _byteLength);

                    recievedData.Reset(HandleData(_data));
                    stream.BeginRead(recieveBuffer, 0, dataBufferSize, RecieveCallback, null);
                }
                catch (Exception _ex)
                {
                    Disconnect();
                    Console.WriteLine($"Error recieving data {_ex}");
                }
            }

            private bool HandleData(byte[] _data)
            {
                int _packetLength = 0;

                recievedData.SetBytes(_data);

                if(recievedData.UnreadLength() >= 4)
                {
                    _packetLength = recievedData.ReadInt();
                    if(_packetLength <= 0)
                    {
                        return true;
                    }
                }

                while(_packetLength > 0 && _packetLength <= recievedData.UnreadLength())
                {
                    byte[] _packetBytes = recievedData.ReadBytes(_packetLength);
                    ThreadManager.ExecuteOnMainThread(() => 
                    {
                        using (Packet _packet = new Packet(_packetBytes))
                        {
                            int _packetId = _packet.ReadInt();
                            packetHandlers[_packetId](_packet);
                        }
                    });

                    _packetLength = 0;

                    if (recievedData.UnreadLength() >= 4)
                    {
                        _packetLength = recievedData.ReadInt();
                        if (_packetLength <= 0)
                        {
                            return true;
                        }
                    }
                }

                if (_packetLength <= 1)
                {
                    return true;
                }

                return false;
            }

            private void Disconnect()
            {
                instance.Disconnect();

                stream = null;
                recieveBuffer = null;
                recievedData = null;
                socket = null;
            }

        }

        private void InitializeClientData()
        {
            packetHandlers = new Dictionary<int, PacketHandler>()
            {
                { (int)ServerPackets.welcome,  ClientHandle.Welcome },
                { (int)ServerPackets.clientConnected,  ClientHandle.ClientConnected },
                { (int)ServerPackets.clientDisconnected,  ClientHandle.ClientDisconnected },
                { (int)ServerPackets.getMessage,  ClientHandle.GetMessage }
            };
        }

        private void Disconnect()
        {
            if (isConnected)
            {
                isConnected = false;
                tcp.socket.Close();
            }
        }
    }
}
