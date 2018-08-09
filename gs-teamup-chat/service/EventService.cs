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
        private ChatService chatService = null;

        public EventService(ChatService chatService)
        {
            this.chatService = chatService;
        }

        public EventInfo GetInfo()
        {
            RestClient client = new RestClient(eventUrl);

            var request = new RestRequest("/");
            IRestResponse response = client.Get(request);
            if (HttpStatusCode.OK.Equals(response.StatusCode))
            {
                EventInfo eventInfo = JsonConvert.DeserializeObject<EventInfo>(response.Content);
                return eventInfo;
            }
            else if ((int)response.StatusCode / 100 == 4)
            {
                throw new System.AggregateException();
            }

            return null;
        }

        public TeamupEventList Polling(int timeout)
        {
            Oauth2Token token = template.GetToken();

            if (token == null)
            {
                return null;
            }

            RestClient client = new RestClient(eventUrl);

            var request = new RestRequest("/v3/events", Method.GET);

            request.AddHeader("Authorization", "bearer " + token.accessToken);
            request.AddHeader("Content-Type", "application/json");
            request.Timeout = timeout;

            IRestResponse response = client.Execute(request);
            
            if (HttpStatusCode.OK.Equals(response.StatusCode))
            {
                TeamupEventList eventList = JsonConvert.DeserializeObject<TeamupEventList>(response.Content);
                return eventList;
            }

            return null;
        }

        public void ActionEvent(TeamupEvent ev)
        {
            switch (ev.type)
            {
                case "chat.initbot":
                    chatService.AcceptInit(ev);
                    break;
                case "chat.message":
                    chatService.AcceptChat(ev);
                    break;
                default:
                    break;
            }

        }
    }
}
