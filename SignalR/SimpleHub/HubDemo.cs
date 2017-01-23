using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SimpleHub
{
    public class HubDemo : Hub
    {
        public void HelloService()
        {
            Clients.All.helloClient();
        }
    }
}