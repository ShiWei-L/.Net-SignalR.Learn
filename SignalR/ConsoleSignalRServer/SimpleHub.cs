using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace ConsoleSignalRServer
{
    public class SimpleHub : Hub
    {
        public void HelloService()
        {
            Clients.All.helloClient();
        }
    }
}
