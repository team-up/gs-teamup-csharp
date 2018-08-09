using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace GsTeamupChat
{
    class Oauth2Template : BaseTemplate
    {
        private string authUrl = ConfigurationManager.AppSettings["authUrl"];

        private string clientId = ConfigurationManager.AppSettings["clientId"];
        private string clientSecret = ConfigurationManager.AppSettings["clientSecret"];

        private string botEmail = ConfigurationManager.AppSettings["botEmail"];
        private string botPassword = ConfigurationManager.AppSettings["botPassword"];

        internal static Oauth2Token oauth2Token { get; set; }

        public Oauth2Token GetToken()
        {
            if (oauth2Token != null && oauth2Token.IsExpired())
            {
                oauth2Token = null;
            }
            if (oauth2Token == null)
            {
                RestClient client = new RestClient(authUrl);

                var request = new RestRequest("/oauth2/token", Method.POST);
                request.AddParameter("grant_type", "password");
                request.AddParameter("client_id", clientId);
                request.AddParameter("client_secret", clientSecret);
                request.AddParameter("username", botEmail);
                request.AddParameter("password", botPassword);

                IRestResponse response = client.Execute(request);
                Console.WriteLine("인증정보: " + response.Content);
                if (HttpStatusCode.OK.Equals(response.StatusCode))
                {
                    oauth2Token = JsonConvert.DeserializeObject<Oauth2Token>(response.Content);
                    oauth2Token.expireDate = DateTime.Now.AddSeconds(oauth2Token.expiresIn);
                }
            }
            return oauth2Token;
        }
    }
}
