using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GsTeamupChat
{
    class ChatService
    {
        EdgeTemplate edgeTemplate = new EdgeTemplate();

        public void AcceptChat(TeamupEvent ev)
        {
            ChatMessage chatMessage = edgeTemplate.GetMessage(ev.chat.room, ev.chat.msg);

            if (chatMessage.content.Length != chatMessage.len)
            {
                string longMessage = edgeTemplate.GetMessageLong(ev.chat.room, ev.chat.msg);
                if (longMessage != null || longMessage.Length > 0)
                {
                    chatMessage.content = longMessage;
                }
            }
            SendResponseChat(chatMessage, ev.chat.room);
        }

        public void SendResponseChat(ChatMessage chatMessage, long room)
        {
            string msg = "";
            switch (chatMessage.type)
            {
                case 1:
                    msg = MakeMessage(chatMessage.content);
                    break;
                default:
                    break;
            }
            if (msg != "")
            {
                edgeTemplate.Say(room, msg);
            }
        }

        private string MakeMessage(string msg)
        {
            if ("?".Equals(msg) || "help".Equals(msg, StringComparison.OrdinalIgnoreCase))
            {
                return "안녕하세요 김도움입니다.";
            }
            else if ("ping".Equals(msg, StringComparison.OrdinalIgnoreCase))
            {
                return "pong";
            }
            // 메세지에 맞게 추가하면 됨.
            return "? 나 help를 이용해주세요";
        }
    }
}
