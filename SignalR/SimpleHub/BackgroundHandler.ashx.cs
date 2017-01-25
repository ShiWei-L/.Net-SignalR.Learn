using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SimpleHub
{
    /// <summary>
    /// 后台处理程序
    /// </summary>
    public class BackgroundHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            var hub = GlobalHost.ConnectionManager.GetHubContext<HubDemo>();
          
            //在集线器外部推送消息
            hub.Clients.All.notice("都起来吃饭了");
        }

        public bool IsReusable => false;
    }
}