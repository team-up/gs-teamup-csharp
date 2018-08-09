using System;
using Newtonsoft.Json;
using System.Net;
using RestSharp;

namespace GsTeamupChat
{
    class BaseTemplate
    {
        protected T Post<T>(string server, string url, object data)
        {
            return Call<T>(server, url, data, Method.POST);
        }

        protected T Get<T>(string server, string url) 
        {
            return Call<T>(server, url, null, Method.GET);
        }

        private T Call<T>(string server, string url, object data, Method method)
        {
            RestClient client = new RestClient(server);

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
                catch (JsonException e)
                {
                    Console.WriteLine(e.Message);
                    return default(T);
                }
            }

            return default(T);
        }
    }
}
