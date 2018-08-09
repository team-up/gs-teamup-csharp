using Newtonsoft.Json;

namespace GsTeamupChat
{
    class Users
    {
        [JsonProperty]
        internal long[] users { get; set; }

        public Users(long[] users)
        {
            this.users = users;
        }
    }
}
