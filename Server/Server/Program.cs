using System;
using System.IO;
using System.Net;
using System.Threading;

namespace Server
{
    class Program
    {

        private static bool isRunning = false;
        private static string IPAddress;
        static void Main(string[] args)
        {
            isRunning = true;

            Thread mainThread = new Thread(new ThreadStart(MainThread));
            mainThread.Start();
            IPAddress = GetIPAddress();
            Console.WriteLine($"IP Address: {IPAddress}");

            Console.WriteLine("Insert the port:");
            int _port = Int32.Parse(Console.ReadLine());
            Server.Start(_port,10);
            Console.ReadLine();
        }

        private static string GetIPAddress()
        {
            string _Address = "";
            WebRequest request = WebRequest.Create("http://checkip.dyndns.com/");
            using (WebResponse response = request.GetResponse())
                using (StreamReader _stream = new StreamReader(response.GetResponseStream()))
            {
                _Address = _stream.ReadToEnd();
            }
            int _first = _Address.IndexOf("Address: ") + 9;
            int _last = _Address.IndexOf("</body>");
            _Address = _Address.Substring(_first, _last - _first);
            return _Address;
        }

        private static void MainThread()
        {
            Console.WriteLine($"Thread started. Running at {Constants.TICKS_PER_SEC} ticks per second");
            DateTime _nextLoop = DateTime.Now;

            while (isRunning)
            {
                while (_nextLoop < DateTime.Now)
                {
                    GameLogic.Update();
                    _nextLoop = _nextLoop.AddMilliseconds(Constants.MS_PER_TICK);

                    if (_nextLoop > DateTime.Now)
                    {
                        Thread.Sleep(_nextLoop - DateTime.Now);
                    }
                }
            }
        }
    }
}
