using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SimpleHub
{
    //[HubName("HubDemo2")]
    public class HubDemo : Hub
    {

        //[HubMethodName("Hello")]
        public void HelloService()
        {
            Clients.All.helloClient();
        }

    }
}