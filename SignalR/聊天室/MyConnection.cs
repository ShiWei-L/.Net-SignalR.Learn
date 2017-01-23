using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;

namespace 聊天室
{
    public class MyConnection : PersistentConnection
    {

        private static IList<Group> RoomList { get; set; }

        private static Random Rdom { get; set; }

        /// <summary>
        /// 静态构造函数
        /// </summary>
        static MyConnection()
        {
            RoomList = new List<Group>();
            Rdom = new Random();
        }


        protected override Task OnConnected(IRequest request, string connectionId)
        {
            var outPut = new OutPut
            {
                ResultType = "RoomList",
                Data = RoomList,
                UserName = $"游客{Rdom.Next(1, 999)}"
            };
            //返回房间信息
            return Connection.Send(connectionId, JsonConvert.SerializeObject(outPut));
        }

        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            var dto = JsonConvert.DeserializeObject<GroupDto>(data);

            var outPut = new OutPut
            {
                ResultType = "msgResult",
                Data = $"{dto.UserName} : {dto.Data}",
                CurrentRoomId = dto.RoomId
            };

            if (dto.Action.Equals("jionUs"))
            {
                //加入聊天室
                Groups.Add(connectionId, dto.RoomId);
                outPut.Data = $"欢迎{dto.UserName}加入{dto.RoomName}聊天室";
                outPut.CurrentRoomId = dto.RoomId;
                Connection.Send(connectionId, JsonConvert.SerializeObject(outPut));
                return Groups.Send(dto.RoomId, JsonConvert.SerializeObject(outPut));
            }

            if (dto.Action.Equals("createRoom"))
            {
                //创建聊天室
                var room = new Group() { RoomId = Guid.NewGuid().ToString(), RoomName = dto.RoomName };
                Groups.Add(connectionId, room.RoomId);
                dto.RoomId = room.RoomId;
                RoomList.Add(room);
                //返回聊天室列表
                outPut.ResultType = "RoomList";
                outPut.Data = RoomList;
                outPut.CurrentRoomId = dto.RoomId;

                //发送消息
                return Connection.Send(connectionId, JsonConvert.SerializeObject(outPut));

            }
            //发送消息
            return Groups.Send(dto.RoomId, JsonConvert.SerializeObject(outPut), connectionId);
        }

    }
}