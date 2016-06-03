using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Boolean IsExpired()
        {
            return this.expiresIn <= 0;
        }
    }
}
