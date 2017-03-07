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

        public ChatMessage GetMessage(long room, long msg)
        {
            return Get<ChatMessage>("/v3/message/summary/" + room + "/" + msg);
        }

        public string GetMessageLong(long room, long msg)
        {
            return Get<String>("/v3/message/" + room + "/" + msg);
        }

        public void Say(long room, string msg)
        {
            Post<MessageResponse>("/v3/message/" + room, new Message(msg));
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
                try
                {
                    return JsonConvert.DeserializeObject<T>(response.Content);
                }
                catch (JsonReaderException e)
                {
                    return (T)Convert.ChangeType(response.Content, typeof(T));
                }
            }

            return default(T);
        }
    }
}
