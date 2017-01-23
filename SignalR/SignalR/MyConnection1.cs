using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Diagnostics;

namespace SignalR
{
    public class MyConnection1 : PersistentConnection
    {
        /// <summary>
        /// 连接事件
        /// </summary>
        /// <returns></returns>
        protected override Task OnConnected(IRequest request, string connectionId)
        {
            Debug.WriteLine("onConnection......");
            return Connection.Send(connectionId, "Welcome!");
        }

        /// <summary>
        /// 收到客户端消息事件
        /// </summary>
        /// <returns></returns>
        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            Debug.WriteLine("onReceived......");
            return Connection.Send(connectionId, $"Service : {data}");
        }

        /// <summary>
        /// 断线事件
        /// </summary>
        /// <returns></returns>
        protected override Task OnDisconnected(IRequest request, string connectionId, bool stopCalled)
        {
            Debug.WriteLine("OnDisconnected......");
            return base.OnDisconnected(request, connectionId, stopCalled);
        }

        /// <summary>
        /// 断线重连事件
        /// </summary>
        /// <returns></returns>
        protected override Task OnReconnected(IRequest request, string connectionId)
        {
            Debug.WriteLine("OnReconnecteds......");
            return base.OnReconnected(request, connectionId);
        }
    }
}