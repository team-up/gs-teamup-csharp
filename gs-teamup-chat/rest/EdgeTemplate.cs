using System;
using System.Configuration;

namespace GsTeamupChat
{
    class EdgeTemplate : BaseTemplate
    {
        private string edgeUrl = ConfigurationManager.AppSettings["edgeUrl"];

        public ChatMessage GetMessage(long room, long msg, bool all = true)
        {
            string query = all ? "?all=1" : "?all=0";
            return Get<ChatMessage>(edgeUrl, "/v3/message/summary/" + room + "/" + msg + query);
        }

        public MessageResponse Say(long room, Message msg)
        {
            return Post<MessageResponse>(edgeUrl, "/v3/message/" + room, msg);
        }

        public RoomResponse CreateRoom(long team, Users users)
        {
            return Post<RoomResponse>(edgeUrl, "/v3/room/" + team, users);
        }
    }
}
