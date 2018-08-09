using Newtonsoft.Json;

namespace GsTeamupChat
{
    class UserResponse
    {
        [JsonProperty]
        internal long index { get; set; }

        [JsonProperty]
        internal string name { get; set; }

        [JsonProperty]
        internal string position { get; set; }

        [JsonProperty]
        internal string job_title { get; set; }
    }
}
