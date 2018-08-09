using Newtonsoft.Json;
using System;

namespace GsTeamupChat
{
    class Oauth2Token
    {
        [JsonProperty("access_token")]
        internal string accessToken { get; set; }
        [JsonProperty("expires_in")]
        internal int expiresIn { get; set; }
        [JsonProperty("refresh_token")]
        internal string refreshToken { get; set; }
        internal DateTime expireDate { get; set; }
        public Boolean IsExpired()
        {
            return DateTime.Now > expireDate;
        }
    }
}
