using System;
using System.Threading.Tasks;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
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

            //把自己的实现注入到容器中 n
            GlobalHost.DependencyResolver.Register(typeof(IJavaScriptMinifier), () => new DefaultJavaScriptMinifier());

            //也可以  app.MapSignalR();
            app.MapSignalR("/simpleHub", new HubConfiguration());
        }
    }



    /// <summary>
    /// 自定义 js 压缩
    /// </summary>
    public class DefaultJavaScriptMinifier : IJavaScriptMinifier
    {
        public string Minify(string source)
        {
            return new Minifier().MinifyJavaScript(source);
        }
    }
}
