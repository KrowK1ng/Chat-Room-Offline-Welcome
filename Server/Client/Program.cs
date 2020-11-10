using System;
using System.Threading;

namespace Client
{
    class Program
    {
        private static Client client;
        private static bool isRunning=false;

        static void Main(string[] args)
        {
            isRunning = true;

            Thread mainThread = new Thread(new ThreadStart(MainThread));
            mainThread.Start();

            Console.Write("Enter a nickname: ");
            string _name = Console.ReadLine();
            Console.Write("Enter the ip adress: ");
            string ip = Console.ReadLine();
            Console.Write("Enter the port: ");
            int _port = Int32.Parse(Console.ReadLine());

            client = new Client(ip,_port,_name);
            client.ConnectToServer();
            
        }

        private static void MainThread()
        {
            //Console.WriteLine($"Thread started. Running at {Constants.TICKS_PER_SEC} ticks per second");
            DateTime _nextLoop = DateTime.Now;

            while (isRunning)
            {
                while (_nextLoop < DateTime.Now)
                {
                    GameLogic.Update();
                    _nextLoop = _nextLoop.AddMilliseconds(Constants.MS_PER_TICK);

                    if(_nextLoop > DateTime.Now)
                    {
                        Thread.Sleep(_nextLoop - DateTime.Now);
                    }
                }
            }
        }
    }
}
