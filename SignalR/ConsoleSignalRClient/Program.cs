using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace ConsoleSignalRClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var hub = new HubConnection("http://localhost:8890");

            var proxy = hub.CreateHubProxy("SimpleHub");

            proxy.On("helloClient", () =>
            {
                Console.WriteLine("收到服务器的问候");
            });

            hub.Start().Wait();

            proxy.Invoke("HelloService").Wait();

            Console.ReadKey();
        }
    }
}
