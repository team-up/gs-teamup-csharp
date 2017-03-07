using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Net;
using Newtonsoft.Json;
using System.Configuration;

namespace GsTeamupChat
{
    class EventService
    {
        private string eventUrl = ConfigurationManager.AppSettings["eventUrl"];
        private Oauth2Template template = new Oauth2Template();
        private ChatService chatService = new ChatService();

        public TeamupEventList Polling()
        {
            Oauth2Token token = template.GetToken();

            if (token == null)
            {
                return null;
            }

            RestClient client = new RestClient(eventUrl);

            var request = new RestRequest("/v1/events", Method.GET);

            request.AddHeader("Authorization", "bearer " + token.accessToken);
            request.AddHeader("Content-Type", "application/json");
            request.Timeout = 1000 * 35;

            IRestResponse response = client.Execute(request);
            
            if (HttpStatusCode.OK.Equals(response.StatusCode))
            {
                TeamupEventList eventList = JsonConvert.DeserializeObject<TeamupEventList>(response.Content);
                return eventList;
            }

            return null;
        }

        public void ActionEvent(TeamupEvent ev) {
            switch (ev.type)
            {
                case "chat.message":
                    chatService.AcceptChat(ev);
                    break;
                // do other event case
                default:
                    break;
            }

        }
    }
}
