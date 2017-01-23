using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SimpleHub.Startup))]

namespace SimpleHub
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=316888

            //也可以  app.MapSignalR();
            app.MapSignalR("/simpleHub", new HubConfiguration());
        }
    }
}
