using Alchemy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TopdownShooterSever
{
    class Program
    {
        static string startupPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
        static bool end = false;
        static void Main(string[] args)
        {
            GameTCPServer server = new GameTCPServer(3000);

            Thread thread = new Thread(delegate () {
                while (end == false)
                {
                    foreach (GameClient client in server.clients)
                    {
                        foreach(string msg in client.recievedMessages)
                        {
                            Console.WriteLine("--------- " + msg);
                        }

                        client.recievedMessages.Clear();
                        client.sendData(DateTime.Now.Second.ToString() + " seconds");
                    }
                    Thread.Sleep(1000);
                }
            });

            thread.Start();

            
            Console.ReadKey();

           // end = true;
            //server.stop();
        }
    }
}
