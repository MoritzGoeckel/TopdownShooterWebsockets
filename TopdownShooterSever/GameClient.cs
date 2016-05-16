using Alchemy.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace TopdownShooterSever
{
    class GameClient
    {
        public List<string> recievedMessages = new List<string>();

        private UserContext userContext;

        public GameClient(UserContext userContext)
        {
            this.userContext = userContext;
            userContext.SetOnReceive(new Alchemy.OnEventDelegate(gotMessage));
        }

        public void gotMessage(UserContext context)
        {
            recievedMessages.Add(context.DataFrame.ToString());
        }

        public void sendData(string msg)
        {
            userContext.Send(msg);
        }

        public void disconnect()
        {
            sendData("#ENDCONNECTION");
        }
    }
}
