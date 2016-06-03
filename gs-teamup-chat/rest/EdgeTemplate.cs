using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using RestSharp;
using System.Configuration;

namespace GsTeamupChat
{
    class EdgeTemplate
    {
        private string edgeUrl = ConfigurationManager.AppSettings["edgeUrl"];

        public ChatMessage GetMessage(int room, int msg)
        {
            return Get<ChatMessage>("/v1/message/summary/" + room + "/" + msg);
        }

        public string GetMessageLong(int room, int msg)
        {
            return Get<string>("/v1/message/" + room + "/" + msg);
        }

        public void Say(int room, string msg)
        {
            Post<MessageResponse>("/v1/message/" + room, new Message(msg));
        }

        private T Post<T>(string url, object data)
        {
            return Call<T>(url, data, Method.POST);
        }

        private T Get<T>(string url) 
        {
            return Call<T>(url, null, Method.GET);
        }

        private T Call<T>(string url, object data, Method method)
        {
            RestClient client = new RestClient(edgeUrl);

            var request = new RestRequest(url, method);
            request.AddHeader("Authorization", "bearer " + Oauth2Template.oauth2Token.accessToken);
            request.AddHeader("Content-Type", "application/json");

            if (data != null)
            {
                string jsonString = JsonConvert.SerializeObject(data);
                request.AddParameter("application/json", jsonString, ParameterType.RequestBody);
                request.RequestFormat = DataFormat.Json;
            }

            IRestResponse response = client.Execute(request);

            if (HttpStatusCode.OK.Equals(response.StatusCode))
            {
                return JsonConvert.DeserializeObject<T>(response.Content);
            }

            return default(T);
        }
    }
}
