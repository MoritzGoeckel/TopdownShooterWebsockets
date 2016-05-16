using Alchemy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Alchemy.Classes;

namespace TopdownShooterSever
{
    class GameTCPServer
    {
        public List<GameClient> clients = new List<GameClient>();

        private WebSocketServer server;

        public GameTCPServer(int port)
        {
            server = new WebSocketServer(port, IPAddress.Any)
            {
                OnReceive = OnReceive,
                OnConnected =  OnConnect,
                OnDisconnect = OnDisconnect,
                TimeOut = new TimeSpan(0, 10, 0)
            };

            server.Start();
            Console.WriteLine("Start");
        }

        private void OnDisconnect(UserContext context)
        {
            Console.WriteLine("Disconnect");
        }

        private void OnConnect(UserContext context)
        {
            clients.Add(new GameClient(context));
            Console.WriteLine(context.ClientAddress.ToString());
        }

        private void OnReceive(UserContext context)
        {
            
        }

        public void stop()
        {
            foreach (GameClient client in clients)
                client.disconnect();

            server.Stop();
        }
    }
}
