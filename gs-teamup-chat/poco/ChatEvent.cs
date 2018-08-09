using System;
using Newtonsoft.Json;

namespace GsTeamupChat
{
    class ChatEvent
    {
        [JsonProperty]
        internal int team { get; set; }
        [JsonProperty]
        internal long room { get; set; }
        [JsonProperty]
        internal int user { get; set; }
        [JsonProperty]
        internal long msg { get; set; }
        [JsonProperty]
        internal int alert { get; set; }
        [JsonProperty]
        internal String name { get; set; }
        [JsonProperty]
        internal int roomtype { get; set; }
    }
}
