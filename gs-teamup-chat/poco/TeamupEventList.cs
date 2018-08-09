using Newtonsoft.Json;

namespace GsTeamupChat
{
    class TeamupEventList
    {
        [JsonProperty("events")]
        internal TeamupEvent[] events { get; set;}
    }
}
