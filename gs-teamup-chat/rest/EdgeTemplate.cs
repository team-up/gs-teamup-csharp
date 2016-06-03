using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using RestSharp;
using System.Configuration;

namespace gs_teamup_chat
{
    class EdgeTemplate
    {
        private string edgeUrl = ConfigurationManager.AppSettings["edgeUrl"];

        public ChatMessage getMessage(int room, int msg)
        {
            return get<ChatMessage>("/v1/message/summary/" + room + "/" + msg);
        }

        public string getMessageLong(int room, int msg)
        {
            return get<string>("/v1/message/" + room + "/" + msg);
        }

        public void say(int room, string msg)
        {
            post<MessageResponse>("/v1/message/" + room, new Message(msg));
        }

        private T post<T>(string url, object data)
        {
            return call<T>(url, data, Method.POST);
        }

        private T get<T>(string url) 
        {
            return call<T>(url, null, Method.GET);
        }

        private T call<T>(string url, object data, Method method)
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
