using System;

namespace GsTeamupChat
{
    class ChatService
    {
        protected EdgeTemplate edgeTemplate = new EdgeTemplate();

        public void AcceptInit(TeamupEvent ev)
        {
            OnWelcome(ev.chat.team, ev.chat.user, ev.chat.roomtype, ev.chat.room);
        }

        public void AcceptChat(TeamupEvent ev)
        {
            ChatMessage chatMessage = edgeTemplate.GetMessage(ev.chat.room, ev.chat.msg);
            if (chatMessage == null)
                return;

            OnChat(ev.chat.room, chatMessage);
        }

        public virtual void OnWelcome(long team, long user, int roomtype, long room)
        {
            Button[] message_buttons = new Button[] {
                        Button.NewUrlInstance("google", "http://www.google.com")
                    };
            Button[] scroll_buttons = new Button[] {
                        Button.NewTextInstance("?", "id_?")
                    };
            Button[] bottom_buttons = new Button[] {
                        Button.NewTextInstance("ping", "id_ping")
                    };
            Extra botExtra = Extra.NewInstance(message_buttons, scroll_buttons, Bottom.NewButtonInstance(bottom_buttons));
            edgeTemplate.Say(room, new Message("안녕하세요.\n저는 샘플봇입니다.", new Extras(botExtra)));
        }

        public virtual void OnChat(long room, ChatMessage chatMessage)
        {
            String responseId = chatMessage.GetExtraUserResponseId();

            if (responseId == "id_?" || chatMessage.content == "?")
            {
                edgeTemplate.Say(room, new Message("채팅창에 ping 을 입력해 보세요."));
            }
            else if (responseId == "id_ping" || chatMessage.content == "ping")
            {
                edgeTemplate.Say(room, new Message("pong"));
            }
            else
            {
                edgeTemplate.Say(room, new Message("? 를 입력해 주세요."));
            }
        }
    }
}
