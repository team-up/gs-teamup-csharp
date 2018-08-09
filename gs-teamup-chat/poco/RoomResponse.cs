using Newtonsoft.Json;

namespace GsTeamupChat
{
    class RoomResponse
    {
        [JsonProperty]
        internal long room { get; set; }
    }
}
