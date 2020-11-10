using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinkClinkGo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        public static Client client;
        private static bool isRunning = false;
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Chat x = new Chat();
            //x.Hide();
            Application.Run(new Form1());

            /*isRunning = true;

            Thread mainThread = new Thread(new ThreadStart(MainThread));
            mainThread.Start();*/

            /*string _name = Console.ReadLine();
            string ip = Console.ReadLine();
            int _port = Int32.Parse(Console.ReadLine());

            client = new Client(ip, _port, _name);
            client.ConnectToServer();*/
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

                    if (_nextLoop > DateTime.Now)
                    {
                        Thread.Sleep(_nextLoop - DateTime.Now);
                    }
                }
            }
        }
    }
}
