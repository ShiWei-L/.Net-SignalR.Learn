using System;
using System.Threading.Tasks;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(ConsoleSignalRServer.Startup))]

namespace ConsoleSignalRServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //GlobalHost.DependencyResolver.UseRedis("localhost", 6379, string.Empty, "signalR");

            //SqlServer
            //GlobalHost.DependencyResolver.UseSqlServer("server=localhost ;user id=sa; password=SqlServerByLSW; Database=signalR");

          
            // 有关如何配置应用程序的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=316888
            app.UseCors(CorsOptions.AllowAll).MapSignalR();
        }
    }

}
