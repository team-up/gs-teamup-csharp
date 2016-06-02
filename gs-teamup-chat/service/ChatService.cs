using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gs_teamup_chat
{
    class ChatService
    {
        EdgeTemplate edgeTemplate = new EdgeTemplate();

        public void acceptChat(TeamupEvent ev)
        {
            ChatMessage chatMessage = edgeTemplate.getMessage(ev.chat.room, ev.chat.msg);

            if (chatMessage.content.Length != chatMessage.len)
            {
                string longMessage = edgeTemplate.getMessageLong(ev.chat.room, ev.chat.msg);
                if (longMessage != null || longMessage.Length > 0)
                {
                    chatMessage.content = longMessage;
                }
            }
            sendResponseChat(chatMessage, ev.chat.room);
        }

        public void sendResponseChat(ChatMessage chatMessage, int room)
        {
            string msg = "";
            switch (chatMessage.type)
            {
                case 1:
                    msg = makeMessage(chatMessage.content);
                    break;
                default:
                    break;
            }
            if (msg != "")
            {
                edgeTemplate.say(room, msg);
            }
        }

        private string makeMessage(string msg)
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
