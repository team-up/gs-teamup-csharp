using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Net;
using Newtonsoft.Json;

namespace gs_teamup_chat
{
    class EventService
    {
        Oauth2Template template = new Oauth2Template();
        ChatService chatService = new ChatService();

        public TeamupEventList polling()
        {
            Oauth2Token token = template.getToken();

            if (token == null)
            {
                return null;
            }

            RestClient client = new RestClient("https://ev.tmup.com/");

            var request = new RestRequest("/v1/events", Method.GET);

            request.AddHeader("Authorization", "bearer " + token.accessToken);
            request.AddHeader("Content-Type", "application/json");
            request.Timeout = 1000 * 10;

            IRestResponse response = client.Execute(request);
            
            if (HttpStatusCode.OK.Equals(response.StatusCode))
            {
                TeamupEventList eventList = JsonConvert.DeserializeObject<TeamupEventList>(response.Content);
                return eventList;
            }

            return null;
        }

        public void actionEvent(TeamupEvent ev) {
            switch (ev.type)
            {
                case "chat.message":
                    chatService.acceptChat(ev);
                    break;
                // do other event case
                default:
                    break;
            }

        }
    }
}
